using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnamenuKontrol : MonoBehaviour
{
    public Sprite [] ButtonImages;
    public Button[] Buttons;
    public GameObject SettingsPanel;
    
    bool AnahtarSettings = false;
    bool AnahtarTitresim = true;
    void Start()
    {
        
    }
    public void OyunSahnesineGit()
    {
        SceneManager.LoadScene("GameScene");
    }
    
    public void SettingsPaneliKapatAc()
    {
        if (!AnahtarSettings)
        {
            SettingsPanel.SetActive(true);
            AnahtarSettings = true;
        }
        else
        {
            SettingsPanel.SetActive(false);
            AnahtarSettings = false;
        }
       
    }
    public void TitresimAcKapa()
    {
        if (AnahtarTitresim)
        {
            Buttons[0].GetComponent<Image>().sprite = ButtonImages[0];
            PlayerPrefs.SetInt("Titresim", 0);
            AnahtarTitresim = false;
        }
        else
        {
            Buttons[0].GetComponent<Image>().sprite = ButtonImages[1];
            PlayerPrefs.SetInt("Titresim", 1);
            AnahtarTitresim = true;
        }
    }

    void Update()
    {
        
    }
}
