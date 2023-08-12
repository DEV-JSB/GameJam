using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
public class StoryTeller : MonoBehaviour
{

    [SerializeField] private List<TextMeshProUGUI> lstStory;
    
    [SerializeField] private List<GameObject> lstPage2Story;

    [SerializeField] private List<Image> lstImage;

    [SerializeField] private Button nextStory;
    [SerializeField] private Button gameStartButton;
    [SerializeField] private float fadeInTime;
    
    private int storyIndex = 0;

    private void Start()
    {
        FadeInTMPPro(lstStory[storyIndex], fadeInTime);
        gameStartButton.onClick.AddListener(() => SceneManager.LoadScene("GameLobby"));
        ButtonSetting();
    }

    private void FadeInTMPPro(TextMeshProUGUI textMeshPro,float time)
    {
        textMeshPro.gameObject.SetActive(true);
        Color initialColor = textMeshPro.color;
        initialColor.a = 0;
        textMeshPro.color = initialColor;

        // 2초 동안 투명도를 1로 변경하여 텍스트를 나타냅니다.
        textMeshPro.DOFade(1, 2);
    }
    public void ButtonSetting()
    {
        nextStory.onClick.AddListener(NextStory);
    }
    private void NextStory()
    {
        if(storyIndex + 1 == lstStory.Count + lstPage2Story.Count)
        {
            nextStory.gameObject.SetActive(false);
            gameStartButton.gameObject.SetActive(true);
        }
        else if(lstStory.Count == storyIndex + 1)
        {
            for(int i = 0; i < 4; ++i)
            {
                lstStory[i].gameObject.SetActive(false);
            }
            ++storyIndex;
        }
        else
        {
            ++storyIndex;
        }
        if (storyIndex < lstStory.Count)
            FadeInTMPPro(lstStory[storyIndex], fadeInTime);
        else
            lstPage2Story[storyIndex - lstStory.Count].SetActive(true);
    }
}
