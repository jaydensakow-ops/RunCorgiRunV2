using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    public TMP_Text ScoreText;

    public void ShowScore()
    {
        ScoreText.text = "Score: " + ScoreKeeper.GetScore();
    }
}
