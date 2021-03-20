using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class moveCharacter : MonoBehaviour
{
    
    public float moveSpeed = 0.5f;
    new Vector3 dir, m_scale;
    public Camera mainCamera;
    
    void Update()
    {
        moveUpdate();
        m_scale = gameObject.transform.localScale;
        if (dir.x <= 0)
        {
            gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0);
        }
        if (dir.x >= 0)
        {
            gameObject.transform.localScale = new Vector3(-0.5f, 0.5f, 0);
        }
    }

    void moveUpdate()
    {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePos);
        dir = mousePos - gameObject.transform.position.normalized;
        gameObject.transform.Translate(new Vector3(dir.x, dir.y, 0) * moveSpeed * Time.deltaTime);

    }
}

