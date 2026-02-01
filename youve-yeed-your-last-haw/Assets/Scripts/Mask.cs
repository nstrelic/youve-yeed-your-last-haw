using System.Collections;
using UnityEngine;

public class Mask : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject opponentPlayer;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Move(float timeToScale, bool pullAway)
    {
        float timer = 0f;
        while (timer < timeToScale)
        {
            if (pullAway)
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.GetComponent<Player>().getPlayerNumber() == 1 ? this.transform.position.x + 1 : this.transform.position.x - 1, this.transform.position.y, this.transform.position.z), timeToScale);
            }
            else
            {
                this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(player.GetComponent<Player>().getPlayerNumber() == 1 ? this.transform.position.x - 1 : this.transform.position.x + 1, this.transform.position.y, this.transform.position.z), timeToScale);
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }

    IEnumerator MovePlayer(float timeToScale, bool pullAway)
    {
        float timer = 0f;
        while (timer < timeToScale)
        {
            if (pullAway)
            {
                opponentPlayer.transform.position = Vector3.MoveTowards(opponentPlayer.transform.position, new Vector3(opponentPlayer.GetComponent<Player>().getPlayerNumber() == 1 ? opponentPlayer.transform.position.x - 1 : opponentPlayer.transform.position.x + 1, player.transform.position.y, player.transform.position.z), timeToScale);
            }
            else
            {
                opponentPlayer.transform.position = Vector3.MoveTowards(opponentPlayer.transform.position, new Vector3(opponentPlayer.GetComponent<Player>().getPlayerNumber() == 1 ? opponentPlayer.transform.position.x + 1 : opponentPlayer.transform.position.x - 1, player.transform.position.y, player.transform.position.z), timeToScale);
            }
            timer += Time.deltaTime;
            yield return null;
        }
    }
}
