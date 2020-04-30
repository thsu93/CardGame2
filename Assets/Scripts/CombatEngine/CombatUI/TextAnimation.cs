using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    Animator animator;
    float timer = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = this.transform.GetComponent<Animator>();

        StartCoroutine(DoAnimation());
    }

    IEnumerator DoAnimation()
    {
        yield return new WaitForSeconds(timer);
        Destroy(this.gameObject);
    }
}
