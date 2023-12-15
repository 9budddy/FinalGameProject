using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FloatingBossHealth : MonoBehaviour
{

    [SerializeField] private GameState gameState;
    [SerializeField] private Slider slider;
    float currentHealth = 180;
    float maxHealth = 180;

    private void Start()
    {
        slider.value = currentHealth / maxHealth;
    }


    public void UpdateHealthBar(string weapon)
    {
        if (!gameState.bossInvulnerable)
        {
            if (weapon == "sword")
            {
                currentHealth -= 15;
            }
            if (weapon == "bow")
            {
                currentHealth -= 6;
            }
            slider.value = currentHealth / maxHealth;
        }
    }
}
