using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooTail : MonoBehaviour
{
    public int n_tail = 0;
    public GameObject parentTail, child;
    public float padding = 1;
    public bool first = true;
    Vector3 tempDir;


    private void Start()
    {
    }

    private void Update()
    {
    }
    public void CreateTail(Vector3 dir)
    {
        tail tail = ObjectPoolManager.instance.GetTail();
        if (first)
        {
            child = tail.gameObject;
            tail.parent = gameObject;
            first = false;
            parentTail = tail.gameObject;
            tail.transform.position = gameObject.transform.position + new Vector3(dir.x * padding, dir.y * padding, 0);
        }
        else
        {
            parentTail.GetComponent<tail>().child = tail.gameObject;
            tail.GetComponent<tail>().parent = parentTail;
            tail.transform.position = parentTail.transform.position + new Vector3(-dir.x + padding, -dir.y + padding, 0);
            parentTail = tail.gameObject;
        }
        n_tail++;
    }

    public void DeleteTail()
    {
        GameObject tempGameObject = parentTail.GetComponent<tail>().parent;
        Destroy(parentTail);
//        ObjectPoolManager.instance.ReturnTail(parentTail.GetComponent<tail>());
        parentTail = tempGameObject.gameObject;
    }
}
