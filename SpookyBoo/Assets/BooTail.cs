using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BooTail : MonoBehaviour
{
    public int n_tail = 0;
    public GameObject parentTail;
    public float padding = 1;

    public GameObject testTail;


    private void Start()
    {
        parentTail = gameObject;
    }
    public void CreateTail(Vector3 dir)
    {
        Vector3 nextTailPos = new Vector3(dir.x * padding, dir.y * padding, 0);
        // 꼬리 object 꺼내와서
        GameObject tail = testTail;
        tail.transform.position = nextTailPos;
        tail.transform.SetParent(parentTail.transform);
        parentTail = tail;
    }
}
