using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    PlayerController pc;
    private void Start()
    {
        pc = GameObject.Find("Character").GetComponent<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            pc.life -= 1;
            pc.cooldown = 0;
            Debug.Log("In 2");
        }
    }
}
