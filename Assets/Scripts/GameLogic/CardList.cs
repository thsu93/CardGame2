using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardList : MonoBehaviour
{
    Dropdown dropdown;
    List<Dropdown.OptionData> cardNames = new List<Dropdown.OptionData>();
    
    // Start is called before the first frame update
    void Start()
    {
        dropdown = this.GetComponent<Dropdown>();
    }

    public void updateList(List<Card> cards)
    {
        foreach (Card card in cards)
        {
            Dropdown.OptionData message = new Dropdown.OptionData();
            message.text = card.cardName;
            cardNames.Add(message);
        }
        dropdown.options = cardNames;
    }
}
