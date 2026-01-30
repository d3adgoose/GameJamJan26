using UnityEngine;

public class MaskButton : MonoBehaviour
{
    public MaskType responseMask;
    private ConversationManager conversationManager;

    private void Start()
    {
        conversationManager = FindFirstObjectByType<ConversationManager>();
        if (conversationManager == null)
            Debug.LogError("ConversationManager not found in the scene.");
    }

    public void OnClick()
    {
        conversationManager.determineMaskResult(responseMask);
    }

    /*    MaskButton: Input for mask response
        enum MaskType
        Happy
        Sad
        Neutral
        On click, sends MaskType to ConversationManager*/
}
