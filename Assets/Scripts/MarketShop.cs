using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class MarketShop : MonoBehaviour
{
    public bool ok = false;

    Clock clock;
    PlayerController pc;

    public GameObject shop;
    public GameObject scene;

    public GameObject btnVisual, btnSell, btnGift, btnLeave;

    [Header("Menu")]
    public GameObject visual;
    public GameObject sell;
    public GameObject gift;

    [Header("Gift")]
    public GameObject animalPlace;

    int[] item = new int[2];

    public TextMeshProUGUI sell0, sell1, priceTxt;

    private void Start()
    {
        //animalPlace.SetActive(false);
        clock = GameObject.Find("Clock").GetComponent<Clock>();
        //pc = GameObject.Find("Character").GetComponent<PlayerController>();

        item[0] = 1;
        item[1] = 1;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(pc.key && clock.dayDate > 0)
        {
            if (collision.tag == "Player" || collision.tag == "Interactable")
            {
                ok = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Interactable")
        {
            ok = false;
        }
    }

    private void OnMouseDown()
    {
        if (ok)
        {
            shop.SetActive(true);
            scene.SetActive(false);
            EnableBtns();
        }
    }

    public void EnableBtns()
    {
        btnVisual.SetActive(true);
        btnSell.SetActive(true); 
        btnGift.SetActive(true); 
        btnLeave.SetActive(true);
    }

    public void DisableBtns()
    {
        btnVisual.SetActive(false);
        btnSell.SetActive(false);
        btnGift.SetActive(false);
        btnLeave.SetActive(false);
    }

    public void Visual()
    {
        //code
        visual.SetActive(true);
        DisableBtns();
    }

    public void VisualOff()
    {
        visual.SetActive(false);
        EnableBtns();
    }

    public void VisualBuy()
    {
        int price;
        int.TryParse(priceTxt.text, out price);
        pc.cash -= price;
        LeaveShop();
    }

    public void Sell()
    {
        //code
        sell.SetActive(true);
        DisableBtns();
    }
    public void SellOff()
    {
        //code
        sell.SetActive(false);
        EnableBtns();
    }

    public void Gift()
    {
        //code
        gift.SetActive(true);
        DisableBtns();
    }

    public void EndGift()
    {
        animalPlace.SetActive(true);
        pc.receivegold = true;
        LeaveShop();
    }

    public void LeaveShop()
    {
        shop.SetActive(false);
        scene.SetActive(true);
        DisableBtns();
    }

    public void SellKey0()
    {
        if (item[0] == 1)
        {
            pc.cash += 100;
            item[0] = 0;
            sell0.text = "done";
        }
    }

    public void SellLetter1()
    {
        if (item[1] == 1)
        {
            pc.cash += 15;
            item[1] = 0;
            sell1.text = "done";
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
