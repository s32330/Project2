using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    public GroundChecker groundChecker;
    public Rigidbody2D rb;
    public PlayerHealth health;
    [SerializeField] private Animator animator;  
    [SerializeField] private PlayerController movement;
    [SerializeField] private string isMovingParameterName = "IsMoving";
    [SerializeField] private string isGroundedParameterName = "IsGrounded";
    [SerializeField] private string isFallingParameterName = "IsFalling";
    [SerializeField] private string isHurtingParameterName = "IsHurting";
    [SerializeField] private string isDeadParameterName = "IsDead";

    int _isMovingHash;
    int _isGroundedHash;
    int _isFallingHash;
    int _isHurtingHash;
    int _isDeadHash;

    private void Start()
    {
        _isMovingHash = Animator.StringToHash(isMovingParameterName);
        _isGroundedHash = Animator.StringToHash(isGroundedParameterName);
        _isFallingHash = Animator.StringToHash(isFallingParameterName);
        _isHurtingHash = Animator.StringToHash(isHurtingParameterName);
        _isDeadHash = Animator.StringToHash(isDeadParameterName);
    }

    private void Update()
    {
        animator.SetBool(_isMovingHash, movement.IsMoving());
        animator.SetBool(_isGroundedHash, groundChecker.IsGrounded());

        bool isFalling = rb.velocity.y < -0.01f;
        animator.SetBool(_isFallingHash, isFalling);

        //animator.SetBool(_isDeadHash, health.IsDead());

        //bool isHurting;
        //animator.SetBool(_isHurtingHash, health.TakeDamage(damage));
    }

}
