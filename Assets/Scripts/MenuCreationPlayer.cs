using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCreationPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        Debug.Log("Next");
    }

    public void Back()
    {
        Debug.Log("Back");
    }

    public void NextStep()
    {
        Debug.Log("NextStep");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
