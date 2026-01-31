using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int drawCountdown = 5;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
