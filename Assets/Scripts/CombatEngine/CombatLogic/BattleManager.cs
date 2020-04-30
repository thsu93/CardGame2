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
public class BattleManager : ScriptableObject
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

        //TODO: Change to an actual UI
        Debug.Log(caster.charName + " played " + casterEffect.cardName + ", dealing " + damage + " damage and healing  " + cardHeal);
        
        caster.changeHP(-cardHeal);
        target.changeHP(damage);
    }
}