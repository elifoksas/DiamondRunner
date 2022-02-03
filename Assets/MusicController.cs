using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string MusicPref = "MusicPref";
    static MusicController Sounds = null;
    public AnamenuKontrol AnamenuKontrol;
    public GameObject MusicControl;
    bool OnOff = true;
    void Start()
    {
        if (PlayerPrefs.GetFloat("MusicPref") == 0)
        {
            GetComponent<AudioSource>().volume = 0;
            MusicControl.GetComponent<Image>().sprite = AnamenuKontrol.ButtonImages[2];

            OnOff = true;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0.2f;
            
            MusicControl.GetComponent<Image>().sprite = AnamenuKontrol.ButtonImages[3];
            OnOff = false;

        }
        GetComponent<AudioSource>().Play();
        if (PlayerPrefs.GetFloat(FirstPlay) == 0)
        {
            PlayerPrefs.SetFloat(MusicPref, 0.2f);
        }

        if (Sounds != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Sounds = this;
            GameObject.DontDestroyOnLoad(gameObject);
        }
        PlayerPrefs.SetFloat(FirstPlay, 1);
        
    }

    public void MusicOnOff()
    {
        if (OnOff)
        {
            MusicControl.GetComponent<Image>().sprite = AnamenuKontrol.ButtonImages[2];
            PlayerPrefs.SetFloat(MusicPref, 0);
            OnOff = false;
        }
        else
        {
            MusicControl.GetComponent<Image>().sprite = AnamenuKontrol.ButtonImages[3];
            PlayerPrefs.SetFloat(MusicPref, 0.2f);
            OnOff = true;
        }
    }
    
    void Update()
    {
        if (AnamenuKontrol == null && MusicControl == null && SceneManager.GetActiveScene().name == "AnaMenu")
        {
            AnamenuKontrol = GameObject.Find("AnamenuKontrol").GetComponent<AnamenuKontrol>();
            MusicControl = GameObject.Find("Canvas").transform.GetChild(2).GetChild(0).GetChild(0).gameObject;
        }
        if (PlayerPrefs.GetFloat("MusicPref") == 0)
        {
            GetComponent<AudioSource>().volume = 0;


        }
        else
        {
            GetComponent<AudioSource>().volume = 0.2f;
            

        }
    }
}
