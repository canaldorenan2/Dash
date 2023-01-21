using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    public float timer;
    public int hours;

    public GameObject clockDisplay;
    public Image nightDisplay;

    public int secondsToAddHour;

    public bool day;

    private void Start()
    {
        hours = 6;
    }

    private void Update()
    {
        if (timer >= secondsToAddHour)
        {
            hours++;
            clockDisplay.transform.Rotate(0, 0, -15);
            timer = 0;

            if (hours == 24)
            {
                hours = 0;
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
}
