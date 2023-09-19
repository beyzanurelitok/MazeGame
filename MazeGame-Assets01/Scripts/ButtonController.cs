using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    //public playerMove player;
    ////private GameObject continueButton;
    //private void Start()
    //{
    //    player = GameObject.FindObjectOfType<playerMove>();
    //}
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");

    }
    public void QuitGame()
    {
        print("Exited The Game!!");
        Application.Quit();
    }
    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
    public void Back()
    {
        SceneManager.LoadScene("Start");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Start");
        //continueButton.SetActive(true);


    }
    public void Restart()
    {
        SceneManager.LoadScene("Start");
        //continueButton.SetActive(false);
    }
   
    
}
