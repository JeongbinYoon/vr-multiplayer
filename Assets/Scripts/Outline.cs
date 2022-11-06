using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Blue" || other.tag == "Red")
        {
            Destroy(other.gameObject);
        }
    }
}
