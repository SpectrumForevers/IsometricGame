using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SoundToggler : ToggleUniversal
{
    int state = 1;

    private void Start()
    {
        state = PlayerPrefs.GetInt(PlayerPref.sound, 1);
        
        button = gameObject.GetComponent<Button>();

        //ColorBlock colors = button.colors;

        //colors.pressedColor = newPressedColor;

        //button.colors = colors;

        CheckSound();
        //button.onClick.AddListener(Test);
        button.onClick.AddListener(CheckSound);

        //button.onClick.AddListener(ActivateSound);
        //button.onClick.AddListener(ActivateButton);
    }
    private void Test()
    {
        Debug.Log("TEST");
    }
    private void CheckSound()
    {
        
        switch(state)
        {
            case 0:

                ChangeSound(state);
                
                state = 1;
                active.SetActive(false);
                inactive.SetActive(true);
                break;

            case 1:
               
                ChangeSound(state);
                active.SetActive(true);
                inactive.SetActive(false);
                state = 0;
                break;

        }

        
    }
    
    public void ChangeSound(int state)
    {
        AudioListener.volume = state;

        PlayerPrefs.SetInt(PlayerPref.sound, state);
    }
}
