using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class school : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //Game.pepe.text = "Tell them that theve been selected";
        SceneManager.LoadScene(3);
    }
}
