using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void OnEnable()
    {
        Time.timeScale = 0;
        AudioManager.instance.PlayBackground("Start");
        AudioManager.instance.mixer.SetFloat("Volume", -30f);
        Cursor.lockState = CursorLockMode.None;
        UIManager.instance.currentScreen = 0;
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void Play()
    {
        UIManager.instance.screens[UIManager.instance.currentScreen].screen.SetActive(false);
        Time.timeScale = 1;
        CameraController.menuUp = false;
        AudioManager.instance.mixer.SetFloat("Volume", -15f);
        Cursor.lockState = CursorLockMode.Locked;

    }

    public void Options ()
    {
        UIManager.instance.ShowScreen("Options");
    }

    public void Controls ()
    {
        ControlsMenu.lastScreen = "Start";
        UIManager.instance.ShowScreen("Controls");
    }

    public void Quit()
    {
        UIManager.instance.Quit();
    }
}
