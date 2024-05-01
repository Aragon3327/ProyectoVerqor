using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip menubackground;
    public AudioClip gamebackground;
    public AudioClip storyBackground;
    public AudioClip walk;
    public AudioClip papel;
    public AudioClip buttonsound;
    public AudioClip plantar;
    public AudioClip comprar;
    public AudioClip bueno;
    public AudioClip malo;
    public AudioClip cat;
    public AudioClip verqor;
    public AudioClip coyote;
    public AudioClip banco;
    public AudioClip win;
    public AudioClip lose;

    private static AudioManager instance = null;

    private bool isPlayingSfx = false;
    
    private void Awake()
{
    if (instance == null)
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        if (SceneManager.GetActiveScene().name == "Menu")
        {
            musicSource.clip = menubackground;
        }
        else if (SceneManager.GetActiveScene().name == "Story")
        {
            musicSource.clip = storyBackground;
        }
        else if (SceneManager.GetActiveScene().name == "Modificado")
        {
            musicSource.clip = gamebackground;
        }
        musicSource.Play();
    }
    else
    {
        Destroy(gameObject);
    }
}

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu")
        {
            musicSource.clip = menubackground;
        }
        else if (scene.name == "Story")
        {
            musicSource.clip = storyBackground;
        }
        else if (scene.name == "Modificado")
        {
            musicSource.clip = gamebackground;
        }
        musicSource.Play();
    }

    public void Playsfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
        isPlayingSfx = true;
        Invoke("ResetIsPlayingSfx", clip.length);
    }

    public void PlayOnesfx(AudioClip clip)
    {
        if (!isPlayingSfx)
        {
            sfxSource.PlayOneShot(clip);
            isPlayingSfx = true;
            Invoke("ResetIsPlayingSfx", clip.length);
        }
    }

    private void ResetIsPlayingSfx()
    {
        isPlayingSfx = false;
    }
}
