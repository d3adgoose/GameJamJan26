using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum MaskType
{
    Happy,
    Sad,
    Neutral,
    None
}

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public ConversationManager conversationManager;
    public AreaSO currentArea;
    private int level = 0;
    private int numCorrectResponses = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        startLevel(level);
    }

    private void startLevel(int levelIndex)
    {
        // Load the level based on the current area and level index
        Debug.Log("Current level is " + levelIndex);
        LevelSO levelToLoad = currentArea.levels[levelIndex];
        if (levelToLoad == null) 
        {
            Debug.LogError("Level not found in current area at index: " + levelIndex);
            return;
        }

        conversationManager.setCurrentLevel(levelToLoad);
        conversationManager.startSentence();
    }

    public void checkForLevelProgression()
    {
        numCorrectResponses++;
        Debug.Log("Num correct responses is " + numCorrectResponses);

        LevelSO currentLevel = currentArea.levels[level];
        if (numCorrectResponses >= currentLevel.numCorrectResponsesToPass)
        {
            // If last level in area, load next area
            if (level == currentArea.levels.Count - 1)
            {
                Debug.Log("Loading new area ");
                SceneManager.LoadScene(currentArea.nextAreaToLoad);
                return;
            }

            // Otherwise move onto the next level in the current area
            Debug.Log("Moving onto next level");
            level++;
            numCorrectResponses = 0;
            startLevel(level);
        }
    }
}
