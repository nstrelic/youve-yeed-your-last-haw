using UnityEngine;
using System.Linq;

public class KeyToPress : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject mask;
    [SerializeField]
    GameObject opponentsMask;

    GameManager gameManager;

    [SerializeField]
    Sprite[] keySprites;

    private void displayKey(KeyCode keyCode)
    {
        string keyName = keyCode.ToString();
        Sprite sprite = keySprites.FirstOrDefault(s => s.name == keyName);
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sprite;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        keySprites = Resources.LoadAll<Sprite>("KeySprites");
    }

    // Update is called once per frame
    void Update()
    {
        switch(gameManager.getCurrentGameState())
        {
            case GameState.Draw:
                displayKey(gameManager.getKeyCode(KeyType.Draw, player.GetComponent<Player>().getPlayerNumber()));
                if (Input.GetKeyDown(gameManager.getKeyCode(KeyType.Draw, player.GetComponent<Player>().getPlayerNumber())))
                {
                    Debug.Log("Player " + player.GetComponent<Player>().getPlayerNumber() + " pressed the correct key: " + gameManager.getKeyCode(KeyType.Draw, player.GetComponent<Player>().getPlayerNumber()));
                    EventManager.ChangeGameState(player.GetComponent<Player>().getPlayerNumber() == 1 ? GameState.PlayerOneAttacking : GameState.PlayerTwoAttacking);
                }
                break;
            case GameState.PlayerOneAttacking:
                displayKey(gameManager.getKeyCode(KeyType.Battle, player.GetComponent<Player>().getPlayerNumber()));
                if (Input.GetKeyDown(gameManager.getKeyCode(KeyType.Battle, player.GetComponent<Player>().getPlayerNumber())))
                {
                    Debug.Log("Player " + player.GetComponent<Player>().getPlayerNumber() + " pressed the correct key: " + gameManager.getKeyCode(KeyType.Battle, player.GetComponent<Player>().getPlayerNumber()));
                    if (player.GetComponent<Player>().getPlayerNumber() == 1)
                    {
                        opponentsMask.GetComponent<Mask>().pullMaskAway();
                    } else
                    {
                        mask.GetComponent<Mask>().pullMaskTowards();
                    }
                    player.GetComponent<Player>().incrementPlayerPressCounter();
                }
                break;
            case GameState.PlayerTwoAttacking:
                displayKey(gameManager.getKeyCode(KeyType.Battle, player.GetComponent<Player>().getPlayerNumber()));
                if (Input.GetKeyDown(gameManager.getKeyCode(KeyType.Battle, player.GetComponent<Player>().getPlayerNumber())))
                {
                    Debug.Log("Player " + player.GetComponent<Player>().getPlayerNumber() + " pressed the correct key: " + gameManager.getKeyCode(KeyType.Battle, player.GetComponent<Player>().getPlayerNumber()));
                    if (player.GetComponent<Player>().getPlayerNumber() == 2)
                    {
                        opponentsMask.GetComponent<Mask>().pullMaskAway();
                    }
                    else
                    {
                        mask.GetComponent<Mask>().pullMaskTowards();
                    }
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
