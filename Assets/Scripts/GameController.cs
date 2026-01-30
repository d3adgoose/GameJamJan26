using UnityEngine;

public enum MaskType
{
    Happy,
    Sad,
    Neutral
}

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public ConversationManager conversationManager;
    public AreaSO currentArea;
    private int level = 0;
    private int numCorrectResponses = 0;

    /*    GameController: State and progression
    Tracks conversation state
        enum gameState
        Speaking
        Response
    Tracks area and level state
        List of AreaSOs
        int level
        LevelController levelController
        Timer responseTime
    Tracks correct response
        int numCorrectResponses
        UnityEvent wasCorrectMaskResponse
*/

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
        loadLevel(level);
    }

    private void loadLevel(int levelIndex)
    {
        // Load the level based on the current area and level index
        LevelSO levelToLoad = currentArea.levels[levelIndex];
        conversationManager.randomlyChooseSentence(levelToLoad);
    }

    /*   
       High Level:  Sentence is given to player ? Player Responds with their mask to their NPC ? Correctness check ? Level result(continue/win/lose)
       Sentence is given to player
           X symbols displayed in a text bubble
           Preset sentences that are randomly grabbed
       Reply timer starts
           Make a bit longer, not stressful
       Player responds
           UI appears automatically
       Level result
           Loss ? players answers incorrectly
           Continue ? new sentence(back to number 1)
           Win ? 3 correct answers
               Go to next level/area if X levels completed
    */

}
