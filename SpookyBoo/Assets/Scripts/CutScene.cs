using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CutScene : MonoBehaviour
{
    [System.Serializable]
    public class CutSceneData
    {
        public string cutsceneKey;
        public string cutsceneString;
    }

    public float printDelay;

    public Animator anim;

    public CutSceneData[] cutsceneDatas;

    public Image cutsceneBackground;

    public Image img;

    public Text cutsceneText;

    private int idx = 0;
    private int len = 0;

    private bool _isPrinting;
    private bool _isSceneLoad = false;

    private string _currentMessage;

    private IEnumerator _showTextCoroutine;

    private void Start()
    {
        len = cutsceneDatas.Length;

        MouseClicked();
    }

    public void SkipClicked()
    {
        SoundManager.instance.PlaySFX("SE", 1f);
    }

    public void LoadInGameScene()
    {
        if (_isSceneLoad)
            return;

        UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
        _isSceneLoad = true;
    }

    public void MouseClicked()
    {
        if (_isPrinting)
        {
            if(_showTextCoroutine != null)
            {
                StopCoroutine(_showTextCoroutine);
                _showTextCoroutine = null;
            }

            cutsceneText.text = _currentMessage;
            _isPrinting = false;
        }
        else
        {
            if (idx == len)
            {
                LoadInGameScene();
                return;
            }

            cutsceneText.text = string.Empty;
            LayoutRebuilder.ForceRebuildLayoutImmediate((RectTransform)img.transform);

            anim.SetTrigger(cutsceneDatas[idx].cutsceneKey);
            _currentMessage = cutsceneDatas[idx].cutsceneString;

            _showTextCoroutine = ShowTextCoroutine();
            StartCoroutine(_showTextCoroutine);

            idx++;
        }
    }

    private IEnumerator ShowTextCoroutine()
    {
        _isPrinting = true;

        cutsceneText.text = string.Empty;

        for (var i = 0; i <= _currentMessage.Length; i++)
        {
            cutsceneText.text = _currentMessage.Substring(0, i);
            yield return new WaitForSeconds(printDelay);
        }

        _showTextCoroutine = null;

        _isPrinting = false;
    }
}
