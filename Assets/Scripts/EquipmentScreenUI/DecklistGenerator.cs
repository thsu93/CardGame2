using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script to create a dynamically sized panel comprised of all currently equipped cards 
/// 
/// Resizing done by content size fitter pivoted around upper right corner of panel
/// </summary>
public class DecklistGenerator : MonoBehaviour
{
    public List<Equipment> equips;
    List<Card> decklist = new List<Card>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Equipment equip in equips)
        {
            decklist.AddRange(equip.AssociatedCards);
        }

        foreach (Card card in decklist)
        {
            Card tempCard = Instantiate(card);
            tempCard.transform.SetParent(this.transform);
        }
        
        //need to add some sort of markers to find for snap-to, highlight
    }

//     //TODO: Found this code on forums, use for reference later when trying to snap to elemments
//     protected ScrollRect scrollRect;
// protected RectTransform contentPanel;

// public void SnapTo(RectTransform target)
//     {
//         Canvas.ForceUpdateCanvases();

//         contentPanel.anchoredPosition =
//             (Vector2)scrollRect.transform.InverseTransformPoint(contentPanel.position)
//             - (Vector2)scrollRect.transform.InverseTransformPoint(target.position);
//     }
}
