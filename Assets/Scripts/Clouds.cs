using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    public float distance = 0;

    public SpriteRenderer clouds;

    // Start is called before the first frame update
    void Start()
    {
        ChangeAlfa();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the clouds
        transform.Translate(new Vector2(Random.Range(0.01f, 0.1f) + distance / 2, 0) * Time.deltaTime);

        // Start again the position of clouds
        if (transform.position.x >= 20)
        {
            this.transform.position.Set(-18, Random.Range(5, 7.1f), 5);
            ChangeAlfa();
        }
    }

    // For change the cloud's alfa
    void ChangeAlfa()
    {
        Material material = clouds.material;
        material.color = new Color(1, 1, 1, Random.Range(0.55f, 1));
    }
}
