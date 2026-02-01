using System.Collections;
using UnityEngine;

public class Mask : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject opponentPlayer;

    GameManager gameManager;

    [SerializeField]   
    GameObject myOpponentPosition;

    Vector3 originalPosition;

    public void pullMaskAway()
    {
        if (player.GetComponent<Player>().getPlayerNumber() == 1)
        {
            // move this mask
            StartCoroutine(Move(0.1f, true));
            // move opponent along with the mask
            StartCoroutine(MovePlayer(0.1f, true));
        }
        else
        {
            // move mask
            StartCoroutine(Move(0.1f, true));
            // move opponent along with the mask
            StartCoroutine(MovePlayer(0.1f, true));
        }
    }

    public void pullMaskTowards()
    {
        if (player.GetComponent<Player>().getPlayerNumber() == 1)
        {
            // move this mask
            StartCoroutine(Move(0.1f, false));
            // move opponent along with the mask
            StartCoroutine(MovePlayer(0.1f, false));
        }
        else
        {
            // move mask
            StartCoroutine(Move(0.1f, false));
            // move opponent along with the mask
            StartCoroutine(MovePlayer(0.1f, false));
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move(float timeToScale, bool pullAway)
    {
        int playerNumber = player.GetComponent<Player>().getPlayerNumber();
        float timer = 0f;
        while (timer < timeToScale)
        {
            if (pullAway)
            {
                float newX = playerNumber == 1 ? this.transform.position.x + gameManager.pullAwayIncrement : this.transform.position.x - gameManager.pullAwayIncrement;
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(newX, this.transform.position.y, this.transform.position.z), timeToScale);
            }
            else
            {
                float newX = playerNumber == 1 ? this.transform.position.x - gameManager.pullAwayIncrement : this.transform.position.x + gameManager.pullAwayIncrement;
                if ((playerNumber == 1 && newX <= originalPosition.x) || (playerNumber == 2 && newX >= originalPosition.x))
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(originalPosition.x, this.transform.position.y, this.transform.position.z), timeToScale);
                } else
                {
                    this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(newX, this.transform.position.y, this.transform.position.z), timeToScale);
                }
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator MovePlayer(float timeToScale, bool pullAway)
    {
        float timer = 0f;
        int playerNumber = player.GetComponent<Player>().getPlayerNumber();
        while (timer < timeToScale)
        {
            if (pullAway)
            {
                float newX = playerNumber == 1 ? opponentPlayer.transform.position.x + gameManager.pullAwayIncrement : opponentPlayer.transform.position.x - gameManager.pullAwayIncrement;
                opponentPlayer.transform.position = Vector3.MoveTowards(opponentPlayer.transform.position, new Vector3(newX, player.transform.position.y, player.transform.position.z), timeToScale);
            }
            else
            {
                float newX = playerNumber == 1 ? opponentPlayer.transform.position.x - gameManager.pullAwayIncrement : opponentPlayer.transform.position.x + gameManager.pullAwayIncrement;
                if ((playerNumber == 1 && newX <= myOpponentPosition.transform.position.x) || (playerNumber == 2 && newX >= myOpponentPosition.transform.position.x))
                {
                    opponentPlayer.transform.position = Vector3.MoveTowards(opponentPlayer.transform.position, new Vector3(myOpponentPosition.transform.position.x, player.transform.position.y, player.transform.position.z), timeToScale);
                } else
                {
                    opponentPlayer.transform.position = Vector3.MoveTowards(opponentPlayer.transform.position, new Vector3(newX, player.transform.position.y, player.transform.position.z), timeToScale);
                }
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
