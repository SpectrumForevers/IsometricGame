using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] Button buttonPlay;
    [SerializeField] Button buttonPreference;
    [SerializeField] Button buttonCloseGame;
    [SerializeField] Button buttonDelliteAllPrefs;
    int currentLVL;
    private void Awake()
    {
        buttonDelliteAllPrefs.onClick.AddListener(DellitePlayerPrefs);
        buttonPlay.onClick.AddListener(StartLVL);
        buttonCloseGame.onClick.AddListener(CloseGame);
        buttonPreference.onClick.AddListener(ActivatePreference);
    }
    private void Start()
    {
        currentLVL = PlayerPrefs.GetInt(PlayerPref.currentLVL_ID, 0);
    }

    private void ActivatePreference()
    {
        Debug.Log("Activate Preference");
    }
    private void CloseGame()
    {
        Debug.Log("Close Game");
    }
    private void StartLVL()
    {
        if(currentLVL == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(currentLVL);
        }
    }

    private void DellitePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

}
