using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealth : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI hpText;

    private void Awake()
    {
        slider.value = 1;
    }

    public void UpdateHealthBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
        if (currentValue <= 0)
        {
            currentValue = 0;
        }
        hpText.text = currentValue + "/" + maxValue;
    }

}
