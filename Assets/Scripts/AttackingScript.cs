using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingScript : MonoBehaviour
{
    [SerializeField] GameState gameState;
    [SerializeField] GameObject arrow;

    private bool arrowSpawned = false;
    private bool swordSwing = false;
    private float speed = 10f;
    private int counter = 0;

    private List<GameObject> arrows;

    private Animator animator;

    //TESTING
    [SerializeField] GameObject enemy;

    void Start()
    {
        arrows = new List<GameObject>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        if (gameState.attack)
        {
            if (gameState.bow && !arrowSpawned) 
            {
                arrowSpawned = true;
                StartCoroutine(SpawnArrow());
            }

            else if (gameState.sword && !swordSwing)
            {
                swordSwing = true;
                StartCoroutine(SwordAttack());
            }
        }
    }

    IEnumerator SwordAttack()
    {
        while (swordSwing)
        {
            yield return new WaitForSeconds(0.6f);
            Vector3 pos = transform.position;
            /*foreach (string name in gameState.enemies.Keys) {
                GameObject obj = GameObject.Find(name);
                if (Vector3.Distance(obj.transform.position, pos) <= 2.5f)
                {

                }
            }*/

            //---TESTING
            Vector3 enemyPos = enemy.transform.position;
            if (Vector3.Distance(enemyPos, pos) <= 3.5f)
            {
                int state = animator.GetInteger("state");
                if (state == 0)
                {
                    if (transform.localScale.x == -1)
                    {
                        if (enemyPos.x >= pos.x)
                        {
                            Debug.Log("Hit Right");
                        }
                    }
                    else
                    {
                        if (enemyPos.x <= pos.x)
                        {
                            Debug.Log("Hit Left");
                        }
                    }
                }
                else if (state == 1)
                {
                    if (enemyPos.y >= pos.y)
                    {
                        Debug.Log("Hit Up");
                    }
                }
                else if (state == 2)
                {
                    if (enemyPos.y <= pos.y)
                    {
                        Debug.Log("Hit Down");
                    }
                }
            }
            yield return new WaitForSeconds(0.6f);
            swordSwing = false;
        }
    }

    IEnumerator SpawnArrow()
    {
        while (arrowSpawned)
        {
            int state = animator.GetInteger("state");
            if (state == 0)
            {
                if (transform.localScale.x == -1)
                {
                    GameObject nA;
                    nA = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
                    string name = "arrow-" + System.Guid.NewGuid().ToString();
                    nA.name = name;
                    
                    Rigidbody2D nARB = nA.GetComponent<Rigidbody2D>();
                    nARB.velocity = new Vector3(1, 0) * speed;

                    StartCoroutine(StartDestroy(nA));
                    yield return new WaitForSeconds(0.55f);
                    counter += 1;
                    if (counter == 2)
                    {
                        counter = 0;
                        arrowSpawned = false;
                    }
                }
                else
                {
                    GameObject nA;
                    nA = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y - 0.5f), Quaternion.Euler(0, 0, 180));
                    string name = "arrow-" + System.Guid.NewGuid().ToString();
                    nA.name = name;

                    Rigidbody2D nARB = nA.GetComponent<Rigidbody2D>();
                    nARB.velocity = new Vector3(-1, 0) * speed;
                    
                    StartCoroutine(StartDestroy(nA));
                    yield return new WaitForSeconds(0.55f);
                    counter += 1;
                    if (counter == 2)
                    {
                        counter = 0;
                        arrowSpawned = false;
                    }
                }
            }
            else if (state == 1)
            {
                GameObject nA;
                nA = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y + 0.5f), Quaternion.Euler(0, 0, 90));
                string name = "arrow-" + System.Guid.NewGuid().ToString();
                nA.name = name;

                Rigidbody2D nARB = nA.GetComponent<Rigidbody2D>();
                nARB.velocity = new Vector3(0, 1) * speed;
                
                StartCoroutine(StartDestroy(nA));
                yield return new WaitForSeconds(0.55f);
                counter += 1;
                if (counter == 2)
                {
                    counter = 0;
                    arrowSpawned = false;
                }

            }
            else if (state == 2)
            {
                GameObject nA;
                nA = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y - 0.8f), Quaternion.Euler(0, 0, 270));
                string name = "arrow-" + System.Guid.NewGuid().ToString();
                nA.name = name;

                Rigidbody2D nARB = nA.GetComponent<Rigidbody2D>();
                nARB.velocity = new Vector3(0, -1) * speed;
                
                StartCoroutine(StartDestroy(nA));
                yield return new WaitForSeconds(0.55f);
                counter += 1;
                if (counter == 2)
                {
                    counter = 0;
                    arrowSpawned = false;
                }
            }
            else
            {
                yield return new WaitForSeconds(1.2f);
                arrowSpawned = false;
            }
        }
    }

    IEnumerator StartDestroy(GameObject nA) {
        
        yield return new WaitForSeconds(1.5f);
        if (nA != null)
        {
            arrows.Remove(nA);
            Destroy(nA);
        }
    }
}
