using UnityEngine;

public class EventManager
{
    public delegate void GenericEvent();

    public delegate void GameStateEvent(GameState state);

    public static event GameStateEvent changeGameStateEvent;

    public static void ChangeGameState(GameState nextState)
    {
        changeGameStateEvent?.Invoke(nextState);
    }
}
