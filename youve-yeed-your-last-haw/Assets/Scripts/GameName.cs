using UnityEngine;
using System;

public class GameName : MonoBehaviour
{
    [SerializeField]
    public Animator animator;

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

    public void CrackWhip()
    {
        audioSrc.Play();
    }

    public void StopAnimator()
    {
        animator.SetTrigger("Float");
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
                animator.enabled = false;
                UnityEngine.Debug.Log(typeof(GameName).Name + "Switched to " + Enum.GetName(typeof(GameState), nextState));
                break;
        }
    }
}
