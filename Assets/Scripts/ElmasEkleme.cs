using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmasEkleme : MonoBehaviour
{
    public Vector3 [] diamondskonum;
    public GameObject[] diamonds ;
    public GameObject[] RenkCizgileri;
    public Vector3 RenkCizgisiKonum;
    public float Elmasuzaklik;
    public int Cizgiuzaklik;

    private void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            
            ElmasOlusturucu(2*i-27);

        }
        RenkCizgisiOlusturucu(0);
    }

    public void RenkCizgisiOlusturucu(int Konum)
    {
        int RastgeleSayiCizgi = Random.Range(0, RenkCizgileri.Length);
        Instantiate(RenkCizgileri[RastgeleSayiCizgi], new Vector3(RenkCizgisiKonum.x, RenkCizgisiKonum.y, RenkCizgisiKonum.z + Konum), Quaternion.identity);

    }
    public void ElmasOlusturucu(int sayac)
    {

        int rastgelesayiElmas = Random.Range(0,diamonds.Length);
       
    
        Instantiate(diamonds[rastgelesayiElmas], new Vector3(diamondskonum[0].x, diamondskonum[0].y, diamondskonum[0].z + Elmasuzaklik + sayac), Quaternion.identity);

 
    } 
}
