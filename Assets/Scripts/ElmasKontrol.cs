using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElmasKontrol : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
       
        Destroy(gameObject);
    }
    void Update()
    {
        
    }
}
