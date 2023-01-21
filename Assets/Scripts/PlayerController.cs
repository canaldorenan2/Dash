using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    GameObject camera1;
    public float distanceCameraZ;
    public float speed;
    TextMeshProUGUI lifeTxt;
    TextMeshProUGUI cashTxt;

    
    Animator anim;

    public float cooldown = 4;

    public int life = 5;
    public int cash = 0;

    public bool key = false;

    public bool playable = false;

    GameObject shop;
    bool notSet;

    public bool receivegold;

    // Start is called before the first frame update
    void Start()
    {
 
        playable = false;
        anim = gameObject.GetComponentInChildren<Animator>();
        notSet = false;
        

    }

    void StartAfter()
    {


        camera1 = GameObject.Find("CameraTop");

        if (distanceCameraZ == 0)
        {
            distanceCameraZ = 10;
        }

        {
            lifeTxt = GameObject.Find("Life-TMP").GetComponent<TextMeshProUGUI>();
            cashTxt = GameObject.Find("Cash-TMP").GetComponent<TextMeshProUGUI>();
        }

        shop = GameObject.Find("Shop");
        shop.SetActive(false);
        notSet = true;
        transform.position = new Vector3(-25, 15, -0.75f);
    }
    
    // Update is called once per frame
    void Update()
    {
        if (playable)
        {
            Movement();
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "MainGame" && notSet == false)
            {
                
                StartAfter();
            }
        }

        // reset cooldown to take a hit
        if (cooldown < 4)
        {
            cooldown = Time.deltaTime;
        }

        if (SceneManager.GetActiveScene().name == "MainGame")
        {
            if (shop.active)
            {
                playable = false;
            }
            else
            {
                playable = true;
            }
        }

        
    }

    private void LateUpdate()
    {


        if (playable)
        {
            //
            {
                camera1.transform.position = transform.position + new Vector3(0, 1, -distanceCameraZ);
            }

            lifeTxt.text = life + "/5";
            cashTxt.text = "$ " + cash;

            if (life <= 0)
            {
                SceneManagerProject.GameOver();
            }
        }

    }



    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime * speed);

        if (inputX != 0 || inputY != 0)
        {
            anim.SetBool("walk", true);
            if (inputX > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            if (inputX < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

        }
        else
        {
            anim.SetBool("walk", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*
        if (cooldown >= 4 && other.tag == "Enemy")
        {
            life -= 1;
            cooldown = 0;
        }
        */
        if (other.tag == "Collectable")
        {
            //LowBar.AddItem(other.gameObject);
            Destroy(other.gameObject, 0.25f);
            
        }
    }
}
