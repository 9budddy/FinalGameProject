using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject flyingBrain, ghost;
    [SerializeField] private GameObject player;

    public List<string> bN;
    public List<string> gN;

    void Start()
    {
        gameState.flyingbrains = new Dictionary<string, Vector3>();
        gameState.flyingbrainsName = new List<string>();
        gameState.ghosts = new Dictionary<string, Vector3>();
        gameState.ghostNames = new List<string>();
        if (gameState.bow)
        {
            StartCoroutine(FlyingBrainSpawner(2f, 6f));
            StartCoroutine(GhostSpawner(2f, 6f));
        }
        else if (gameState.sword)
        {
            StartCoroutine(FlyingBrainSpawner(6f, 12f));
            StartCoroutine(GhostSpawner(6f, 12f));
        }
        else
        {
            StartCoroutine(FlyingBrainSpawner(6f, 12f));
            StartCoroutine(GhostSpawner(6f, 12f));
        }

    }

/*    void OnDrawGizmos()
    {
        Gizmos.DrawCube(player.transform.position, new Vector3(32f, 18f));
    }*/

    IEnumerator FlyingBrainSpawner(float a, float b)
    {
        while (true)
        {
            if (gameState.flyingbrainsName.Count < 10)
            {
                GameObject obj = Instantiate(flyingBrain, getRange(), Quaternion.identity);
                string name = "flyingbrain-" + System.Guid.NewGuid().ToString();
                obj.name = name;

                gameState.flyingbrains.Add(obj.name, obj.transform.position);
                gameState.flyingbrainsName.Add(obj.name);
            }

            float waitTime = Random.Range(a, b);
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator GhostSpawner(float a, float b)
    {
        while (true)
        {
            if (gameState.ghostNames.Count < 10)
            {
                GameObject obj = Instantiate(ghost, getRange(), Quaternion.identity);
                string name = "ghost-" + System.Guid.NewGuid().ToString();
                obj.name = name;

                gameState.ghosts.Add(obj.name, obj.transform.position);
                gameState.ghostNames.Add(obj.name);
            }

            float waitTime = Random.Range(a, b);
            yield return new WaitForSeconds(waitTime);
        }
    }

    Vector3 getRange()
    {
        //-20y - 60y
        //-20x -50x
        float x = Random.Range(-20f, 50f);
        float y = Random.Range(-20f, 60f);

        Vector3 pos = player.transform.position;
        float width = 24f;
        float height = 14f;


        while ((x <= pos.x + width &&
            x > pos.x - width) &&
            (y <= pos.y + height &&
            y > pos.y - height))
        {
            x = Random.Range(-20f, 50f);
            y = Random.Range(-20f, 60f);
        }
        return new Vector3(x, y);
    }

    internal void RemoveBrain(string name)
    {
        gameState.flyingbrains.Remove(name);
        gameState.flyingbrainsName.Remove(name);
        AddKilled();
    }

    internal void RemoveGhost(string name)
    {
        gameState.ghosts.Remove(name);
        gameState.ghostNames.Remove(name);
        AddKilled();
    }

    private int killed = 0;
    internal void AddKilled()
    {
        killed++;
        if (killed == 20)
        {
            SceneManager.LoadScene("BossSummon");
        }
    }
}
