using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void GoToLevelsMenu()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
    public void GoToCreditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu");
    }
}
