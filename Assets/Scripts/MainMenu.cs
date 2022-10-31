using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // [SerializeField] Button startButton, instrButton;

    void Start()
    {
        // Button start = startButton.GetComponent<Button>();
        // Button instr = instrButton.GetComponent<Button>();
    }

    public void GameStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
    }

    public void GameInstructions()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Instructions");
    }

    public void GameExit()
    {
        Application.Quit();
    }
}
