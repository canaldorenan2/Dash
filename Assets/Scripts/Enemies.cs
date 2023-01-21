using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public GameObject bat;
     GameObject player;

    public float speed = 1.5f;

    public bool follow;
    bool end;

    Animator anim;

    Clock clock;

    PlayerController pc;

    private void Start()
    {
        player = GameObject.Find("Character");
        end = false;
        anim = gameObject.GetComponentInParent<Animator>();
        clock = GameObject.Find("Clock").GetComponent<Clock>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            follow = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player"){
            follow = false;
        }
        
    }

    private void Update()
    {
        if (follow)
        {
            Vector3 direction = player.transform.position - bat.transform.position;
            direction.Normalize();
            bat.transform.Translate(direction * Time.deltaTime * speed);
            
        }

        if (anim.GetBool("die")&& !end)
        {
            Destroy(bat, 1.29f);
            end = true;
        }

        if (clock.day)
        {
            anim.SetBool("die", true);
        }
    }


}
