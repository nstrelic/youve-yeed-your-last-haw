using UnityEngine;
using System;

public class IntroCutscene : MonoBehaviour
{
    public Canvas canvas;
    void OnEnable()
    {
        EventManager.changeGameStateEvent += this.ChangeGameState;
    }

    void OnDisable()
    {
        EventManager.changeGameStateEvent -= this.ChangeGameState;
    }

    public void EndCutscene()
    {
        canvas.enabled = false;
        EventManager.ChangeGameState(GameState.Draw);
    }

    public void ChangeGameState(GameState nextState)
    {
        switch(nextState)
        {
            case GameState.WaitingToStart:
                canvas.enabled = true;
                UnityEngine.Debug.Log(typeof(IntroCutscene).Name + "Switched to intro cutscene screen");
                break;
            case GameState.Draw:
                canvas.enabled = false;
                break;
            default:
                UnityEngine.Debug.Log(typeof(IntroCutscene).Name + "Switched to " + Enum.GetName(typeof(GameState), nextState));
                break;
        }
    }
}
