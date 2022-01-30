using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToLevelsMenu()
    {
        SceneManager.LoadScene("LevelsScreen");
    }
    public void GoToCreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
