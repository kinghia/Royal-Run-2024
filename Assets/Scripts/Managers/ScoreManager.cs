using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    
    int score = 0;

    public void IncreaseScore(int amout)
    {
        score += amout;
        scoreText.text = score.ToString();
    }
}
