using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public int currentScreen;

    [System.Serializable]
    public struct Screen
    {
        public string name;
        public GameObject screen;
        
    }

    public List<Screen> screens = new List<Screen>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else
        {
            GameObject.Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
        
    }

    void Start()
    {
        ShowScreen("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape") || Input.GetKeyDown("joystick button 7"))
        {
            ShowScreen("Pause");
            CameraController.menuUp = true;
        }
    }

    public void ShowScreen (string name)
    {
        Time.timeScale = 0;
        for(int i = 0; i < screens.Count; i++)
        {
            if (screens[i].name.Equals(name))
            {
                screens[currentScreen].screen.SetActive(false);
                screens[i].screen.SetActive(true);
                currentScreen = i;
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
    /*
    public IEnumerator ShowScreenCoroutine (int index)
    {
        //Found Screen, disable old one, enable new one, keep new reference
        if (screens[currentScreen].screenAnimator!= null)
        {
            screens[currentScreen].screenAnimator.SetTrigger("Close");
            yield return new WaitForSeconds(1.0f);
        }
        screens[currentScreen].screen.SetActive(false);
        screens[index].screen.SetActive(true);
        currentScreen = index;
    }
    */
}
