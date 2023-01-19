using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCm : MonoBehaviour
{
    public bool wait;
    public bool isTalking;
    public float timer = 0;

    public float aux = 0;
    public float speed = 2.5f;

    Animator anim;

    void Start()
    {
        isTalking = false;
        wait = true;
        aux = 5;

        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
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
            if (!isTalking)
                Move();

            if (timer <= 0)
            {
                timer = 0;
                wait = true;
                anim.SetBool("walk", false);
            }
            timer -= Time.deltaTime;
        }
    }

    public void Move()
    {
        
        transform.Translate(aux * Time.deltaTime * speed, 0, 0);
    }


}
