using UnityEngine;
using System.Collections.Generic;

public class KeyToPress : MonoBehaviour
{
    int playerNumber = 1; // Set player number here (1 or 2)
    Dictionary<KeyType, KeyCode> keyToPress = new Dictionary<KeyType, KeyCode>() { { KeyType.Draw, KeyCode.None } }; // Set the key to press here

    public void setKeyToPress(KeyType keyType, KeyCode keyToPress)
    {
        this.keyToPress = new Dictionary<KeyType, KeyCode>() { { keyType, keyToPress } };
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (keyToPress.Keys)
        {
            case var _ when keyToPress.ContainsKey(KeyType.Draw):
                Debug.Log(keyToPress[KeyType.Draw]);
                if (Input.GetKeyDown(keyToPress[KeyType.Draw]))
                {
                    Debug.Log("Player " + playerNumber + " pressed the correct key: " + keyToPress[KeyType.Draw]);
                    keyToPress.Remove(KeyType.Draw);
                    EventManager.ChangeGameState(playerNumber == 1 ? GameState.PlayerOneAttacking : GameState.PlayerTwoAttacking);
                    // Add additional logic for correct key press here
                }
                break;
            case var _ when keyToPress.ContainsKey(KeyType.Battle):
                if (Input.GetKeyDown(keyToPress[KeyType.Battle]))
                {
                    Debug.Log("Player " + playerNumber + " pressed the correct key: " + keyToPress[KeyType.Battle]);
                    // Add additional logic for correct key press here
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
