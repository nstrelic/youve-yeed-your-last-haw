using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int playerNumber = 1;

    KeyCode drawKey = KeyCode.A;
    KeyCode battleKey = KeyCode.S;

    GameManager gameManager;

    public KeyCode getDrawKey()
    {
        return drawKey;
    }

    public KeyCode getBattleKey()
    {
        return battleKey;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        drawKey = gameManager.dynamicPossibleKeyCodes[Random.Range(0, gameManager.dynamicPossibleKeyCodes.Count)];
        gameManager.dynamicPossibleKeyCodes.Remove(drawKey);
        battleKey = gameManager.dynamicPossibleKeyCodes[Random.Range(0, gameManager.dynamicPossibleKeyCodes.Count)];
        gameManager.dynamicPossibleKeyCodes.Remove(battleKey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
