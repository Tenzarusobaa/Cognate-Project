using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager
using TMPro;

public class NumberTextIncreaser : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    int counter;

    public void ButtonPressed() 
    {

        // Load the scene named "2048"
        SceneManager.LoadScene("2048");
    }

    public void LeaderboardsButton() 
    {
        SceneManager.LoadScene("Leaderboards");
    }

    public void BackButton() 
    {
        SceneManager.LoadScene("Menu");
    }

    public void SettingsButton() 
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
