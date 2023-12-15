using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{

    private float timer = 0.0f;
    private float load = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.03f)
        {
            timer = 0.0f;
            load += 0.02f;
        }
        if (load*100 >= 300)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
