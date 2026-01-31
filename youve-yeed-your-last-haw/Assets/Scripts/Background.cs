using UnityEngine;
using System;

public class Background : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer spriteRenderer;

    [SerializeField]
    public Sprite[] backgrounds;

    void Start()
    {
        if (backgrounds == null || backgrounds.Length == 0)
        {
            UnityEngine.Debug.LogError("No backgrounds set");
        }
        else if (spriteRenderer == null)
        {
            UnityEngine.Debug.LogError("No sprite renderer set");
        }
        else
        {
            spriteRenderer.sprite = backgrounds[0];
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
            case GameState.TitleScreen:
            case GameState.MainMenu:
                spriteRenderer.sprite = backgrounds[0];
                UnityEngine.Debug.Log(typeof(Background).Name + "Switched to title or main menu screen");
                break;
            default:
                UnityEngine.Debug.Log(typeof(Background).Name + "Switched to " + Enum.GetName(typeof(GameState), nextState));
                break;
        }
    }
}
