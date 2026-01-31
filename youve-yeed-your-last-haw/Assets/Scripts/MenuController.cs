using UnityEngine;
using System;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public Canvas canvas;

    [SerializeField]
    public AudioSource audioSrc;

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
                canvas.enabled = true;
                UnityEngine.Debug.Log(typeof(MenuController).Name + "Switched to main menu screen");
                break;
            default:
                UnityEngine.Debug.Log(typeof(MenuController).Name + "Switched to " + Enum.GetName(typeof(GameState), nextState));
                break;
        }
    }
    
    public void StartGame()
    {
        audioSrc.Play();
        EventManager.ChangeGameState(GameState.WaitingToStart);
        canvas.enabled = false;
    }

    public void ExitGame()
    {
        #if UNITY_STANDALONE
                //Quit the application
                Application.Quit();
        #endif

        #if UNITY_EDITOR
                //Stop playing the scene
                UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}