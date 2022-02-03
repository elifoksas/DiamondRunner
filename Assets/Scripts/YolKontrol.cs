using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YolKontrol : MonoBehaviour
{
    ElmasEkleme ElmasEkleme;
    

    void Start()
    {
        ElmasEkleme = GameObject.Find("ElmasKontrol").GetComponent<ElmasEkleme>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //yol sonsuz devam etsin diye yazdýk
        //player collidera deðince yol eklencek
        if (other.tag == "Player")
        {
            transform.position += new Vector3(0, 0, 87f);

            //ElmasEkleme.ElmasOlusturucu(other.gameObject.transform.position*5f);//Karakterin yoldaki pozisyonuna göre elmas oluþturma
        }
    }
    
   
}
