using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPickUp : MonoBehaviour
{
   public GameObject pickup1;
 void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            pickup1.gameObject.SetActive(true);
            
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
