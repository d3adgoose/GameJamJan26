using System.Timers;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    public GameObject pauseMenu;
    public Timer responseTimer;

    /*    
    UIController
        Menus
        SpeechBubble
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
}
