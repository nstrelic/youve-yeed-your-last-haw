using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float drawCountdown = 700f;
    int keyPressCounter = 0;
    [SerializeField]
    int keyPressWinCount = 10;

    private List<KeyCode> possibleKeyCodes = new List<KeyCode> {
        KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D, KeyCode.E,
        KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.I, KeyCode.J,
        KeyCode.K, KeyCode.L, KeyCode.M, KeyCode.N, KeyCode.O,
        KeyCode.P, KeyCode.Q, KeyCode.R, KeyCode.S, KeyCode.T,
        KeyCode.U, KeyCode.V, KeyCode.W, KeyCode.X, KeyCode.Y,
        KeyCode.Z, KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow,
        KeyCode.RightArrow, KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7,
        KeyCode.Alpha8, KeyCode.Alpha9, KeyCode.Alpha0
    };

    public List<KeyCode> dynamicPossibleKeyCodes;

    public float getDrawCountdown()
    {
        return drawCountdown;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        dynamicPossibleKeyCodes = new List<KeyCode>(possibleKeyCodes);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GameState
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver
    }
