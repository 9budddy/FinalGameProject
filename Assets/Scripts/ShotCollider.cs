using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class ShotCollider : MonoBehaviour
{
    [SerializeField] private GameObject brainShot, ghostShot;
    private float brainspeed = 10.0f;
    private float ghostspeed = 6.5f;
    public void shooting(string name, PlayerAwarenessController playerAwarenessController, int state)
    {


        if (name != null && name.StartsWith("flying"))
        {
            if (playerAwarenessController != null)
            {
                Vector3 dTP = playerAwarenessController.DirectionToPlayer;
                GameObject obj;
                GameObject enemy = GameObject.Find(name);

                if (state == 1)
                {
                    //---1
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x + 0.5f, enemy.transform.position.y + 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 45f));
                    string objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(0.5f, 0.5f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x - 0.5f, enemy.transform.position.y + 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 135f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(-0.5f, 0.5f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x - 0.5f, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 225f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(-0.5f, -0.5f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x + 0.5f, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 315f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(0.5f, -0.5f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));
                }



                if (state == 2)
                {
                    //---1
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x + 0.5f, enemy.transform.position.y + 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 22.5f));
                    string objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(0.8f, 0.3f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x - 0.5f, enemy.transform.position.y + 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 112.5f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(-0.3f, 0.8f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x - 0.5f, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 202.5f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(-0.8f, -0.3f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x + 0.5f, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 292.5f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(0.3f, -0.8f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));
                }


                if (state == 3)
                {
                    //---1
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x + 0.5f, enemy.transform.position.y + 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 0f));
                    string objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(1f, 0f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x - 0.5f, enemy.transform.position.y + 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 90f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(0f, 1f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x - 0.5f, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 180f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(-1f, 0f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x + 0.5f, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 270f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(0f, -1f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));
                }


                if (state == 4)
                {
                    //---1
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x + 0.5f, enemy.transform.position.y + 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 337.5f));
                    string objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(.8f, -.3f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x - 0.5f, enemy.transform.position.y + 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 67.5f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(.3f, .8f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x - 0.5f, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 157.5f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(-.8f, .3f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x + 0.5f, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, Quaternion.identity.z + 247.5f));
                    objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector2(-.3f, -.8f) * brainspeed;

                    StartCoroutine(StartDestroy(obj));
                }
            }
        }

        if (name != null && name.StartsWith("ghost"))
        {
            if (playerAwarenessController != null)
            {

                
                Vector3 dTP = playerAwarenessController.DirectionToPlayer;

                //BOTTOM_LEFT
                if (dTP.x > 0.4 && dTP.y < -0.4)
                {
                    GameObject obj;
                    GameObject enemy = GameObject.Find(name);


                    //---1
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0,0,315f));
                    string objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.6f, -0.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2

                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 337.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.8f, -0.3f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 0));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(.9f, 0f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 292.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.3f, -0.8f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---5
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 270f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0f, -.9f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));
                }

                //TOP_RIGHT
                if (dTP.x > 0.4 && dTP.y > 0.4)
                {
                    GameObject obj;
                    GameObject enemy = GameObject.Find(name);


                    //---1
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 45f));
                    string objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.6f, 0.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2

                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 67.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.3f, 0.8f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 90));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0f, .9f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 22.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.8f, 0.3f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---5
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 0f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(.9f, 0f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));
                }

                //TOP_LEFT
                if (dTP.x < -0.4 && dTP.y > 0.4)
                {
                    GameObject obj;
                    GameObject enemy = GameObject.Find(name);


                    //---1
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 135f));
                    string objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.6f, 0.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2

                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 157.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.8f, 0.3f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 180f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-.9f, 0f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 112.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.3f, 0.8f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---5
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 90f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0f, .9f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));
                }

                //BOTTOM_LEFT
                if (dTP.x < -0.4 && dTP.y < -0.4)
                {
                    GameObject obj;
                    GameObject enemy = GameObject.Find(name);


                    //---1
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 225f));
                    string objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.6f, -0.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2

                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 247.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.3f, -0.8f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 270f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0f, -.9f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 202.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.8f, -0.3f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---5
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 180f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-.9f, 0f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));
                }


                //UPWARDS
                else if (dTP.x >= -.4 && dTP.x <= .4 && dTP.y >= .4)
                {
                    GameObject obj;
                    GameObject enemy = GameObject.Find(name);


                    //---1
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 90));
                    string objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0f, .85f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2

                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 112.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.3f, 0.8f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 135f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-.6f, .6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 67.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.3f, 0.8f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---5
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 45f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.6f, 0.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));
                }


                //LEFT
                else if (dTP.x <= -.4 && dTP.y >= -.4 && dTP.y <= .4)
                {
                    GameObject obj;
                    GameObject enemy = GameObject.Find(name);


                    //---1
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 180));
                    string objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-.85f, 0f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2

                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 202.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.8f, -0.3f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 225f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-.6f, -.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 157.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.8f, 0.3f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---5
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 135f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.6f, 0.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));
                }

                //DOWNWARDS
                else if (dTP.x >= -.4 && dTP.x <= .4 && dTP.y <= -.4)
                {
                    GameObject obj;
                    GameObject enemy = GameObject.Find(name);


                    //---1
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 270));
                    string objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0f, -.85f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2

                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 292.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.3f, -0.8f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 315f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(.6f, -.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 247.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.3f, -0.8f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---5
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 225f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(-0.6f, -0.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));
                }

                //RIGHT
                else if (dTP.x >= .4 && dTP.y <= .4 && dTP.y >= -.4)
                {
                    GameObject obj;
                    GameObject enemy = GameObject.Find(name);


                    //---1
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 0));
                    string objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(.85f, 0f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---2

                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 22.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.8f, 0.3f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---3
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 45f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(.6f, .6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---4
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 337.5f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.8f, -0.3f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));


                    //---5
                    obj = Instantiate(ghostShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.Euler(0, 0, 315f));
                    objName = "ghostshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = new Vector3(0.6f, -0.6f) * ghostspeed;

                    StartCoroutine(StartDestroy(obj));
                }
            }
        }
    }

    /* BASIC ENEMIES IF I WANT TO ADD THIS WOULD WORK PERFECTLY
     *         if (name != null && name.StartsWith("flying"))
        {
            if (playerAwarenessController != null)
            {
                Vector3 dTP = playerAwarenessController.DirectionToPlayer;
                if (dTP.x <= 0 && dTP.y <= 0)
                {
                    GameObject obj;
                    GameObject enemy = GameObject.Find(name);
                    obj = Instantiate(brainShot, new Vector3(enemy.transform.position.x, enemy.transform.position.y - 0.5f), Quaternion.identity);
                    string objName = "brainshot-" + System.Guid.NewGuid().ToString();
                    obj.name = objName;

                    Rigidbody2D arb = obj.GetComponent<Rigidbody2D>();
                    arb.velocity = dTP * speed;

                    StartCoroutine(StartDestroy(obj));

                }
            }
        }
     */

    IEnumerator StartDestroy(GameObject obj)
    {
        if (obj.name.StartsWith("ghost"))
        {
            yield return new WaitForSeconds(3.0f);
            Destroy(obj);
        }
        else if (obj.name.StartsWith("brain"))
        {
            yield return new WaitForSeconds(1.5f);
            Destroy(obj);
        }
        else
        {
            yield return new WaitForSeconds(5.0f);
            Destroy(obj);
        }
    }
}
