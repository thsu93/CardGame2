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
public class Deck : MonoBehaviour
{
    // //PROG Q: should likely switch to list of cardIDs that are instantiated

    List<string> fullDeck = new List<string>();
    List<string> currentDeck = new List<string>();
    List<string> burned = new List<string>();
    List<string> graveyard = new List<string>();

    private void Start() {
    }

    public void initialize(List<string> cards)
    {
        fullDeck = cards;
        currentDeck.AddRange(fullDeck);
        Shuffle();
    }

    //PROG Q: public? private? 
    /// <summary>
    /// Shuffles cards in deck.
    /// </summary>
    void Shuffle()  
    {
        int n = currentDeck.Count;
        while (n > 1) {  
            n--;  
            int k = Random.Range(0, n + 1);  
            string value = currentDeck[k];  
            currentDeck[k] = currentDeck[n];  
            currentDeck[n] = value;  
        }  
    }

    /// <summary>
    /// Adds cards from graveyard back into deck, then shuffles deck
    /// </summary>
    public void GYReshuffle()
    {
        //Some sort of animation call
        currentDeck.AddRange(graveyard);
        graveyard = new List<string>();
        Shuffle();
    }

    //PROG Q: Should these be using instantiate?

    /// <summary>
    /// Given a card, will add it's card ID to the list of graveyard cards
    /// </summary>
    /// <param name="card"></param>
    public void AddToGraveyard(Card card)
    {
        graveyard.Add(card.cardID);
        Destroy(card.gameObject);
    }


    /// <summary>
    /// Given a card, will add it's card ID to the list of burned cards
    /// </summary>
    /// <param name="card"></param>
    public void AddToBurn(Card card)
    {        
        burned.Add(card.cardID);
        Destroy(card.gameObject);
    }

    /// <summary>
    /// Returns an instantiated copy of the top card in the deck. Will shuffle graveyard in if nothing in deck.
    /// 
    /// Removes that card from current deck.
    /// </summary>
    /// <returns>a copy of the top card in the deck, or null if no cards remaining in both deck and gy</returns>
    public string GenerateNewCard()
    {
        if (currentDeck.Count == 0)
        {
            GYReshuffle();
        }

        //check if post-shuffle count remains 0
        //DESIGN Q: What should game do in this case?
        if (currentDeck.Count == 0)
        {
            return null;
        }


        string temp = currentDeck[0];
        currentDeck.RemoveAt(0);
        return temp;
    }

    public void Reset()
    {
        currentDeck = new List<string>();
        currentDeck.AddRange(fullDeck);
        Shuffle();
        graveyard = new List<string>();
        burned = new List<string>();
    }

    //TODO: Write code to select a card from the decklist given a cardID (controlled draw)

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
