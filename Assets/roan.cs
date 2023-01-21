using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class roan : MonoBehaviour
{
    public Text ko;
    public GameObject bro1;
    void OnTriggerEnter(Collider other)
    {
        ko.text = "Gleaning Complete";
        Destroy(bro1);
    }
}
