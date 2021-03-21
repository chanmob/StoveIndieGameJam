using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TeamLogo : MonoBehaviour
{
    public Image fadeImage;

    private void Start()
    {
        Invoke("FadeOut", 2f);
    }

    public void FadeOut()
    {
        StartCoroutine(FadeCoroutine());
    }

    private IEnumerator FadeCoroutine()
    {
        fadeImage.gameObject.SetActive(true);
        
        float time = 0f;
        Color alpha = fadeImage.color;
        
        alpha.a = 0;
        while (alpha.a < 1)
        {
            time += Time.deltaTime / 1f;
            alpha.a = Mathf.Lerp(0, 1, time);
            fadeImage.color = alpha;
            yield return null;
        }

        SceneManager.LoadScene("OutGame");
    }

    public void GoToOutGame()
    {
        FadeOut();
    }
}
