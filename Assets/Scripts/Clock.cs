using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clock : MonoBehaviour
{
    public float timer;
    public int hours;

    public GameObject clockDisplay;
    public Image nightDisplay;

    public int secondsToAddHour;

    public bool day;
    public int dayDate;

    public TextMeshProUGUI dayNumber;

    PlayerController pc;

    private void Start()
    {
        hours = 6;
        dayDate = 0;
        pc = GameObject.Find("Character").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (timer >= secondsToAddHour)
        {
            hours++;
            clockDisplay.transform.Rotate(0, 0, -15);
            timer = 0;

            if (pc.receivegold)
            {
                pc.cash += 5;
            }

            if (hours == 24)
            {
                hours = 0;
                dayDate++;
            }
        }
        timer += Time.deltaTime;

        if (hours == 6 || hours == 18)
        {
            nightDisplay.color = new Color(0,0,0, 0.15f);
            day = false;
        }
        else
        {
            day = true;
        }

        if (hours == 19 || hours == 5)
        {
            nightDisplay.color = new Color(0, 0, 0, 0.25f);
        }

        if (hours == 20 || hours == 4)
        {
            nightDisplay.color = new Color(0, 0, 0, 0.55f);
        }

        if (hours == 7)
        {
            nightDisplay.color = new Color(0, 0, 0, 0.0f);
        }
    }
    private void LateUpdate()
    {
        int numberdisplay = dayDate + 1;
        dayNumber.text = numberdisplay.ToString();
    }

    public void InstanciaPlayer(PlayerController inst)
    {
        if (pc == null)
        {
            pc = inst;
        }
    }
}
