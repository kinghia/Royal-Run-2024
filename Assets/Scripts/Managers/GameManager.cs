using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameOverText;
    //[SerializeField] GameObject againButton;
    [SerializeField] float startTime = 5f;

    float timeRight;
    bool gameOver = false;

    public bool GameOver => gameOver;

    void Start()
    {
        timeRight = startTime;
    }

    void Update()
    {
        if (gameOver) return;

        timeRight -= Time.deltaTime;
        timeText.text = timeRight.ToString("F1");

        if (timeRight <= 0f)
        {
            PlayerGameOver();
        }
    }

    public void IncreaseTime(float amount)
    {
        timeRight += amount;
    }

    void PlayerGameOver()
    {
        gameOver = true; 
        playerController.enabled = false;
        gameOverText.SetActive(true);
        //againButton.SetActive(true);
        Time.timeScale = .1f;
    }
}
