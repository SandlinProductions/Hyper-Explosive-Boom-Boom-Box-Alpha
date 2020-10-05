using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene); //this will load scene that we type in on the editor
    }
    public void QuitGame()
    {
        Application.Quit(); //This closes the game
    }
}
