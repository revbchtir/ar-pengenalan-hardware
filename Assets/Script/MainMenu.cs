using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void QuitApp()
    {
        Application.Quit();
    }
    public void StartAR()
    {
        SceneManager.LoadScene("kamera AR");
    }
}

