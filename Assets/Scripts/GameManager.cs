using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// Handles the logic of the game
/// </summary>


//TODO: Decide what should be a gameobject vs a scriptable
public class GameManager : MonoBehaviour
{
    //Referenced gameobjects
    public PlayHandler playZone;
    public HandHandler hand;
    public DeckDisplay playerDeckDisplay;
    public UIController UI;
    public BurnHandler burner;
    public ComboManager combo;

    //characters in the battle.
    //TODO: will require rework if more than one enemy/player char
    public Character player;
    public Character enemy;


    //Scriptable Objects
    BattleManager battle;
    CardLoader loader;


    //holders for aspects of player and enemy, derived from respective character 
    CharacterStats playerStats;
    CharacterStats enemyStats;
    Deck playerDeck;
    Deck enemyDeck;

    //helper classes, holders for card effects
    Card currentPlayerCard;
    CardAction currentPlayerAction;
    Card currentEnemyCard;

    //variables for game logic
    int turnCount = 1;
    static int COMBOLENGTH = 3;

    /// <summary>
    /// initialize game.
    /// </summary>
    private void Start() 
    {
        playerDeck = this.gameObject.AddComponent<Deck>();
        enemyDeck = this.gameObject.AddComponent<Deck>();

        battle = ScriptableObject.CreateInstance<BattleManager>();
        loader = ScriptableObject.CreateInstance<CardLoader>();

        playerStats = player.stats;
        enemyStats = enemy.stats;

        UI.SetChar(playerStats, 0);
        UI.SetChar(enemyStats, 1);

        playerDeck.initialize(player.decklist);
        enemyDeck.initialize(enemy.decklist);

        StartGame();
    }


    /// <summary>
    /// Initialize the game state
    /// 
    /// Currently just deals out a full hand
    /// 
    /// DESIGN Q: Additional complexity?
    /// </summary>
    public void StartGame()
    {
        //Current deck for both players to full decklist
        //Char stats to default values
        //fill hand to full
        for (int i = 0; i < hand.getMax(); i++)
        {
            string id = playerDeck.GenerateNewCard();

            //does not check if card ID is bad, should re-evaluate.
            Card card = loader.InstantiateCard(id);
            playerDeckDisplay.Deal(card);
        }
        
        UI.SetTurn(turnCount);
        setDropMode(true);

        //etc. etc.
    }

    /// <summary>
    /// Checks every frame if drop zone has a card object
    /// </summary>
    private void Update() {

        //if playzone has a card, execute turn loop
        if (playZone.hasCard)
        {
            PreExecute();
            ExecuteTurn();
            CleanUp();
        }

    }


    ///
    /// TURN LOOP:
    /// 
    /// DRAW
    /// WAIT FOR PLAYER TO DROP
    /// PRE-EXECUTE
    /// EXECUTE
    /// CLEAN-UP
    /// 
    /// 
    /// 
    // DRAW
    // Check for any draw/action manipulation
    // If manipulated, check (kinds of manipulation?)
    // Add card to hand
    /// <summary>
    /// Handles the drawing of cards.
    /// 
    /// Has Deck generate the top card, deactivate draw button, activate dropzones, and moves card to player hand.
    /// 
    /// TODO: work in draw manipulation
    /// </summary>
    public void DrawStep()
    {
        //Should be able to possibly change the top card
        //some sort of draw manipulation func

        //generate an instance of the top card
        currentPlayerCard = loader.InstantiateCard(playerDeck.GenerateNewCard());

        setDropMode(true);
        playerDeckDisplay.setActive(false);

        //pass to deckdisplay for dealing
        playerDeckDisplay.Deal(currentPlayerCard);
    }


    /// PRE-EXECUTE
    /// Called when card is dropped into a play dropzone
    /// Calculate DOTs, checks gamestate
    /// Check for any combos, calculates damage/defense values against existing player/opponent health
    /// Calculate damage (check for any status modifiers)
    /// 
    /// TODO: play vs burn actions
    /// TODO: manager for DOT effects
    /// TODO: enemy AI
    /// 
    /// <summary>
    /// Determines how turn will proceed. Checks for combos, runs enemy AI, calculates damage values.
    /// 
    /// Current Execution order:
    /// DOTs,
    /// Combo Check,
    /// Determine Card Action,
    /// Pass to execution.
    /// </summary>
    void PreExecute()
    {
        //DOTs take effect
        GameStateCheck();
        

        //take the card effect and set to current card effect
        currentPlayerCard = playZone.GetCard();

        //pass newCard to combomanager for processing
        combo.addToQueue(currentPlayerCard);
        currentPlayerCard = combo.getAction();

        //AI generate enemy card
        currentEnemyCard = loader.InstantiateCard(enemyDeck.GenerateNewCard());

        //TODO: placeholder, needs to deal with if burn
        currentPlayerAction = currentPlayerCard.play;

        //add card to GY or burn;
        // isActive = false;

        //Set enemy AI card to card action. Currently just always using play effect
    }


    /// EXECUTE
    /// <summary>
    /// Handles applying damage, playing animations/locking out players during animation
    /// 
    /// TODO: implement lockouts, animations after finishing core loop
    /// </summary>
    public void ExecuteTurn()
    {
        //should probably just pass all effects
        battle.BattleCalculations(currentPlayerAction, playerStats, currentEnemyCard.play, enemyStats);


        //StartCoroutine(Lockout(.5f));
    }
    
    // CLEAN-UP
    // Check gamestate 
    // Enable start of next turn
    /// <summary>
    /// Function to process post-turn.
    /// 
    /// Moves cards to appropriate post-turn locations.
    /// 
    /// Checks gamestate for player/enemy death
    /// 
    /// If not endstate, update values/reset variables and wait for next turn to begin
    /// </summary>
    void CleanUp()
    {
        //TODO: CURRENT ERROR: ENEMY DOES NOT REGEN CARDS
        //CARDS ARE NOT ADDED TO ENEMY'S GY
        
        //TODO: handle adding to burn vs graveyard
        if (combo.transform.childCount>=COMBOLENGTH)
        {
            playerDeck.AddToGraveyard(combo.getFirst()); 

        }
        enemyDeck.AddToGraveyard(currentEnemyCard);
        
        GameStateCheck();

        //Re-activate draw button, turn off drop zones.
        playerDeckDisplay.setActive(true);
        setDropMode(false);

        //Update turn counter.
        turnCount++;
        UI.SetTurn(turnCount);
    }


    // CHECK GAMESTATE
    // If a char health is = 0, character dies
    // Check for game over/win states given char health
    /// <summary>
    /// Checks if a character has died. Player death evaluated first.
    /// 
    /// TODO: Will eventually add more complexity to win/loss states
    /// </summary>
    void GameStateCheck()
    {
        if (playerStats.currentHP == 0)
        {
            GameOver();
        }
        else if (enemyStats.currentHP <= 0)
        {
            GameWin();
        }
    }
    void GameOver()
    {
        UI.GameOver();
        fullReset();
    }
    void GameWin()
    {
        UI.GameWin();
        fullReset();
    }

    void fullReset()
    {
        turnCount = 0;
        hand.Reset();
        combo.Reset();
    }



    /// <summary>
    /// Prevent player actions while animations play
    /// 
    /// TODO: re-evaluate code once animations made
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    IEnumerator Lockout(float time)
    {
        yield return new WaitForSeconds(time);
        //TODO: SOME ANIMATION TO REPRESENT LOCKOUT

        //PROG Q: should be in an animation manager?
    }


    /// <summary>
    /// Function to activate/inactivate drop-zones
    /// </summary>
    /// <param name="on">true if on, false if off</param>
    void setDropMode(bool on)
    {
        playZone.setMode(on);   
        burner.setMode(on);
    }

}
