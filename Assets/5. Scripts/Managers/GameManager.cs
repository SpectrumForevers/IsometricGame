using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> enemysActive;
    [SerializeField] int countEnemy;
    [SerializeField] UIManager uiManager;
    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1.0f;
    }
    private void Start()
    {
        PlayerPrefs.SetInt(PlayerPref.currentLVL_ID, SceneManager.GetActiveScene().buildIndex);
    }

    private void Update()
    {
        if (enemysActive.Count <= 0 && countEnemy <= 0)
        {
            WinLVL();
        }
    }
    public void SetNewEnemyActive(GameObject enemy)
    {
        enemysActive.Add(enemy);
        
    }
    public void AddEnemyCounter(int enemyCount)
    {
        countEnemy += enemyCount;
    }
    public GameObject GetPlayer()
    {
        return player;
    }
    public void SetPlayer(GameObject player)
    {
        this.player = player;
    }
    public List<GameObject> GetListEnemy()
    {
        return enemysActive;
    }
    public void RemoveEnemyFromList(GameObject enemy)
    {
        enemysActive.Remove(enemy);
    }
    public void WinLVL()
    {
        Time.timeScale = 0f;
        PlayerPrefs.SetInt(PlayerPref.currentLVL_ID, SceneManager.GetActiveScene().buildIndex + 1);
        uiManager.ActivateWinUI();
    }
    public void LoseLVL()
    {
        Time.timeScale = 0f;

        uiManager.ActivateLoseUI();
    }
}
