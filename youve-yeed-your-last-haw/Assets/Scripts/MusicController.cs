using UnityEngine;
using System;

public class MusicController : MonoBehaviour
{
    [SerializeField]
    public AudioSource audioSrc;

    [SerializeField]
    public AudioClip[] tracks;

    void Start()
    {
        if (tracks == null || tracks.Length == 0)
        {
            UnityEngine.Debug.LogError("No music tracks set");
        }
        else if (audioSrc == null)
        {
            UnityEngine.Debug.LogError("No audio source set");
        }
        else
        {
            audioSrc.clip = tracks[0];
            audioSrc.Play();
        }
    }

    void OnEnable()
    {
        EventManager.changeGameStateEvent += this.ChangeGameState;
    }

    void OnDisable()
    {
        EventManager.changeGameStateEvent -= this.ChangeGameState;
    }

    public void ChangeGameState(GameState nextState)
    {
        switch(nextState)
        {
            case GameState.MainMenu:
                UnityEngine.Debug.Log(typeof(Background).Name + "Switched to title or main menu screen");
                break;
            default:
                audioSrc.Stop();
                UnityEngine.Debug.Log(typeof(Background).Name + "Switched to " + Enum.GetName(typeof(GameState), nextState));
                break;
        }
    }
}
