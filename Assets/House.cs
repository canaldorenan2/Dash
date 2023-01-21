using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class House : MonoBehaviour
{
    NPCm merc;
    public bool ok = false;

    public GameObject sleep;
    Clock clock;

    PlayerController pc;

    public Image transition;
    bool transitionB;
    float timer;

    float fade;

    // Start is called before the first frame update
    void Start()
    {
        merc = GameObject.Find("NPC - M").GetComponent<NPCm>();
        clock = GameObject.Find("Clock").GetComponent<Clock>();
        // sleep = GameObject.Find("Sleep Dialogue and Buttoms");
        pc = GameObject.Find("Character").GetComponent<PlayerController>();

        transitionB = false;
        timer = 0;


        fade = 0;

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Merc line: " + merc.line);
        Debug.Log("Player key: " + pc.key);
        Debug.Log("Collision name: " + collision.tag);

        if (merc.line > 1 && pc.key)
        {
            ok = true;
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
            //ok = false;
        }
    }

    private void OnMouseDown()
    {
        if (ok)
        {
            sleep.SetActive(true);
        }
    }

    public void Sleep()
    {

        clock.hours = 6;
        clock.dayDate++;
        clock.transform.eulerAngles = new Vector3(0,0,0);
        Transition();
        sleep.SetActive(false);
        Destroy(this.gameObject, 5);

    }

    public void Leave()
    {
        sleep.SetActive(false);
    }

    public void Transition()
    {
        Debug.Log("Transition");
        fade = 0;
    }

    public void InstanciaPlayer(PlayerController inst)
    {
        if (pc == null)
        {
            pc = inst;
        }
    }
}
