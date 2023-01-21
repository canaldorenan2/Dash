using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowBar : MonoBehaviour
{
    GameObject[] items = new GameObject[9];
    int emp = 0;

    public GameObject letter;

    public Image[] icon;
    public Image defaultImg;

    public int teste = 0;

    bool closedLetter = true;

    PlayerController pc;

    void Start()
    {
        pc = GameObject.Find("Character").GetComponent<PlayerController>();
    }

    public void AddItem(GameObject item, SpriteRenderer spriteRenderer)
    {
        if (emp > 8)
        {
            Debug.Log("Your bag is full");

        }
        else
        {
            items[emp] = item;
            icon[emp].sprite = spriteRenderer.sprite;
            Debug.Log("Item: " + items[emp].name);
            if (item.name == "key")
            {
                pc.key = true;
            }
                
            
            emp++;
        }
    }

    public void RemoveItem(GameObject item)
    {
        for (int i = 0; i <= items.Length; i++)
        {
            if (item.name == items[i].name)
            {
                items[i] = null;
                icon[i] = defaultImg;
                i = items.Length;

            }
        }
    }

    public bool CheckItem(string itemName)
    {
        bool end = false;
        for (int i = 0; i <= items.Length; i++)
        {
            if (itemName == items[i].name)
            {
                end = true;
                i = items.Length;
            }
        }
        return end;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (items[0] != null)
                if (items[0].name == "letter")
                {
                    OpenCloseLetter();
                }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (items[1] != null)
                if (items[1].name == "letter")
                {
                    OpenCloseLetter();
                }
        }
    }

    public void OpenCloseLetter()
    {
        if (closedLetter)
        {
            OpenLetter();
            
        }
        else
        {
            CloseLetter();
            
        }
    }

    void OpenLetter()
    {
        letter.SetActive(true);
        closedLetter = false;
    }

    void CloseLetter()
    {
        letter.SetActive(false);
        closedLetter = true;
    }

    private void OnMouseDown()
    {
        Debug.Log("" + Camera.main.ScreenToWorldPoint(Input.mousePosition));

        if (icon[emp].name == "letter")
        {
            letter.SetActive(true);
        }
    }

    public void InstanciaPlayer(PlayerController inst)
    {
        if (pc == null)
        {
            pc = inst;
        }
    }
}
