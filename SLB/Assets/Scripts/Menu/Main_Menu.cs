using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu : MonoBehaviour
{
    public string sceneName;

    public GameObject main_View;
    public GameObject secondary_View;
    public int control = 1;

    public void Start_Game()
    {
        // Starts the Game 
        SceneManager.LoadScene(sceneName);

    }

    public void Swap_Menu()
    {
        if (control == 1)
        {
            main_View.SetActive(false);
            secondary_View.SetActive(true);
            control = 2;
        }
        
    }

    public void Swap_Menu2()
    {
        if (control == 2)
        {
            main_View.SetActive(true);
            secondary_View.SetActive(false);
            control = 1;
        }
    }

    public void Quit()
    {
         Application.Quit();
         Debug.Log("Game Closed");
    }

}
