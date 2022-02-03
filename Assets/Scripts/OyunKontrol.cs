using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{
    public GameObject PausePanel;
    public karakter karakter;
    bool BaslangicKontrol=true;
    public Text BaslamaSayaci;

    void Start()
    {

        StartCoroutine(OyunuBaslat());

    }
    IEnumerator OyunuBaslat()
    {
        karakter.GetComponent<karakter>().Ilerihiz = 0;
        karakter.GetComponent<karakter>().GetComponent<Animator>().enabled = false;
        BaslamaSayaci.text = "3";
        yield return new WaitForSeconds(1);
        BaslamaSayaci.text = "2";
        yield return new WaitForSeconds(1);
        BaslamaSayaci.text = "1";
        yield return new WaitForSeconds(1);
        BaslamaSayaci.text = "GO!";
        karakter.GetComponent<karakter>().Ilerihiz = 3;
        karakter.GetComponent<karakter>().GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        BaslamaSayaci.text = "";
        StopCoroutine(OyunuBaslat());
    }
    private void Update()
    {
        
        
    }
    public void OyunuTekrarBaslat()
    {
        
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Dead", 1);
        SceneManager.LoadScene("GameScene");
        
    }
    public void AnaMenuyeDon()
    {
        SceneManager.LoadScene("AnaMenu");
        Time.timeScale = 1;
    }
    public void OyunaDevamEt()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void OyunuDurdur()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }
}
