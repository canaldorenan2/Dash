using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuCreationPlayer : MonoBehaviour
{
    public GameObject nextButtom;
    public GameObject previousButtom;

     GameObject gameObjectHat;
     GameObject gameObjectHair;
     GameObject gameObjectBeard;
     GameObject gameObjectFace;

    SpriteRenderer hats;
    SpriteRenderer hair;
    SpriteRenderer beard;
    SpriteRenderer face;

    public Sprite[] spritesHat;
     int[] priceHat;

    public Sprite[] spritesHair;
     int[] priceHair;

    public Sprite[] spritesBeard;
     int[] priceBeard;

    public Sprite[] spritesFace;
     int[] priceFace;

    public Text priceTxt;

    int count = 0;

    public Text txtBtn;

    private void Start()
    {
        gameObjectHat = GameObject.Find("Hat");
        gameObjectHair = GameObject.Find("Hair");
        gameObjectBeard = GameObject.Find("Beard");
        gameObjectFace = GameObject.Find("Face");


        hats = gameObjectHat.GetComponent<SpriteRenderer>();
        hair = gameObjectHair.GetComponent<SpriteRenderer>();
        beard = gameObjectBeard.GetComponent<SpriteRenderer>();
        face = gameObjectFace.GetComponent<SpriteRenderer>();

        Price();
    }

    public void Next()
    {
        if (count == spritesHat.Length - 1)
            count = 0;
        else
            count++;

        Debug.Log("Next Chamado");

        int buttomFunction = GetButtomFunction();

        Debug.Log("Function obtained: " + buttomFunction);

        ChangeSkinCollor(buttomFunction);
    }

    public void Back()
    {
        if (count == 0)
            count = spritesHat.Length - 1;
        else
            count--;

        int buttomFunction = GetButtomFunction();

        ChangeSkinCollor(buttomFunction);
    }

    public void NextStep()
    {
        SceneManager.LoadScene("MainGame"); ;
    }

    public void Exit()
    {
        if (SceneManager.GetActiveScene().name == "PlayerCreation")
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene("MainGame");
        }


    }

    int GetButtomFunction()
    {
        string bName;
        int buttomFunction = 0;

        bName = nextButtom.name;

        buttomFunction = (int)char.GetNumericValue(bName[0]);

        return buttomFunction;
    }

    void ChangeSkinCollor(int function)
    {
        switch (function)
        {
            case 0:
                hats.sprite = spritesHat[count];
                priceTxt.text = "$ " + priceHat[count];
                break;
            case 1:
                hair.sprite = spritesHair[count];
                priceTxt.text = "$ " + priceHair[count];
                break;
            case 2:
                beard.sprite = spritesBeard[count];
                priceTxt.text = "$ " + priceBeard[count];
                break;
            case 3:
                face.sprite = spritesFace[count];
                priceTxt.text = "$ " + priceFace[count];
                break;

            default:
                //
                break;

        }

    }

    public void ChangeButtomFunction()
    {
        // 0 - Change Hat, 1 - Change Hair, 2 - Change Beard, 3 - Change Face

        int newNumber = 0;

        newNumber = (int)char.GetNumericValue(nextButtom.name[0]);

        if (newNumber >= 3)
        {
            newNumber = 0;
        }
        else
        {
            newNumber++;
        }

        nextButtom.name = "" + newNumber + " - Next - Skin";
        previousButtom.name = "" + newNumber + " - Back - Skin";

        switch (newNumber)
        {
            case 0:
                txtBtn.text = "HAT";
                break;
            case 1:
                txtBtn.text = "HAIR";
                break;
            case 2:
                txtBtn.text = "BEARD";
                break;
            case 3:
                txtBtn.text = "FACE";
                break;
        }

    }

    public void Price()
    {

        for (int i = 0; i <= spritesHat.Length; i++)
        {
            priceHat[i] = 50 + i + Random.Range(0,10);
        }

        for (int i = 0; i <= spritesHair.Length; i++)
        {
            priceHair[i] = 60 + i + Random.Range(0, 10);
        }

        for (int i = 0; i <= spritesFace.Length; i++)
        {
            priceFace[i] = 80 + i + Random.Range(0, 10);
        }

        for (int i = 0; i <= spritesBeard.Length; i++)
        {
            priceBeard[i] = 10 + i + Random.Range(0, 10);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameObject.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            gameObject.SetActive(false); ;
        }

    }
}
