using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles calculating, applying damage caused by played cards
/// 
/// Currently only deals with damage, defense, heal.
/// 
/// Should eventually handle status, field effects in seperate functions.
/// </summary>
/// 
public class BattleManager : MonoBehaviour
{
    /// <summary>
    /// Given a card and stats for both a player and enemy, apply those effects to each other simultaneously
    /// </summary>
    /// <param name="playerCard"></param>
    /// <param name="playerStats"></param>
    /// <param name="enemyCard"></param>
    /// <param name="enemyStats"></param>
    public void BattleCalculations(CardAction playerCard, CharacterStats playerStats, CardAction enemyCard, CharacterStats enemyStats)
    {

        //apply card effects to both characters
        ApplyAction(playerCard, enemyCard, playerStats, enemyStats);
        ApplyAction(enemyCard, playerCard, enemyStats, playerStats);
    }


    /// <summary>
    /// Determines how a card action takes effect
    /// 
    /// More description/complexity will be required
    /// </summary>
    /// <param name="effect"></param>
    /// <param name="caster">Stats of the casting character</param>
    /// <param name="target">Stats of the target character</param>
    void ApplyAction(CardAction casterEffect, CardAction targetEffect, CharacterStats caster, CharacterStats target)
    {
        int damage = casterEffect.damageVal;
        int cardHeal = casterEffect.healVal;

        damage -= targetEffect.defenseVal;
        if (damage < 0)
        {
            damage = 0;
        }
        
        Debug.Log(caster.charName + " Damage:" + damage + ", Heal: " + cardHeal);
        
        caster.changeHP(-cardHeal);
        target.changeHP(damage);
    }

    // Old code version. 
    // void BattleCalculations(CardAction p1, CardAction p2)
    // {
    //     int playerDamageTaken = p2.damageVal - p1.defenseVal - p1.healVal;
    //     int enemyDamageTaken = p1.damageVal - p2.defenseVal - p1.healVal;
    //     int playerBlock = p1.defenseVal;
    //     int enemyBlock = p2.defenseVal;
    //     int playerHeal = p1.healVal;
    //     int enemyHeal = p2.healVal;

    //     if (p1.defenseVal > p2.damageVal)
    //     {
    //         playerBlock = p2.damageVal;
    //     }
    //     if (p2.defenseVal > p1.damageVal)
    //     {
    //         enemyBlock = p1.damageVal;
    //     }

    //     if (playerDamageTaken < 0)
    //     {
    //         playerDamageTaken = 0;
    //     }
        
    //     if (enemyDamageTaken < 0)
    //     {
    //         enemyDamageTaken = 0;
    //     }

    //     if (PlayerHP+p1.healVal > player.maxHP)
    //     {
    //         playerHeal = PlayerMaxHP-PlayerHP;
    //     }
    //     if (EnemyHP+p2.healVal > enemy.maxHP)
    //     {
    //         enemyHeal = EnemyMaxHP-EnemyHP;
    //     }

    //     UI.playerDamageDisplay.displayDamage(playerDamageTaken, playerBlock, playerHeal);
    //     UI.enemyDamageDisplay.displayDamage(enemyDamageTaken, enemyBlock, enemyHeal);

    //     PlayerHP -= playerDamageTaken;
    //     EnemyHP -= enemyDamageTaken;
    // }


}
