using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class ConversationManager : MonoBehaviour
{
    /*    ConversationManager
            Get LevelSO from GameController
            Manages sentences
                Choose random line -> SentenceSO
                Displays to game
            Calculate result
                Send correctness to GameController
                If correct and it exceeds the level/area max, move onto the next
                If wrong, grab another line
        */

    private List<SentenceSO> excludedSentences;
    private SentenceSO currentSentence;

    private void Awake()
    {
        excludedSentences = new List<SentenceSO>();
    }

    public void randomlyChooseSentence(LevelSO level)
    {
        if (level == null)
        {
            Debug.LogError("randomlyChooseSentence called with null level.");
            return;
        }

        if (level.sentences == null || level.sentences.Count == 0)
        {
            Debug.LogWarning("Level has no sentences.");
            return;
        }

        // Filter out excluded sentences
        List<SentenceSO> availableSentences = level.sentences
            .Where(s => !excludedSentences.Contains(s))
            .ToList();

        if (availableSentences.Count == 0)
        {
            Debug.Log("No available sentences left. Clearing excluded list and retrying.");
            excludedSentences.Clear();
            availableSentences = new List<SentenceSO>(level.sentences);
        }

        int randomIndex = UnityEngine.Random.Range(0, availableSentences.Count);
        currentSentence = availableSentences[randomIndex];


        // display to screen
    }

    public void determineMaskResult(MaskType mask)
    {
        // Determine if the player's mask response is correct
        if (currentSentence.correctMask == mask)
        {
            // Correct response
            //GameController.Instance.numCorrectResponses++;
        }
        else
        {
            // Incorrect response
            excludedSentences.Add(currentSentence);
            // start randomlyChooseSentence again
        }

    }
}
