using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArrowCollider : MonoBehaviour
{
    private List<string> arrowNames;
    [SerializeField] int hits = 5;

    private void Start()
    {
        arrowNames = new List<string>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string name = collision.gameObject.name;
        string tag = collision.gameObject.tag;
        if (tag.Equals("Arrow"))
        {
            if (arrowNames.Count != 0 && arrowNames.Contains(name))
            {
                // Arrow all ready hit.
            }
            else
            {
                arrowNames.Add(name);
                Debug.Log("Hit Enemy");
                //Destroy Enemy
                if (arrowNames.Count == hits)
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
