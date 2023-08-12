using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
public class GameLobby : MonoBehaviour
{
    [SerializeField] private Button gameStartButton;

    private void Start()
    {
        gameStartButton.onClick.AddListener(() => SceneManager.LoadScene(""));
    }
}
