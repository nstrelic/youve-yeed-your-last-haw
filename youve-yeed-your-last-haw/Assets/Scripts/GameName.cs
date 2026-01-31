using UnityEngine;
using System;

public class GameName : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

    void OnEnable()
    {
        EventManager.changeGameStateEvent += this.ChangeGameState;
    }

    void OnDisable()
    {
        EventManager.changeGameStateEvent -= this.ChangeGameState;
    }

    public void StopAnimator()
    {
        animator.enabled = false;
    }

    public void ChangeGameState(GameState nextState)
    {
        switch(nextState)
        {
            case GameState.MainMenu:
                animator.enabled = true;
                animator.SetTrigger("Slide");
                UnityEngine.Debug.Log(typeof(GameName).Name + "Switched to main menu screen");
                break;
            default:
                UnityEngine.Debug.Log(typeof(GameName).Name + "Switched to " + Enum.GetName(typeof(GameState), nextState));
                break;
        }
    }
}
