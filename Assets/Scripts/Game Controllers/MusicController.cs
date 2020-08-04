using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicController : MonoBehaviour
{
    public static MusicController instance;

    private AudioSource bgMusic, click;

    private float time;

    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleton();
        AudioSource[] audioSources = GetComponents<AudioSource>();

        bgMusic = audioSources[0];
        click = audioSources[1];
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
 
    void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
 
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("LevelMenu"))
        {
            if (GameController.instance.isMusicOn)
            {
                if (!bgMusic.isPlaying)
                {
                    bgMusic.time = time;
                    bgMusic.Play();
                }
            }
        }
    }

    // Obsolete - replaced by OnSceneLoaded() above.
    // void OnLevelWasLoaded()
    // {
        
    // }

    public void GameIsLoadedTurnOffMusic()
    {
        if (bgMusic.isPlaying)
        {
            time = bgMusic.time;
            bgMusic.Stop();
        }
    }

    public void PlayClickClip()
    {
        click.Play();
    }

    public void StopBgMusic()
    {
        if (bgMusic.isPlaying)
        {
            bgMusic.Stop();
        }
    }

    public void PlayBgMusic()
    {
        if (!bgMusic.isPlaying)
        {
            bgMusic.Play();
        }
    }
}
