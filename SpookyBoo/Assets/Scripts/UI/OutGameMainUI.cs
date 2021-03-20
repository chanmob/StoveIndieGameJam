using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutGameMainUI : MonoBehaviour
{
    public Image fadeImage;

    public GameObject titleLogo;

    public Button[] cloudBtns;
    public CanvasGroup[] cloudCanvasGroup;

    private void Start()
    {
        StartCoroutine(FadeCoroutine());
    }

    private IEnumerator FadeCoroutine()
    {
        fadeImage.gameObject.SetActive(true);

        float time = 0f;
        Color alpha = fadeImage.color;

        alpha.a = 1;
        while (alpha.a > 0)
        {
            time += Time.deltaTime / 1f;
            alpha.a = Mathf.Lerp(1, 0, time);
            fadeImage.color = alpha;
            yield return null;
        }

        fadeImage.gameObject.SetActive(false);
        titleLogo.SetActive(true);
    }

    public void CloudBtnOn()
    {
        StartCoroutine(CloudBtnOnCoroutine());
    }

    public IEnumerator CloudBtnOnCoroutine()
    {
        float time = 0f;
        Color alpha = new Color(1, 1, 1, 0);
        int len = cloudBtns.Length;

        alpha.a = 0;
        while (alpha.a < 1)
        {
            time += Time.deltaTime / 1f;
            alpha.a = Mathf.Lerp(0, 1, time);

            for (int i = 0; i < len; i++)
            {
                cloudBtns[i].GetComponent<Image>().color = alpha;
                cloudCanvasGroup[i].alpha = alpha.a;
            }

            yield return null;
        }

        for (int i = 0; i < len; i++)
        {
            cloudBtns[i].GetComponent<Image>().color = Color.white;
            cloudBtns[i].interactable = true;
        }
    }

    public void Developer()
    {
        Debug.Log("Developer");
    }

    public void GamePlay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("CutScene");
    }
}
