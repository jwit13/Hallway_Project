using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour {

    private float _audioVolume;
    public float audioVolume 
    {
        get 
        {
            return _audioVolume;
        }

        set
        {
            _audioVolume = value;
            mixer.SetFloat("Volume", _audioVolume);
        }
    }

    public AudioMixer mixer;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    void Start () {
		
	}
	
	void Update () {
		
	}
}
