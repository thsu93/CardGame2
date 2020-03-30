using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardEffect : MonoBehaviour
{
    public string cardName = "";
    public int damageVal = 0;
    public int defenseVal = 0;
    public int healVal = 0;
    public bool isStatus = false;
    //how to rep status effect?
    public bool isSpecial = false;
    //how to rep special effect?
    public bool isBurnEffect = false;

    private void Start() {
        cardName = this.GetComponent<Card>().cardName;
    }
}
