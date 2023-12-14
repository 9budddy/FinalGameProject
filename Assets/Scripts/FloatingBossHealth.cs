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


    public void UpdateHealthBar(string weapon)
    {
        if (!gameState.bossInvulnerable)
        {
            if (weapon == "sword")
            {
                currentHealth -= 12;
            }
            if (weapon == "bow")
            {
                currentHealth -= 6;
            }
            slider.value = currentHealth / maxHealth;
        }
    }
}
