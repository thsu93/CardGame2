using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manage in-game logic. 

//To Do:
//? of how to add edit phase

public class GameManager : MonoBehaviour
{
    public PlayHandler playZone;
    public HandHandler hand;
    public DeckDisplay playerDeckDisplay;
    public UIController UI;
    public BurnHandler burner;
    public Character player;
    public Character enemy;
    public ComboManager enemyCombo;
    int turnCount = 1;
    int PlayerHP;
    int PlayerMaxHP;
    int EnemyHP;
    int EnemyMaxHP;
    int damage;
    int attack;
    int heal;
    bool isActive = true;
    bool wasBurned = false;
    //NEED TO INCORPORATE OF THE GAME LOGIC, SHOULD BE IN HERE

    private void Start() 
    {
        StartGame();
    }

    void StartGame()
    {
        PlayerMaxHP = player.maxHP;
        PlayerHP = PlayerMaxHP;
        UI.setMaxHP(PlayerMaxHP, 0);
        UI.setHP(PlayerHP, 0);
        UI.playerHealth.setName(player.charName, Color.green);

        EnemyMaxHP = enemy.maxHP;
        EnemyHP = EnemyMaxHP;
        UI.setMaxHP(EnemyMaxHP, 1);
        UI.setHP(EnemyHP, 1);
        UI.enemyHealth.setName(enemy.charName, Color.red);

        playerDeckDisplay.InitializeDeck(player);
        playerDeckDisplay.b.interactable = true;
        


    }

    private void Update()
    {
        setMode(isActive);
    }

    //Called when card is dropped into a play dropzone, calculates damage/defense values against existing player/opponent health
    //Updates player health, enemy health
    //Locks out until re-activated from elsewhere.  
    public void ExecuteTurn(CardEffect playerCard)
    {

        if (playerCard.isBurnEffect)
        {
            wasBurned = true;
        }

        //obv need better AI
        //likely need a way to incorporate
        Card enemyCard = enemy.GenerateNewCard();

        BattleCalculations(playerCard, enemyCard.playEffect);

        GameStateCheck();

        UI.setHP(PlayerHP, 0);
        UI.setHP(EnemyHP, 1);
        isActive = false;
        StartCoroutine(Lockout());
    }

    IEnumerator Lockout()
    {
        yield return new WaitForSeconds(1.0f);
        NewTurn();
        isActive = true;
    }


    //Will likely have to split this into its own class later;
    //Especially with non-random enemy AI
    //Leave in for now
    void BattleCalculations(CardEffect p1, CardEffect p2)
    {
        int playerDamageTaken = p2.damageVal - p1.defenseVal - p1.healVal;
        int enemyDamageTaken = p1.damageVal - p2.defenseVal - p1.healVal;
        int playerBlock = p1.defenseVal;
        int enemyBlock = p2.defenseVal;
        int playerHeal = p1.healVal;
        int enemyHeal = p2.healVal;

        if (p1.defenseVal > p2.damageVal)
        {
            playerBlock = p2.damageVal;
        }
        if (p2.defenseVal > p1.damageVal)
        {
            enemyBlock = p1.damageVal;
        }

        if (playerDamageTaken < 0)
        {
            playerDamageTaken = 0;
        }
        
        if (enemyDamageTaken < 0)
        {
            enemyDamageTaken = 0;
        }

        if (PlayerHP+p1.healVal > player.maxHP)
        {
            playerHeal = PlayerMaxHP-PlayerHP;
        }
        if (EnemyHP+p2.healVal > enemy.maxHP)
        {
            enemyHeal = EnemyMaxHP-EnemyHP;
        }

        UI.playerDamageDisplay.displayDamage(playerDamageTaken, playerBlock, playerHeal);
        UI.enemyDamageDisplay.displayDamage(enemyDamageTaken, enemyBlock, enemyHeal);

        PlayerHP -= playerDamageTaken;
        EnemyHP -= enemyDamageTaken;
    }

    void GameStateCheck()
    {
        if (PlayerHP>PlayerMaxHP)
        {
            PlayerHP = PlayerMaxHP;
        }

        if (PlayerHP <= 0)
        {
            PlayerHP = 0;
            GameOver();
        }
        else if (EnemyHP <= 0)
        {
            EnemyHP = 0;
            GameWin();
        }
    }

    void setMode(bool on)
    {
        playZone.setMode(on);   
        burner.setMode(on);
    }

    // CardEffect enemyTurn()
    // {
    //     Card randCard = ;
    // }

    //Called when new hand is dealt
    //Queuehandler: Emptys queue, resets all queue values to defaults
    //Hand: re-fills hand
    public void NewTurn()
    {
        //this should probably be relegated to its own button
        if (turnCount == 0)
        {
            StartGame();
        }
        else 
        {
            if (wasBurned)
            {
                wasBurned = false;
            }
            else
            {
                playerDeckDisplay.Deal(player.GenerateNewCard());
            }
        }
        turnCount++;
        UI.ChangeTurn(turnCount);
        isActive = true;
    }
    
    //if queue is full, create execute button at some location (currently temp)
    //should this be in queuehandler!?
    void GameOver()
    {
        UI.GameOver();
        turnCount = 0;
        hand.Reset();
    }

    void GameWin()
    {
        UI.GameWin();
        turnCount = 0;
        hand.Reset();
    }
}
