using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooTail : MonoBehaviour
{
    public int n_tail = 0;
    public GameObject parentTail;
    public float padding = 1;
    bool first = true;
    Vector3 tempDir;


    private void Start()
    {
        parentTail = gameObject;
    }

    private void Update()
    {
        if (transform.parent != null)
        {
            tempDir = transform.parent.position - transform.position;
            tempDir.Normalize();
        }
    }
    public void CreateTail(Vector3 dir)
    {
        Vector3 nextTailPos = new Vector3(0, 0, 0);
        GameObject tail;

        if (n_tail == 0)
            first = true;
        else
            first = false;


        tail = ObjectPoolManager.instance.GetTail();
        tail.transform.SetParent(parentTail.transform);

        if (first)
            tempDir = dir;
        else {
            tempDir = parentTail.transform.GetComponent<tail>().dir;
        }
        nextTailPos = new Vector3(tempDir.x >= 0 ? -1 : 1 * (padding + parentTail.transform.position.x), tempDir.y >= 0 ? -1 : 1 * (padding + parentTail.transform.position.y), 0);
        tail.transform.position = new Vector3(nextTailPos.x, nextTailPos.y, nextTailPos.z);
        parentTail = tail;
        if (tail.transform.position == new Vector3(nextTailPos.x, nextTailPos.y, nextTailPos.z))
            tail.GetComponent<tail>().arrive = true;
        n_tail++;
    }
}
