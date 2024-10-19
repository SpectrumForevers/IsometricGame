
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleUniversal : MonoBehaviour
{

    [SerializeField] public Button button;
    [SerializeField] PauseToggle toggle = PauseToggle.DeactivatePause;

    [SerializeField] public GameObject active;
    [SerializeField] List<GameObject> activeWhenToggle;

    [SerializeField] public GameObject inactive;
    [SerializeField] List<GameObject> inactiveWhenToggle;

    

    private void Start()
    {
        Init();

        button.onClick.AddListener(ActivateButton);

    }

    public void Init()
    {
        button = GetComponent<Button>();
        
        if (active.activeInHierarchy)
        {
            SetActiveList(activeWhenToggle, true);
            SetActiveList(inactiveWhenToggle, false);

        }
        else
        {
            SetActiveList(activeWhenToggle, false);
            SetActiveList(inactiveWhenToggle, true);
        }

    }

    
    
    public void ActivateButton()
    {

        switch (toggle)
        {
            case PauseToggle.DeactivatePause:
                DeactivatePause();
                break;

            case PauseToggle.ActivatePause:
                ActivatePause();
                break;
        }
        if (active.activeInHierarchy)
        {
            inactive.SetActive(true);
            active.SetActive(false);
            if(inactive.GetComponent<Image>() != null)
                button.targetGraphic = inactive.GetComponent<Image>();
            
            SetActiveList(activeWhenToggle, false);
            SetActiveList(inactiveWhenToggle, true);

        }
        else
        {
            active.SetActive(true);
            inactive.SetActive(false);
            if (inactive.GetComponent<Image>() != null)
                button.targetGraphic = active.GetComponent<Image>();

            SetActiveList(activeWhenToggle, true);
            SetActiveList(inactiveWhenToggle, false);

        }
    }
    void SetActiveList(List<GameObject> listGameobject, bool ActivateOrDeactivate)
    {
        if(listGameobject.Count > 0)
        {
            for (int i = 0; i < listGameobject.Count; i++)
            {
                listGameobject[i].SetActive(ActivateOrDeactivate);
            }
        }
    }
    private void ActivatePause()
    {
        Time.timeScale = 0f;
    }
    private void DeactivatePause()
    {
        Time.timeScale = 1f;
    }
}
enum PauseToggle
{
    ActivatePause,
    DeactivatePause,
}