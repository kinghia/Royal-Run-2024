using UnityEngine;

public class Coin : Pickup
{
    ScoreManager scoreManager;

    void Start()
    {
        scoreManager = FindFirstObjectByType<ScoreManager>();
    }
    protected override void OnPickup()
    {
        scoreManager.IncreaseScore(100);
    }
}
