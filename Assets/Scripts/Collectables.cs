using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
     LowBar lowBar;
    SpriteRenderer spriteRenderer;
    public bool ok;


    private void Start()
    {
        lowBar = GameObject.Find("LowBar").GetComponent<LowBar>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            ok = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Interactable")
        {
            ok = false;
        }
    }

    private void OnMouseDown()
    {
        if (ok)
        {
            Debug.Log("Lv2");
            lowBar.AddItem(this.gameObject, spriteRenderer);
            gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}
