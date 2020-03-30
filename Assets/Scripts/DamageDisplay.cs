using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text animatedText;
    float waittime = 1.0f;
    void Start()
    {
        //WHY IS THIS HARDCODED FIX THIS

        //should a prefab animated pop-up color coded to the type of display, and not three hardcoded text lines
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void displayDamage(int damaged, int armored, int healed)
    {
        StartCoroutine(ShowDamage(damaged, armored, healed));
    }

    IEnumerator ShowDamage(int damaged, int armored, int healed)
    {
        if (healed > 0)
        {
            Text healText = Instantiate(animatedText);
            healText.transform.SetParent(this.transform.parent);
            healText.transform.position=this.transform.position;
            healText.color = Color.green;
            healText.text = "Healed " + healed;
            yield return new WaitForSeconds(waittime);
        }
        if (armored > 0)
        {
            Text armorText = Instantiate(animatedText);
            armorText.transform.SetParent(this.transform.parent);
            armorText.transform.position=this.transform.position;
            armorText.color = Color.gray;
            armorText.text = "Blocked " + armored;
            yield return new WaitForSeconds(waittime);
        }
        if (damaged > 0)
        {
            Text damageText = Instantiate(animatedText);
            damageText.transform.SetParent(this.transform.parent);
            damageText.transform.position=this.transform.position;
            damageText.color = Color.red;
            damageText.text = "Took " + damaged + " Damage";
            yield return new WaitForSeconds(waittime);
        }
        yield return new WaitForSeconds(waittime);
    }


}
