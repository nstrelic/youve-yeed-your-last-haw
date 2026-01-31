using UnityEngine;
using System.Collections.Generic;

public class KeyToPress : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    GameManager gameManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameManager.getCurrentGameState())
        {
            case GameState.Draw:
                Debug.Log("P" + player.GetComponent<Player>().getPlayerNumber() + " " + gameManager.getKeyCode(KeyType.Draw, player.GetComponent<Player>().getPlayerNumber()));
                if (Input.GetKeyDown(gameManager.getKeyCode(KeyType.Draw, player.GetComponent<Player>().getPlayerNumber())))
                {
                    Debug.Log("Player " + player.GetComponent<Player>().getPlayerNumber() + " pressed the correct key: " + gameManager.getKeyCode(KeyType.Draw, player.GetComponent<Player>().getPlayerNumber()));
                    EventManager.ChangeGameState(player.GetComponent<Player>().getPlayerNumber() == 1 ? GameState.PlayerOneAttacking : GameState.PlayerTwoAttacking);
                }
                break;
            case GameState.PlayerOneAttacking:
            case GameState.PlayerTwoAttacking:
                Debug.Log("P" + player.GetComponent<Player>().getPlayerNumber() + " " + gameManager.getKeyCode(KeyType.Battle, player.GetComponent<Player>().getPlayerNumber()));
                if (Input.GetKeyDown(gameManager.getKeyCode(KeyType.Battle, player.GetComponent<Player>().getPlayerNumber())))
                {
                    Debug.Log("Player " + player.GetComponent<Player>().getPlayerNumber() + " pressed the correct key: " + gameManager.getKeyCode(KeyType.Battle, player.GetComponent<Player>().getPlayerNumber()));
                    player.GetComponent<Player>().incrementPlayerPressCounter();
                }
                break;
        }
    }
}

public enum KeyType
{
    Draw,
    Battle
}
