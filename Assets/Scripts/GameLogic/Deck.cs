using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles a deck once given a decklist
/// 
/// Holds current and full decklist
/// 
/// Can re-shuffle, handle Graveyard and Burn lists, and add GY to current deck
/// 
/// </summary>
/// 
/// 
/// TODO: THIS IS NOT HOW INSTANTIATE WORKS
public class Deck : MonoBehaviour
{
    //PROG Q: should likely switch to list of cardIDs that are instantiated
    List<Card> fullDeck = new List<Card>();
    List<Card> currentDeck = new List<Card>();
    List<Card> burned = new List<Card>();
    List<Card> graveyard = new List<Card>();

    //TODO: Needs implementation of cardloader;
    CardLoader loader;

    private void Start() {
        loader = ScriptableObject.CreateInstance<CardLoader>();
    }

    public void initialize(List<Card> cards)
    {
        fullDeck = cards;
        currentDeck.AddRange(fullDeck);
    }

    //PROG Q: public? private? 
    /// <summary>
    /// Shuffles cards in deck.
    /// </summary>
    public void Shuffle()
    {
        List<Card> tempDeck = new List<Card>();
        while (currentDeck.Count>=0)
        {
            int cardNumber = Random.Range(0, currentDeck.Count);
            tempDeck.Add(currentDeck[cardNumber]);
            currentDeck.RemoveAt(cardNumber);
        }
        currentDeck = tempDeck;
    }

    /// <summary>
    /// Adds cards from graveyard back into deck, then shuffles deck
    /// </summary>
    public void GYReshuffle()
    {
        //Some sort of animation call
        currentDeck.AddRange(graveyard);
        graveyard = new List<Card>();
        Shuffle();
    }

    //PROG Q: Should these be using instantiate?
    public void AddToGraveyard(Card card)
    {
        graveyard.Add(Instantiate(card));
        Destroy(card.gameObject);
    }

    public void AddToBurn(Card card)
    {        
        burned.Add(Instantiate(card));
        Destroy(card.gameObject);
    }

    /// <summary>
    /// Returns an instantiated copy of the top card in the deck.
    /// 
    /// Removes that card from current deck.
    /// </summary>
    /// <returns>a copy of the top card in the deck, or null if no cards remaining</returns>
    public Card GenerateNewCard()
    {
        if (currentDeck.Count == 0)
        {
            GYReshuffle();
        }
        //check if post-shuffle count remains 0
        if (currentDeck.Count == 0)
        {
            return null;
        }
        Card temp = Instantiate(currentDeck[0]);
        currentDeck.RemoveAt(0);
        return temp;
    }

    //TODO: Write code to find a card given a cardID

    // /// <summary>
    // /// Finds a card in the decklist given a cardID, returns a copy of it, and removes it from the current decklist
    // /// </summary>
    // /// <param name="targetID">cardID of the desired card</param>
    // /// <returns>A card of type </returns>
    // public Card findCard(string targetID)
    // {
    //      auto-shuffle?
    //      return card;
    // }

    //TODO: Write code to add a card to the deck, given a cardID
}
