using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI percent;
    string sceneName;

    private void Awake()
    {
        slider.value = 0;
        sceneName = SceneManager.GetActiveScene().name;

    }

    private float timer = 0.0f;
    private float load = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.03f)
        {
            timer = 0.0f;
            load += 0.02f;
            slider.value = load;
            if ((int)load*100 > 100)
            {
                load = 1;
            }
            percent.text =(int)(load*100) + "%";
        }
        if (load*100 >= 100 && sceneName == "EnterRealm")
        {
            SceneManager.LoadScene("Realm");
        }
        if (load*100 >= 100 && sceneName == "BossSummon")
        {
            SceneManager.LoadScene("BossFight");
        }
    }
}
