using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    GameObject camera;
    public float varZ;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("CameraTop");

        if (varZ == 0)
        {
            varZ = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        transform.Translate(new Vector2(inputX, inputY) * Time.deltaTime);
    }

    private void LateUpdate()
    {
        camera.transform.position = transform.position + new Vector3(0, 1, -varZ);
    }
}
