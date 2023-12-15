using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowBossCollider : MonoBehaviour
{
    private List<string> arrowNames;
    [SerializeField] int hits = 5;
    [SerializeField] GameState gameState;


    private void Start()
    {
        arrowNames = new List<string>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        string aname = collision.gameObject.name;
        string tag = collision.gameObject.tag;
        if (!gameState.bossInvulnerable)
        {
            if (tag.Equals("Arrow"))
            {
                if (arrowNames.Count != 0 && arrowNames.Contains(aname))
                {
                    // Arrow all ready hit.
                }
                else
                {

                    arrowNames.Add(aname);
                    FloatingBossHealth floatingHealth = GetComponentInChildren<FloatingBossHealth>();
                    floatingHealth.UpdateHealthBar("bow");


                    //Destroy Enemy
                    if (arrowNames.Count == hits)
                    {
                        gameState.endGame = true;
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
