using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hoverable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 scaleSize = new Vector3(.5f,.5f,0);    
    private Vector3 initScale; 
    private Vector3 magScale;

    private float HOVER_TIME = .5f;
    private float timer = 0.0f;
    private bool hovering;
    public bool active;
    private GameObject hoverImage;

    // Start is called before the first frame update
    void Start()
    {
        initScale = this.transform.localScale;
        magScale = this.transform.localScale + scaleSize;
        hovering = false;
        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hovering && active)
        {
            timer += Time.deltaTime;
            if (timer>HOVER_TIME)
            {
                this.transform.localScale = magScale;
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData){
        Debug.Log("entered");
        hovering = true;
    }
    public void OnPointerExit(PointerEventData eventData) {
        Debug.Log("exited");
        hovering = false;
        timer = 0.0f;
        this.transform.localScale = initScale;
    }
    
}
