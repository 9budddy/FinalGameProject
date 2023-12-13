using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowCollider : MonoBehaviour
{
    private List<string> arrowNames;
    [SerializeField] int hits = 5;
    [SerializeField] GameState gameState;

    public List<string> gNA;
    public List<string> bNA;
    private EnemySpawner enemySpawner;

    private void Start()
    {
        arrowNames = new List<string>();
        GameObject spawner = GameObject.Find("Spawner");
        enemySpawner = spawner.GetComponent<EnemySpawner>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string aname = collision.gameObject.name;
        string tag = collision.gameObject.tag;
        if (tag.Equals("Arrow"))
        {
            if (arrowNames.Count != 0 && arrowNames.Contains(aname))
            {
                // Arrow all ready hit.
            }
            else
            {
                arrowNames.Add(aname);

                //Destroy Enemy
                if (arrowNames.Count == hits)
                {
                    if (name.StartsWith("flying"))
                    {
                        enemySpawner.RemoveBrain(name);
                    }
                    else if (name.StartsWith("ghost"))
                    {
                        enemySpawner.RemoveGhost(name);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }
}
