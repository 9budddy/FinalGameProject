using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject flyingBrain, ghost;
    [SerializeField] private GameObject player;

    void Start()
    {
        gameState.flyingbrains = new Dictionary<string, Vector3>();
        gameState.ghosts = new Dictionary<string, Vector3>();
        StartCoroutine(FlyingBrainSpawner(8f, 12f));
        StartCoroutine(GhostSpawner(8f, 12f));
    }

/*    void OnDrawGizmos()
    {
        Gizmos.DrawCube(player.transform.position, new Vector3(32f, 18f));
    }*/

    IEnumerator FlyingBrainSpawner(float a, float b)
    {
        while (true)
        {
            if (gameState.flyingbrains.Count <= 10)
            {
                GameObject obj = Instantiate(flyingBrain, getRange(), Quaternion.identity);
                string name = "flyingbrain-" + System.Guid.NewGuid().ToString();
                obj.name = name;

                gameState.flyingbrains.Add(obj.name, obj.transform.position);
            }

            float waitTime = Random.Range(a, b);
            yield return new WaitForSeconds(waitTime);
        }
    }

    IEnumerator GhostSpawner(float a, float b)
    {
        while (true)
        {
            if (gameState.ghosts.Count <= 10)
            {
                GameObject obj = Instantiate(ghost, getRange(), Quaternion.identity);
                string name = "ghost-" + System.Guid.NewGuid().ToString();
                obj.name = name;

                gameState.ghosts.Add(obj.name, obj.transform.position);
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
}
