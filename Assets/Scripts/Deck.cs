using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public List<Card> fullDeck;
    public List<Card> currentDeck;
    public List<Card> burnList;
    public List<Card> playList;
    public List<Equipment> equips;
    int level;
    public int maxHP;
    public string charName;

    public void setDeck(List<Card> cards)
    {
        fullDeck = cards;
    }

    public Card GenerateNewCard()
    {
        int cardNumber = Random.Range(0, currentDeck.Count);
        Card NewCard = Instantiate(currentDeck[cardNumber]);
        currentDeck.RemoveAt(cardNumber);
        return NewCard;
    }

}
