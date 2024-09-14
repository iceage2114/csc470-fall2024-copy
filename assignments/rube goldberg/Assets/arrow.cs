using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class GravityTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);
        
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            Debug.Log("Rigidbody found, enabling gravity");
            rb.useGravity = true;
        }
        else
        {
            Debug.Log("No Rigidbody found on entering object");
        }
    }
}