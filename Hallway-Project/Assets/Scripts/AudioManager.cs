using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioMixer mixer;

    // Static Refs
    public static AudioManager instance;

    // Struct in C#: Variable of variables
    [System.Serializable]
    public struct Clip
    {
        public string keyName;
        public AudioClip audio;
    }
    public Clip[] clips;
    public AudioSource audioSource;

    // Background Music
    public AudioClip levelMusic;
    public AudioClip chaseMusic;
    public AudioClip winMusic;
    public AudioClip loseMusic;

    void Start()
    {
        mixer.SetFloat("Volume", -15f);
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        instance = this;
    }

    void Update()
    {

    }

    public void PlayAudio(string keyName)
    {
        for (int i = 0; i < clips.Length; i++)
        {
            if (clips[i].keyName == keyName)
            {
                // Found clip to play
                audioSource.PlayOneShot(clips[i].audio);
                return;
            }
        }
    }

    public void PlayBackground(string keyName)
    {
        switch (keyName)
        {
            case "Lose":
                instance.audioSource.clip = loseMusic;
                instance.audioSource.Play();
                break;
            case "Win":
                instance.audioSource.clip = winMusic;
                instance.audioSource.Play();
                break;
            case "Chase":
                instance.audioSource.clip = chaseMusic;
                instance.audioSource.Play();
                break;
            default:
                instance.audioSource.clip = levelMusic;
                instance.audioSource.Play();
                break;
        }
        
    }

}
