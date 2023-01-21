using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    //places
    public GameObject Cirta;
    public GameObject Roan;
    public GameObject Scool;
    public GameObject Movie;
    public GameObject Fariday;
    public GameObject Bus;
    public GameObject Conclave;
    public GameObject Currie;
    public GameObject Goddard;
    public GameObject Texet;
    //public Text pepe;
    public Text intro;
    public Text objj;
    public static int count = -1;
    //public Button Cont;
    //things

    void Start()
    {
        intro.text = "Hello Player." +
            "Your name is Sythe Faraday. " +
            "Humanity has evolved to conquer: war, disease, hunger, and everything else, " +
            "except over population. " +
            "Good luck out there " +
            "Press 'x' to continue"
            ;

        //pepe.text = "Find Citra";
        objj.text = "Find Citra";
    }

    // Update is called once per frame
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            count++;
            SceneManager.LoadScene(2);

        }
        
    }
    void OnTriggerEnter(Collider other)
    {
       // pepe.text = "Find Roawn";
        SceneManager.LoadScene(2);
    }
    public void presscont()
    {
        intro.text = "";
        //Destroy(Cont);

    }
    public void Update()
    {
        Debug.Log(count);
        if (Input.GetKeyDown(KeyCode.X))
        {
            intro.text = "";
            //Cont =
        }
        if (count == 1)
        {
            objj.text = "Glean the red person at the school and find Rowan";
        }
        if (count == 2)
        {
            objj.text = "Tell Citra and Rowan they have been selected ";
        }
        if (count == 3)
        {
            objj.text = "Go Home";
        }
        if (count == 4)
        {
            objj.text = "Go To The Conclave (Meeting Of Sythes (at bus stop))";
        }
    }

}
