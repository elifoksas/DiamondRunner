using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmasCarpisma : MonoBehaviour
{
    static int sayac;
    static int ElmasSayaci;
    ElmasEkleme ElmasEkleme;
    void Start()
    {

        if (PlayerPrefs.GetInt("Dead") == 1)
        {
            sayac = 0;
            ElmasSayaci = 0;
        }
        ElmasEkleme = GameObject.Find("ElmasKontrol").GetComponent<ElmasEkleme>();

        
    }

  
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            
            
            //Surekli transformun üstüne ekleme yapmak için kullanýldý.
            sayac = sayac + 2;
            ElmasEkleme.ElmasOlusturucu(sayac);
            ElmasSayaci++;
            if (ElmasSayaci % 10 == 0)
            {
                sayac = sayac + 10;
               
            }
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
