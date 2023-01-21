using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerProject : MonoBehaviour
{
    public static void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
