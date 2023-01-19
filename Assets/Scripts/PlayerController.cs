using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    GameObject camera;
    public float distanceCameraZ;
    public float speed;

    bool mover;

    // Start is called before the first frame update
    void Start()
    {
        mover = false;
    }

    void StartAfter()
    {
        mover = true;

        camera = GameObject.Find("CameraTop");

        if (distanceCameraZ == 0)
        {
            distanceCameraZ = 10;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        if (mover)
        {
            float inputX = Input.GetAxis("Horizontal");
            float inputY = Input.GetAxis("Vertical");

            transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime * speed);
        }
        else
        {
            if (SceneManager.GetActiveScene().name == "MainGame")
            {
                StartAfter();
            }
        }
    }

    private void LateUpdate()
    {
        if (mover)
        {
            camera.transform.position = transform.position + new Vector3(0, 1, -distanceCameraZ);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bounds")
        {

        }
    }
}
