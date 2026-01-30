using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    [Header("Timer UI")]
    public Slider timerSlider;

    [Header("Timer Settings")]
    public float responseTime = 5f;

    private Coroutine timerCoroutine;

    private List<SentenceSO> excludedSentences;
    private SentenceSO currentSentence;
    private LevelSO currentLevel;

    private void Awake()
    {
        excludedSentences = new List<SentenceSO>();

        // Initialize timer UI safely
        if (timerSlider != null)
        {
            timerSlider.maxValue = responseTime;
            timerSlider.value = responseTime;
        }
        else
        {
            Debug.LogWarning("ConversationManager: timerSlider is not assigned in the Inspector.");
        }
    }

    public void setCurrentLevel(LevelSO level)
    {
        currentLevel = level;
        excludedSentences.Clear();

        StopTimer(); // safety case
    }

    public void startSentence()
    {
        if (currentLevel == null)
        {
            Debug.LogError("startSentence called with null level.");
            return;
        }

        if (currentLevel.sentences == null || currentLevel.sentences.Count == 0)
        {
            Debug.LogWarning("Level has no sentences.");
            return;
        }

        // Filter out excluded sentences
        List<SentenceSO> availableSentences = currentLevel.sentences
            .Where(s => !excludedSentences.Contains(s))
            .ToList();

        // If all sentences are excluded, reset the excluded list
        if (availableSentences.Count == 0)
        {
            Debug.Log("No available sentences left. Clearing excluded list and retrying.");
            excludedSentences.Clear();
            availableSentences = new List<SentenceSO>(currentLevel.sentences);
        }

        int randomIndex = Random.Range(0, availableSentences.Count);
        currentSentence = availableSentences[randomIndex];

        if (currentSentence == null)
        {
            Debug.LogError("Chosen sentence is null.");
            return;
        }

        Debug.Log("Chosen Sentence: " + currentSentence.correctMask);

        // display to screen
        // timer
        
        // Start / restart the response timer
        StartTimer();
    }

    private void StartTimer()
    {
        StopTimer(); // prevent multiple timers running at once

        if (timerSlider != null)
        {
            timerSlider.maxValue = responseTime;
            timerSlider.value = responseTime;
        }

        timerCoroutine = StartCoroutine(ResponseTimerRoutine());
    }

    private void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }

    private IEnumerator ResponseTimerRoutine()
    {
        float remainingTime = responseTime;

        while (remainingTime > 0f)
        {
            remainingTime -= Time.unscaledDeltaTime;

            if (timerSlider != null)
            {
                timerSlider.value = Mathf.Max(0f, remainingTime);
            }

            yield return null;
        }

        // Mark coroutine as finished before calling the result handler
        // timer finished
        timerCoroutine = null;

        // Time out means: player gave no mask response
        determineMaskResult(MaskType.None);
    }

    public void determineMaskResult(MaskType mask)
    {
        // If the player answered, stop the timer immediately
        StopTimer();

        if (currentSentence == null)
        {
            Debug.LogWarning("determineMaskResult called but currentSentence is null.");
            return;
        }
        // Determine if the player's mask response is correct
        if (currentSentence.correctMask == mask)
        {
            Debug.Log("Correct choice");
            // Correct response
            excludedSentences.Add(currentSentence);
            GameController.Instance.checkForLevelProgression();
        }
        else
        {
            Debug.Log("Wrong choice, you picked " + mask + " when it was " + currentSentence.correctMask);
            // Incorrect response 
            startSentence();
        }
    }
}
