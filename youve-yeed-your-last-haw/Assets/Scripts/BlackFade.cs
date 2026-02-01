using UnityEngine;
using System;

public class BlackFade : MonoBehaviour
{
    public Animator animator;

    void OnEnable()
    {
        EventManager.changeGameStateEvent += this.ChangeGameState;
    }

    void OnDisable()
    {
        EventManager.changeGameStateEvent -= this.ChangeGameState;
    }

    public void StopFade()
    {
        animator.SetTrigger("Idle");
    }

    public void ChangeGameState(GameState nextState)
    {
        switch(nextState)
        {
            case GameState.WaitingToStart:
                animator.SetTrigger("Fade");
                UnityEngine.Debug.Log(typeof(BlackFade).Name + "Switched to waiting to start screen");
                break;
            default:
                UnityEngine.Debug.Log(typeof(BlackFade).Name + "Switched to " + Enum.GetName(typeof(GameState), nextState));
                break;
        }
    }
}
