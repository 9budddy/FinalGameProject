using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RealmStart : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private TextMeshProUGUI text;
    public void StartRealm()
    {
        if (!gameState.bow && !gameState.sword)
        {
            text.enabled = true;
            StartCoroutine(Text());
        }
        else if (gameState.sword)
        {
            SceneManager.LoadScene("Realm");
        }
        else if (gameState.bow)
        {
            SceneManager.LoadScene("Realm");
        }
    }

    IEnumerator Text()
    {
        yield return new WaitForSeconds(4.0f);
        text.enabled = false;
    }
}
