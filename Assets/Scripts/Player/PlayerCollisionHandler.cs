using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] Animator animator;
    const string hitString = "Hit";
    
    void OnCollisionEnter(Collision other) 
    {
        animator.SetTrigger(hitString);
    }
}
