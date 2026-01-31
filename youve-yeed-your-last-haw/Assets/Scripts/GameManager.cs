using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    float drawCountdown = 700f;
    [SerializeField]
    int keyPressWinCount = 10;
    [SerializeField]
    GameObject playerOne;
    [SerializeField]
    GameObject playerTwo;
    int keyPressCounter = 0;
    
    GameState gameState = GameState.Draw;

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

    private List<KeyCode> dynamicPossibleKeyCodes;

    KeyCode playerOneDrawKey;
    KeyCode playerOneBattleKey;
    KeyCode playerTwoDrawKey;
    KeyCode playerTwoBattleKey;

    public KeyCode getPlayerOneDrawKey() { return playerOneDrawKey; }
    public KeyCode getPlayerOneBattleKey() { return playerOneBattleKey; }
    public KeyCode getPlayerTwoDrawKey() { return playerTwoDrawKey; }
    public KeyCode getPlayerTwoBattleKey() { return playerTwoBattleKey; }  

    public float getDrawCountdown()
    {
        return drawCountdown;
    }

    public GameState getCurrentGameState()
    {
        return gameState;
    }

    public KeyCode getKeyCode(KeyType keyType, int player)
    {
        switch (keyType)
        {
            case KeyType.Battle:
                if (player == 1)
                {
                    return playerOneBattleKey;
                }
                else if (player == 2)
                {
                    return playerTwoBattleKey;
                }
                break;
            case KeyType.Draw:
                if (player == 1)
                {
                    return playerOneDrawKey;
                }
                else if (player == 2)
                {
                    return playerTwoDrawKey;
                }
                break;
        }

        return KeyCode.None;
    }

    public KeyCode generateKeyCode(KeyType keyType, int player) 
    {
        KeyCode generatedKey = dynamicPossibleKeyCodes[Random.Range(0, dynamicPossibleKeyCodes.Count)];
        dynamicPossibleKeyCodes.Remove(generatedKey);
        switch (keyType)
        {
            case KeyType.Battle:
                if (player == 1)
                {
                    playerOneBattleKey = generatedKey;
                    return playerOneBattleKey;
                }
                else if (player == 2) 
                { 
                    playerTwoBattleKey = generatedKey;
                    return playerTwoBattleKey;
                }
                break;
            case KeyType.Draw:
                if (player == 1)
                {
                    playerOneDrawKey = generatedKey;
                    return playerOneDrawKey;
                }
                else if (player == 2)
                {
                    playerTwoDrawKey = generatedKey;
                    return playerTwoDrawKey;
                }
                break;
        }

        return KeyCode.None;
    }

    private void OnEnable()
    {
        EventManager.changeGameStateEvent += OnChangeGameState;
    }

    private void OnDisable()
    {
        EventManager.changeGameStateEvent -= OnChangeGameState;
    }

    public void OnChangeGameState(GameState nextState)
    {
        gameState = nextState;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        dynamicPossibleKeyCodes = new List<KeyCode>(possibleKeyCodes);
    }

    // Update is called once per frame
    void Update()
    {
        // evaluate battle counter
        if (gameState == GameState.PlayerOneAttacking || gameState == GameState.PlayerTwoAttacking)
        {
            keyPressCounter = playerOne.GetComponent<Player>().getPlayerPressCounter() - playerTwo.GetComponent<Player>().getPlayerPressCounter();
            if (System.Math.Abs(keyPressCounter) >= keyPressWinCount)
            {
                if (keyPressCounter < 0)
                {
                    playerOne.GetComponent<Player>().snapMask();
                    Debug.Log("Player 2 Wins the Round!");
                }
                else
                {
                    playerTwo.GetComponent<Player>().snapMask();
                    Debug.Log("Player 1 Wins the Round!");
                }
                gameState = GameState.GameOver;
                Debug.Log("Game Over!");
            }
        }
    }
}

public enum GameState
    {
        TitleScreen,
        MainMenu,
        WaitingToStart,
        Draw,
        GamePlaying,
        PlayerOneAttacking,
        PlayerTwoAttacking,
        GameOver
    }
