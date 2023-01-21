using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class momo : MonoBehaviour
{
    public Text uTalk;
    public Text tTalk;
    public int numberotimee = 0;
     void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
       
        SceneManager.LoadScene(5);
    }
    private void Update()
    {
        if (numberotimee == 0)
        {
            uTalk.text = "So both of you are going to be trained in the ways of death";
            tTalk.text = "";
        }
        if (Input.GetKeyDown(KeyCode.X))
        {

            numberotimee++;
            if (numberotimee == 1)
            {
                uTalk.text = "Only one will prevail";
                tTalk.text = "";
            }
            if (numberotimee == 2)
            {
                tTalk.text = "No....";
                uTalk.text = "";
            }
            if (numberotimee == 3)
            {
                tTalk.text = "If we must";
                uTalk.text = "";
            }
        }
    }
}
