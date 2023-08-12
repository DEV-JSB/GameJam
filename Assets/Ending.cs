using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject inGameUI;
    // Start is called before the first frame update
    void OnEnable()
    {
        inGameUI.SetActive(false);
    }
    public void GoToLobby() => SceneManager.LoadScene("GameLobby");
}
