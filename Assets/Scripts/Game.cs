using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    public GameTimer GameTimer;

    private bool isGameRunning = false;

    public void Start()
    {
        Ui.HideGameOvertScreen();
        Ui.ShowStartScreen();
    }
    public void Update()
    {
        if (isGameRunning)
        {
            Ui.ShowTime();
        }
    }

    public void OnPlayButtonClicked()
    {
        isGameRunning = true;
        Ui.HideStartScreen();
        GameTimer.StartTimer(10, OnTimerDone);
    }

    public void OnPlayAgainButtonClicked()
    {
        
    }

    public void OnTimerDone()
    {
        isGameRunning = false;
        Ui.ShowGameOvertScreen();
    }
}
