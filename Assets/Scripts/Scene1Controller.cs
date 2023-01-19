using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1Controller : MonoBehaviour
{
    public GameObject intro;
    public GameObject playerCreation;
    public GameObject player;

    public GameObject dash;
    public GameObject enter;

    float count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;

        dash.SetActive(false);
        enter.SetActive(false);
        playerCreation.SetActive(false);
        intro.SetActive(true);
        player.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;


        if (count >= 3)
        {
            dash.SetActive(true);

            if (count >= 6)
            {
                enter.SetActive(true);
            }

        }

        if ((Input.GetKeyDown(KeyCode.KeypadEnter) || (Input.GetKeyDown(KeyCode.Return))) && (count >= 6))
        {
            playerCreation.SetActive(true);
            intro.SetActive(false);
            player.SetActive(true);
        }

    }
}
