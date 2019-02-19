using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
        slider.value = GameManager.instance.audioVolume;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Back()
    {
        UIManager.instance.ShowScreen("Main");
    }

    public void Graphics()
    {
        UIManager.instance.ShowScreen("Graphics");
    }

    public void SetAudioVolume (float sliderValue)
    {
        Debug.Log("Setting volume to: " + sliderValue);
        GameManager.instance.audioVolume = sliderValue;
    }
}
