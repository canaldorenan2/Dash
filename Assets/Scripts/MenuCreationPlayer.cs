using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCreationPlayer : MonoBehaviour
{
    public GameObject nextButtom;
    public GameObject previousButtom;

    public GameObject gameObjectHat;
    public GameObject gameObjectHair;
    public GameObject gameObjectBeard;
    public GameObject gameObjectFace;

    SpriteRenderer hats;
    SpriteRenderer hair;
    SpriteRenderer beard;
    SpriteRenderer face;

    public Sprite[] spritesHat;
    public Sprite[] spritesHair;
    public Sprite[] spritesBeard;
    public Sprite[] spritesFace;

    int count = 0;



    private void Start()
    {
        hats = gameObjectHat.GetComponent<SpriteRenderer>();
        hair = gameObjectHair.GetComponent<SpriteRenderer>();
        beard = gameObjectBeard.GetComponent<SpriteRenderer>();
        face = gameObjectFace.GetComponent<SpriteRenderer>();
    }

    public void Next()
    {
        if (count == spritesHat.Length - 1)
            count = 0;
        else
            count++;

        int buttomFunction = GetButtomFunction();

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

        bName = gameObject.name;

        buttomFunction = (int)char.GetNumericValue(bName[0]);

        return buttomFunction;
    }

    void ChangeSkinCollor(int function)
    {
        switch (function)
        {
            case 0:
                hats.sprite = spritesHat[count];
                break;
            case 1:
                hair.sprite = spritesHair[count];
                break;
            case 2:
                beard.sprite = spritesBeard[count];
                break;
            case 3:
                face.sprite = spritesFace[count];
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

        if (newNumber >= 4)
        {
            newNumber = 0;
        }
        else
        {
            newNumber++;
        }

        nextButtom.name = "" + newNumber + " - Next - Skin";
        previousButtom.name = "" + newNumber + " - Back - Skin";

    }
}
