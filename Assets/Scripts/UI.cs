using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TMP_Text ScoreText;
    public TMP_Text TimeText;
    public GameTimer GameTimer;
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup GameOverScreenCanvasGroup;

    public void ShowScore()
    {
        ScoreText.text = "Score: " + ScoreKeeper.GetScore();
    }
    
    public void ResetScore()
    {
        ScoreText.text = "Score: 0";
    }

    public void ShowTime()
    {
        TimeText.text = GameTimer.GetTimeAsString();
    }

    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
    
    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
    }
    
    public void HideGameOvertScreen()
    {
        CanvasGroupDisplayer.Hide(GameOverScreenCanvasGroup);
    }
    
    public void ShowGameOvertScreen()
    {
        CanvasGroupDisplayer.Show(GameOverScreenCanvasGroup);
    }
}
