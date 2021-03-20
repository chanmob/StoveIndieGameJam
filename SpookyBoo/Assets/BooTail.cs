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
    public GameObject testTail;


    private void Start()
    {
        parentTail = gameObject;
    }
    public void CreateTail(Vector3 dir)
    {
        if (n_tail == 0)
            first = true;
        else
            first = false;

        if (first)
            tempDir = dir;
        else
            tempDir = parentTail.GetComponent<tail>().dir;

        Vector3 nextTailPos = new Vector3(tempDir.x>=0 ? -1 : 1 * (padding + parentTail.transform.position.x), tempDir.y>=0 ? -1 : 1 * (padding + parentTail.transform.position.y), 0);
        tail tail = ObjectPoolManager.instance.GetTail();
        tail.transform.position = nextTailPos;
        tail.transform.SetParent(parentTail.transform);
        parentTail = tail.gameObject;
        n_tail++;
    }
}
