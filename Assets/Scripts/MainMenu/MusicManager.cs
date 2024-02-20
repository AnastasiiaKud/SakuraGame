using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource repeatedMusicMenu;
    [SerializeField] private AudioSource repeatedMusicLevelJapan;
    [SerializeField] private AudioSource repeatedMusicLevelUK;
    [SerializeField] private AudioSource repeatedMusicLevelEgypt;

    [SerializeField] private List<string> scenesMenu;
    [SerializeField] private List<string> scenesLevelsJapan;
    [SerializeField] private List<string> scenesLevelsUK;
    [SerializeField] private List<string> scenesLevelsEgypt;

    private static bool isMuted = false; 

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!isMuted) 
        {
            if (scenesMenu.Contains(scene.name))
            {
                repeatedMusicMenu.mute = false;
                MuteAudioLevelJapan();
                MuteAudioLevelUK();
                MuteAudioLevelEgypt();
            }
            else if (scenesLevelsJapan.Contains(scene.name))
            {
                MuteAudioMenu();
                repeatedMusicLevelJapan.mute = false;
                MuteAudioLevelUK();    
                MuteAudioLevelEgypt();       
            }
            else if (scenesLevelsUK.Contains(scene.name))
            {
                MuteAudioMenu();
                MuteAudioLevelJapan();
                repeatedMusicLevelUK.mute = false;
                MuteAudioLevelEgypt();
            }
            else if (scenesLevelsEgypt.Contains(scene.name))
            {
                MuteAudioMenu();
                MuteAudioLevelJapan();
                MuteAudioLevelUK();
                repeatedMusicLevelEgypt.mute = false;
            }
            else
            {
                MuteAudioMenu();
                MuteAudioLevelJapan();
                MuteAudioLevelUK();
                MuteAudioLevelEgypt();
            }
        }
    }
    
    private void MuteAudioMenu() => repeatedMusicMenu.mute = true;
    private void MuteAudioLevelJapan() => repeatedMusicLevelJapan.mute = true;
    private void MuteAudioLevelUK() => repeatedMusicLevelUK.mute = true;
    private void MuteAudioLevelEgypt() => repeatedMusicLevelEgypt.mute = true;

    public void TurnOffAllSounds()
    {
        repeatedMusicMenu.mute = true;
        repeatedMusicLevelJapan.mute = true;
        repeatedMusicLevelUK.mute = true;
        repeatedMusicLevelEgypt.mute = true;
        isMuted = true;
    }

    public void TurnOnAllSounds()
    {
        OnSceneLoaded(SceneManager.GetActiveScene(), LoadSceneMode.Single);
        isMuted = false;
    }


    public bool IsAnySoundOn()
    {
        if (!repeatedMusicMenu.mute ||
            !repeatedMusicLevelJapan.mute ||
            !repeatedMusicLevelUK.mute ||
            !repeatedMusicLevelEgypt.mute)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}





