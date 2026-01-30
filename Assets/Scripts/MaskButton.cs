using UnityEngine;

public class MaskButton : MonoBehaviour
{
    public MaskType responseMask;
    private ConversationManager conversationManager;

    private void Start()
    {
        //conversationManager = FindFi
    }

    public void OnClick()
    {
        // On click, send MaskType to ConversationManager
    }

    /*    MaskButton: Input for mask response
        enum MaskType
        Happy
        Sad
        Neutral
        On click, sends MaskType to ConversationManager*/
}
