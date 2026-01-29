using UnityEngine;

public enum GameState
{
    Observation,
    Conversation,
    Listening,
    Speaking,
    Reacting,
    Win,
    Lose
}

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameState currentState;

    public int mistakes = 0;
    public int maxMistakes = 1;

    private void Awake()
    {
        Instance = this;
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
        Debug.Log("State changed to: " + newState);
    }

    public void RegisterMistake()
    {
        mistakes++;

        if (mistakes > maxMistakes)
        {
            ChangeState(GameState.Lose);
        }
    }
}
