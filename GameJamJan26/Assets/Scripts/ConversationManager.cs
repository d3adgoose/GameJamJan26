using System;
using System.Linq;
using UnityEngine;

public class ConversationManager
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
        // Start managing the conversation for the given level
        List<SentenceSO> availableSentences = level.sentences.Where(l => !excluded.Any(e => l.Contains(e)));
        int randomIndex = UnityEngine.Random.Range(0, availableSentences.Count);
        SentenceSO chosenSentence = level.sentences[randomIndex];

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
