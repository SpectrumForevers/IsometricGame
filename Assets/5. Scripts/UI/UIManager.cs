using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Weapon UI")]
    [SerializeField] TMP_Text ammoCountText;

    [Header("Pause UI")]
    [SerializeField] Button buttonContinue;
    [SerializeField] Button buttonPause;
    [SerializeField] Button buttonExitToMenu;
    [SerializeField] Button buttonPreference;
    [SerializeField] GameObject menu;

    [Header("Win UI")]
    [SerializeField] Button buttonWin;
    [SerializeField] GameObject winUI;

    [Header("Lose UI")]
    [SerializeField] Button buttonLose;
    [SerializeField] GameObject loseUI;
    
    private void OnEnable()
    {
        EventBus.StartReload += StartReload;
        EventBus.Shoot += CurrentAmmo;
    }
    private void OnDisable()
    {
        EventBus.StartReload -= StartReload;
        EventBus.Shoot -= CurrentAmmo;
    }
    private void Awake()
    {
        buttonPause.onClick.AddListener(PauseGame);
        buttonContinue.onClick.AddListener(StartGame);
        buttonWin.onClick.AddListener(Win);
        buttonLose.onClick.AddListener(Lose);
    }
    private void CurrentAmmo(int currentAmmo)
    {
        ammoCountText.text = currentAmmo.ToString();
    }
    private void StartReload()
    {
        ammoCountText.text = "Reloading";
    }
    public void ActivateWinUI()
    {
        winUI.SetActive(true);
    }
    public void ActivateLoseUI()
    {
        loseUI.SetActive(true);
    }
    private void PauseGame()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
    }
    private void StartGame()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
    }
    private void LoadMainScene()
    {

    }
    private void Activatepreference()
    {

    }
    private void Win()
    {
        int nextLVL = SceneManager.GetActiveScene().buildIndex + 1;
        PlayerPrefs.SetInt(PlayerPref.currentLVL_ID, nextLVL);
        
        if(SceneManager.sceneCountInBuildSettings > nextLVL)
        {
            SceneManager.LoadScene(nextLVL);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    private void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
