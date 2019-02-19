using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        AudioManager.instance.mixer.SetFloat("Volume", -30f);
        Cursor.lockState = CursorLockMode.None;
    }



    public void Resume()
    {
        UIManager.instance.screens[UIManager.instance.currentScreen].screen.SetActive(false);
        Time.timeScale = 1;
        CameraController.menuUp = false;
        AudioManager.instance.mixer.SetFloat("Volume", -15f);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        UIManager.instance.ShowScreen("Start");
    }

    public void Controls()
    {
        ControlsMenu.lastScreen = "Pause";
        UIManager.instance.ShowScreen("Controls");
    }

    public void Quit()
    {
        UIManager.instance.Quit();
    }
}
