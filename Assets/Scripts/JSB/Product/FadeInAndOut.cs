using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class FadeInAndOut : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    private void Start()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.DOFade(0, 2).OnComplete(LoadStoryScene);
    }
    private void LoadStoryScene()
    {
        SceneManager.LoadScene("Intro");
    }

}
