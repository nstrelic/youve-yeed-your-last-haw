using UnityEngine;
using TMPro;
using System;

public class TitlesController : MonoBehaviour
{

    public string[] titles;

    public TMP_Text titleText;

    public Animator animator;

    public Canvas titlesCanvas;

    private int currentTitleIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (titles == null || titles.Length == 0)
        {
            UnityEngine.Debug.LogError("No titles set");
        }
        else if (titleText == null)
        {
            UnityEngine.Debug.LogError("No title mesh set");
        }
        else
        {
            currentTitleIndex = 0;
            titleText.text = titles[currentTitleIndex];
            animator.SetTrigger("TitleFadeZoom");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable()
    {
        EventManager.changeGameStateEvent += this.ChangeGameState;
    }

    void OnDisable()
    {
        EventManager.changeGameStateEvent -= this.ChangeGameState;
    }

    public void NextTitle()
    {
        if (currentTitleIndex == (titles.Length - 1))
        {
            titlesCanvas.enabled = false;
            animator.enabled = false;
            EventManager.ChangeGameState(GameState.MainMenu);
        }
        else
        {
            currentTitleIndex++;
            titleText.text = titles[currentTitleIndex];
            animator.SetTrigger("TitleFadeZoom");
        }
    }

    void ChangeGameState(GameState nextState)
    {
        switch(nextState)
        {
            case GameState.TitleScreen:
                UnityEngine.Debug.Log(typeof(TitlesController).Name + "Switched to title screen");
                currentTitleIndex = 0;
                titlesCanvas.enabled = true;
                animator.enabled = true;
                animator.SetTrigger("TitleFadeZoom");
                break;
            default:
                UnityEngine.Debug.Log(typeof(TitlesController).Name + "Switched to " + Enum.GetName(typeof(GameState), nextState));
                break;
        }
    }
}
