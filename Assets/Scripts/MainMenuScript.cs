using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    private void Start()
    {
        gameState.selected = 0;
        gameState.bow = false;
        gameState.sword = false;
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
