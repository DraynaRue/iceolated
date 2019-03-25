using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Room_ : MonoBehaviour 
{
 void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            AudioManager.Instance.PlaySound ("IceRoom", transform.position);
        }
    }
}
