using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

using TMPro;
public class FadeOutTextAndImage : MonoBehaviour
{
    [SerializeField] private CanvasGroup group;

    private void OnEnable()
    {
        group.alpha = 0f;
        group.DOFade(1f, 1);
    }
}
