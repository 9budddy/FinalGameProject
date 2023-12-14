using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FloatingHealth2 : MonoBehaviour
{


    [SerializeField] private Slider slider;
    float currentHealth;
    float maxHealth;
    private bool set = false;

    private void Update()
    {
        if (!set)
        {
            if (gameObject.name.StartsWith("flying"))
            {
                set = true;
                currentHealth = 40f;
                maxHealth = 40f;
            }
            if (gameObject.name.StartsWith("ghost"))
            {
                set = true;
                currentHealth = 18f;
                maxHealth = 18f;
            }
        }
    }

    public void UpdateHealthBar(string weapon, string type)
    {
        if (weapon == "sword")
        {
            if (type == "brain")
            {
                currentHealth -= 10;
            }
            else if (type == "ghost")
            {
                currentHealth -= 6;
            }
        }
        if (weapon == "bow")
        {
            if (type == "brain")
            {
                currentHealth -= 5;
            }
            else if (type == "ghost")
            {
                currentHealth -= 3;
            }
        }
        slider.value = currentHealth / maxHealth;
    }
}
