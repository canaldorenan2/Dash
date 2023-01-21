using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCm : MonoBehaviour
{
    public bool wait;
    public bool isTalking;
    public float timer = 0;

    public float aux = 0;
    int aux2 = -1;
    public float speed = 2.5f;

    Animator anim;

    bool ok;

    public GameObject[] dialogue;
    public int line = 0;

    Clock clock;

    GameObject displayCharacter;

    GameObject marketShop;

    PlayerController pc;
    void Start()
    {
        isTalking = false;
        wait = true;
        aux = 5;

        anim = gameObject.GetComponentInChildren<Animator>();
        clock = GameObject.Find("Clock").GetComponent<Clock>();
        marketShop = GameObject.Find("MarketShop");
        
    }

    private void Awake()
    {
        pc = GameObject.Find("Character").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!isTalking)
        {
            if (wait)
            {
                if (timer <= 6)
                {
                    timer += Time.deltaTime;

                }
                else
                {
                    wait = false;
                    aux = aux * -1;
                    anim.SetBool("walk", true);
                }
            }
            else
            {
                Move();

                if (timer <= 0)
                {
                    timer = 0;
                    wait = true;
                    anim.SetBool("walk", false);
                    transform.localScale = new Vector3(aux2, 1, 1);
                    aux2 = aux2 * -1;
                }
                timer -= Time.deltaTime;
            }
        }

        if (clock.dayDate > 1 && pc.key)
        {
            displayCharacter.SetActive(false);
            isTalking = true;
            marketShop.SetActive(true);
        }
    }


    public void Move()
    {
        transform.Translate(aux * Time.deltaTime * speed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            isTalking = true;
            anim.SetBool("walk", false);
        }
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

        if (collision.transform.tag == "Player")
        {
            isTalking = false;
        }

        Deactivate();
    }

    private void OnMouseDown()
    {
        if (ok)
        {
            Dialogue();
        }
    }

    public void Dialogue()
    {
        Deactivate();

        if (pc.key && line <2)
        {
            line++;
        }
        
        if (dialogue[line].active)
        {
            Deactivate();
        }
        else
        {
            Active();
        }

    }

    void Active()
    {
        isTalking = true;
        dialogue[line].SetActive(true);
    }

    public void Deactivate()
    {
        isTalking = false;
        dialogue[line].SetActive(false);
    }

    public void InstanciaPlayer(PlayerController inst)
    {
        if (pc == null)
        {
            pc = inst;
        }
    }
}
