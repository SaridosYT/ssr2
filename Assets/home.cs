using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class home : MonoBehaviour
{
    //movie
    //explore
    //glean1
    //conclave1
    //Faraday K.O.
    //PickOne
    //if (citra)
    //curries
    //find him
    //if (roan)
    //goodard
    //glean
    //conclave2
    //if (citra)
    //hang
    //if (roan)
    //kill gooder
    //conclave3
    void OnTriggerEnter(Collider other)
    {
        // pepe.text = "explore";
        SceneManager.LoadScene(6);
    }
}
