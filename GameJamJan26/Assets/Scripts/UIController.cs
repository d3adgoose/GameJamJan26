using System.Threading;
using UnityEngine;

public class UIController
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
