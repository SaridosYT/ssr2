using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class citra : MonoBehaviour
{
    public Text Citratalk;
    public Text Faradaytalk;
    public int numberotime = 0;
    // Start is called before the first frame update
    void Start()
    {
        //Game.pepe.text = "Glean The Red Person At The School and find Rowan";

    }

    // Update is called once per frame
    void Update()
    {
        if (numberotime == 0)
        {
            Faradaytalk.text = ""; 
            Citratalk.text = "Ahhh a Sythe, screams Citra";
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            numberotime++;
            
            if (numberotime == 1)
            {
                Faradaytalk.text = "Chill bro, I'm here for food, says Sythe Faraday";
                Citratalk.text = "";
            }
            if (numberotime == 2)
            {
                Faradaytalk.text = "";
                Citratalk.text = "Oh I thought you would glean (kill) us because Sythe's eat out";
            }
            if (numberotime == 3)
            {
                Faradaytalk.text = "I'm different";
                Citratalk.text = "";
            }

        }
    }
}
