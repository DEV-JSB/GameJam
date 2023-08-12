using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(SoundManager.Instance.ButtonClickSound);
    }
}
