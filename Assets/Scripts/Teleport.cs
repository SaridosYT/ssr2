using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    public void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            quitButtonPressed();
        }
    }
    public void playButtonPressed()
    {
        SceneManager.LoadScene(1);
        Game.count++;
    }
    public void quitButtonPressed()
    {
        Application.Quit();
    }
    public void Door1()
    {
        SceneManager.LoadScene(2);
    }
    public void Door2()
    {
        SceneManager.LoadScene(3);
    }
    public void Door3()
    {
        SceneManager.LoadScene(4);
    }
    public void Door4()
    {
        SceneManager.LoadScene(5);
    }
    public void Door5()
    {
        SceneManager.LoadScene(6);
    }
    public void Door6()
    {
        SceneManager.LoadScene(7);
    }
    public void Door7()
    {
        SceneManager.LoadScene(8);
    }
    public void Door8()
    {
        SceneManager.LoadScene(9);
    }
    public void End()
    {
        SceneManager.LoadScene("Final Scene");
    }
    
}
