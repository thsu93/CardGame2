using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public List<Equipment> equips;
    public List<Card> fullDeck;
    public List<Card> currentDeck;
    public List<Card> graveyard;
    public List<Card> burned;

    //CURRENTLY A WORKAROUND WHILE THINKING ABOUT BETTER IMPLEMENTATION
    //PROB WOULD WORK WITH JUST NAMES IF DATABASED????
    public List<Card> inPlay;

    int level;
    public int maxHP;
    public string charName;

    private void Awake() {
        List<Card> fullDeck = new List<Card>();
        foreach (Equipment equip in equips)
        {
            foreach (Card tempCard in equip.AssociatedCards)
            {
                fullDeck.Add(tempCard);
            }
        }
        currentDeck = fullDeck;
        burned = new List<Card>();
        graveyard = new List<Card>();
        inPlay = new List<Card>();
    }

    public Card GenerateNewCard()
    {
        if (currentDeck.Count == 0)
        {
            currentDeck = graveyard;
            //DO SOME ANIMATION TO INDICATE THIS HAPPENED ON THE SCREEN
            graveyard = new List<Card>();
        }
        int cardNumber = Random.Range(0, currentDeck.Count);
        Card NewCard = currentDeck[cardNumber];
        inPlay.Add(NewCard);
        currentDeck.RemoveAt(cardNumber);
        return NewCard;
    }

    public void addToGraveyard(Card card)
    {
        //JURY RIGGED SOLUTION, REQUIRES FIXING LATER
        for (int i = 0; i<inPlay.Count; i++)
        {
            Card comp = inPlay[i];
            if (comp.cardName == card.cardName)
            {
                graveyard.Add(comp);
                inPlay.Remove(comp);
                break;
            }
        }
        Destroy(card.gameObject);
    }

    public void addToBurn(Card card)
    {        
        //JURY RIGGED SOLUTION, REQUIRES FIXING LATER
        for (int i = 0; i<inPlay.Count; i++)
        {
            Card comp = inPlay[i];
            if (comp.cardName == card.cardName)
            {
                burned.Add(comp);
                inPlay.Remove(comp);
                break;
            }
        }
        Destroy(card.gameObject);
    }
}