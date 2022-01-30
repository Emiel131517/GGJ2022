using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsMenu : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene("Level_2");
    }
    public void LevelThree()
    {
        Debug.Log("Coming soon!");
    }
    public void LevelFour()
    {
        Debug.Log("Coming soon!");
    }
    public void LevelFive()
    {
        Debug.Log("Coming soon!");
    }
    public void LevelSix()
    {
        Debug.Log("Coming soon!");
    }
}
