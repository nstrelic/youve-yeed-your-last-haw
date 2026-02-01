using System.Collections;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Arm : MonoBehaviour
{
    [SerializeField]
    GameObject positionToMove;

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
        int playerNumber = transform.parent.gameObject.transform.parent.gameObject.GetComponent<Player>().getPlayerNumber();
        switch (nextState) 
        {
            case GameState.PlayerOneAttacking:
                // rotate arm.
                if (playerNumber == 1)
                {
                    StartCoroutine(MoveArm(0.1f, playerNumber));
                    StartCoroutine(MovePlayer(0.1f, playerNumber));
                }
                // bring hand to opponent mask
                break;
            case GameState.PlayerTwoAttacking:
                if (playerNumber == 2)
                {
                    StartCoroutine(MoveArm(0.1f, playerNumber));
                    StartCoroutine(MovePlayer(0.1f, playerNumber));
                }
                break;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveArm(float timeToScale, int playerNumber)
    {
        GameObject shoulder = transform.parent.gameObject;
        float timer = 0f;
        while (timer < timeToScale)
        {
            
            shoulder.transform.localRotation = Quaternion.Slerp(shoulder.transform.localRotation, Quaternion.Euler(0, 0, playerNumber == 1 ? 90 : -90), timeToScale);
            timer += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator MovePlayer(float timeToScale, int playerNumber)
    {
        GameObject player = transform.parent.gameObject.transform.parent.gameObject;
        float timer = 0f;
        while (timer < timeToScale)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(positionToMove.transform.position.x, player.transform.position.y, player.transform.position.z), timeToScale);
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
