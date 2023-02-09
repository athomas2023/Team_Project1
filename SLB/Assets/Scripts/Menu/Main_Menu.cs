using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Main_Menu : MonoBehaviour
{
    public string sceneName;

    public GameObject main_View;
    public GameObject secondary_View;
    public GameObject third_View;
    public int control = 1;


    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex = 0;


    public void Start_Game()
    {
        // Starts the Game 
        SceneManager.LoadScene(sceneName);

        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        Debug.Log("RefreshRate" + currentRefreshRate);
        for (int i = 0; i < resolutions.Length; i++)
        {
            Debug.Log("Resolutions:" + resolutions[i]);
            if (resolutions[i].refreshRate == currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for (int i = 0; i < filteredResolutions.Count; i++)
        {
            string resolutionOption = filteredResolutions[i].width + "x" + filteredResolutions[i].height + " " + filteredResolutions[i].refreshRate + " Hz";
            options.Add(resolutionOption);
            if (filteredResolutions[i].width == Screen.width && filteredResolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }


        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, true);
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

        if (control == 3)
        {
            main_View.SetActive(true);
            third_View.SetActive(false);
            control = 1;
        }
    }



    public void Swap_Menu3()
    {
        if (control == 1)
        {
            main_View.SetActive(false);
            third_View.SetActive(true);
            control = 3;
        }
        
    }
    public void Quit()
    {
         Application.Quit();
         Debug.Log("Game Closed");
    }

}
