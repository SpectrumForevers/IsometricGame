using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text ammoCountText;


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

    private void CurrentAmmo(int currentAmmo)
    {
        ammoCountText.text = currentAmmo.ToString();
    }
    private void StartReload()
    {
        ammoCountText.text = "Reloading";
    }
}
