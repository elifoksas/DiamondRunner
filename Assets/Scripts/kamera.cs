using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamera : MonoBehaviour
{
    public GameObject karakter;
    Vector3 aradakifark;
    void Start()
    {
        aradakifark = transform.position - karakter.transform.position;
    }

    
    void Update()
    {
        if(karakter!=null)
        transform.position = karakter.transform.position + aradakifark;

    }
}
