using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] float collisionCooldown = 1f;
    [SerializeField] float adjustChangeMoveSpeedAmount = -2f;
    const string hitString = "Hit";

    LevelGenerator levelGenerator;

    void Start()
    {
        levelGenerator = FindFirstObjectByType<LevelGenerator>();    
    }

    float colldownTimer = 0f;

    void Update()
    {
        colldownTimer += Time.deltaTime;
    }

    void OnCollisionEnter(Collision other) 
    {
        if (colldownTimer < collisionCooldown) return;

        levelGenerator.ChangeChunkMoveSpeed(adjustChangeMoveSpeedAmount);
        animator.SetTrigger(hitString);
        colldownTimer = 0f;
    }
}
