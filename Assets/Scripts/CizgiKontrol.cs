using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CizgiKontrol : MonoBehaviour
{
    
    ElmasEkleme ElmasEkleme;
    static int konum;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("Dead") == 1)
        {
            konum = 0;
        }
        ElmasEkleme = GameObject.Find("ElmasKontrol").GetComponent<ElmasEkleme>();


    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (PlayerPrefs.GetFloat("MusicPref") == 0)
            {

                GetComponent<AudioSource>().volume = 0;
            }
            else
            {
                GetComponent<AudioSource>().volume = 0.2f;
                GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);
            }
           
            Handheld.Vibrate();
            if (PlayerPrefs.GetInt("Dead") == 1)
            {
                
                konum = 0;
            }
            konum = konum + 30;
            ElmasEkleme.RenkCizgisiOlusturucu(konum);
            StartCoroutine(Destroyer());
            PlayerPrefs.SetInt("Dead", 0);
            
            
        }
    }
    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        StopCoroutine(Destroyer());

    }
}
