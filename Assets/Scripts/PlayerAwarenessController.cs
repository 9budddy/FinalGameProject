using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerAwarenessController : MonoBehaviour
{
    public bool AwareOfPlayer { get; private set; }

    public Vector2 DirectionToPlayer { get; private set; }
    public Vector2 enemyToPlayerVector { get; private set; }

    [SerializeField] private float minPlayerAwarenessDistance;
    [SerializeField] private float maxPlayerAwarenessDistance;
    private ShotCollider shotCollider;
    private float timer;
    private int state;

    [SerializeField] private GameState gameState;
    public bool shooting { get; set; }

    private void Start()
    {
        state = 1;
        shooting = false;
        timer = 0.0f;
        shotCollider = GameObject.Find("Player").GetComponent<ShotCollider>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        enemyToPlayerVector = gameState.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;
    }

    void Update()
    {
        

        if (enemyToPlayerVector.magnitude <= maxPlayerAwarenessDistance && enemyToPlayerVector.magnitude > minPlayerAwarenessDistance)
        {
            if (!shooting)
            {
                shooting = true;
                StartCoroutine(StartShooting());
            }
            AwareOfPlayer = true;
        }
        else if (enemyToPlayerVector.magnitude <= maxPlayerAwarenessDistance)
        {
            AwareOfPlayer = false;
            if (!shooting)
            {
                shooting = true;
                StartCoroutine(StartShooting());
            }
        }
        else
        {
            AwareOfPlayer = false;
            if (shooting && timer > 0.3f)
            {
                timer = 0.0f;
                shooting = false;
            }
            else if (shooting && timer <= 0.3f)
            {
                timer += Time.deltaTime;
            }
            shooting = false;
        }
    }



    public IEnumerator StartShooting()
    {
        while (shooting)
        {
            shotCollider.shooting(name, this, state);
            if (name.StartsWith("ghost"))
            {
                yield return new WaitForSeconds(3f);
            }
            else if (name.StartsWith("flying"))
            {
                yield return new WaitForSeconds(0.5f);
                shotCollider.shooting(name, this, state);
                yield return new WaitForSeconds(1.0f);
                state += 1;
                if (state > 4)
                {
                    state = 1;
                }
            }
            else
            {
                yield return new WaitForSeconds(5f);
            }
        }
    }
}
