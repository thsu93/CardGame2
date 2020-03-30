using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboManager : MonoBehaviour
{
    GameManager manager;
    public Character associatedCharacter;

    static int COMBOLENGTH = 3;

    public CardDict comboDict;

    //some sort of dict to check against;
    //if combo is in dict, 


    //check new card against existing two cards for card combo
    //if combo, new combo cardeffect
    //then reset combo 
    //if not, then push+pop

    /*
    public CardEffect comboCheck(Card card)
    {
        check cardname + two prev card names
        if in dict, return matching card effect
        else 
        return card.playEffect;
    }
    */

    private void Start() {
        
        GameObject ManagerHolder = GameObject.Find("GameManager");
        manager = ManagerHolder.GetComponent<GameManager>();
    }

    public void add(Card card)
    {
        card.transform.SetParent(this.transform);
        ExecuteCardAction();
    }

    private void ExecuteCardAction()
    {
        bool isCombo = false;
        Card matchingCombo = null;
        if (this.transform.childCount == COMBOLENGTH)
        {
            string[] comboName = new string[COMBOLENGTH];
            //check if combo
            for (int i = 0; i<COMBOLENGTH; i++)
            {
                comboName[i] = this.transform.GetChild(i).GetComponent<Card>().cardName;
            }
            if (comboDict.isACombo(comboName))
            {
                isCombo = true;
                matchingCombo = comboDict.GetComboCard(comboName);
                for (int i = 0; i<COMBOLENGTH; i++)
                {   
                    associatedCharacter.addToBurn(this.transform.GetChild(i).GetComponent<Card>());
                }
            }
        }
        if (!isCombo)
        {
            Card recentCard = this.transform.GetChild(this.transform.childCount-1).GetComponent<Card>();
            manager.ExecuteTurn(recentCard.playEffect);
        }
        if (this.transform.childCount >=3)
        {
            associatedCharacter.addToGraveyard(this.transform.GetChild(0).GetComponent<Card>());
            //PROBABLY CAN JUST PASS NAME AND NOT OBJECT IN THE FUTURE
            Destroy(this.transform.GetChild(0));
        }
    }
}
