using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int playerNumber = 1;

    [SerializeField]
    GameObject mask;

    GameManager gameManager;

    int playerPressCounter = 0;

    public int getPlayerNumber()
    {
        return playerNumber;
    }

    public int getPlayerPressCounter()
    {
        return playerPressCounter;
    }

    public void incrementPlayerPressCounter()
    {
        playerPressCounter++;
    }

    public void snapMask()
    {
        mask.GetComponent<SpringJoint2D>().enabled = true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.generateKeyCode(KeyType.Draw, playerNumber);
        gameManager.generateKeyCode(KeyType.Battle, playerNumber);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
