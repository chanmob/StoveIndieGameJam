using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CloudButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image img;

    public GameObject ghost;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData data)
    {
        if(img.color.a == 1)
            ghost.SetActive(true);
    }

    public void OnPointerExit(PointerEventData data)
    {
        if (img.color.a == 1)
            ghost.SetActive(false);
    }
}
