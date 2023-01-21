using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z <= -5.45f || speed <=0)
        {
            transform.Translate(0, 0, 1 * Time.deltaTime * speed);
            speed -= 0.000021f;
        }
    }
}
