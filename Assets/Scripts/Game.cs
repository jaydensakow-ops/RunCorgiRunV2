using UnityEngine;

public class Game : MonoBehaviour
{
    public UI Ui;
    public Corgi Corgi;
    public GameTimer GameTimer;
    public BeerPlacer BeerPlacer;
    public BonePlacer BonePlacer;
    public PillPlacer PillPlacer;
    public MoonshinePlacer MoonshinePlacer;

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

    public bool IsPlaying()
    {
        return isGameRunning;
    }

    public void OnPlayButtonClicked()
    {
        Ui.HideStartScreen();
        InitializeGame();
    }
    
    public void InitializeGame()
    {
        isGameRunning = true;
        GameTimer.StartTimer(10, OnTimerDone);
        StartPlacers();
        ScoreKeeper.ResetScore();
        Ui.ResetScore();
        Corgi.Reset();
    }

    private void StartPlacers()
    {
        BeerPlacer.StartPlacing();
        BonePlacer.StartPlacing();
        PillPlacer.StartPlacing();
        MoonshinePlacer.StartPlacing();
    }
    
    private void StopPlacers()
    {
        BeerPlacer.StopPlacing();
        BonePlacer.StopPlacing();
        PillPlacer.StopPlacing();
        MoonshinePlacer.StopPlacing();
    }
    
    public void OnPlayAgainButtonClicked()
    {
        Ui.HideGameOvertScreen();
        InitializeGame();
    }

    public void OnTimerDone()
    {
        isGameRunning = false;
        Ui.ShowGameOvertScreen();
        StopPlacers();
    }
}
