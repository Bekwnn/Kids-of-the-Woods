using UnityEngine;
using System.Collections;

/// <summary>
/// Handles animations and animation requests sent by other unit components.
/// </summary>
public class KUnitAnimations : MonoBehaviour {
    public Animator animator;
    Vector3 positionLastFrame;

    void Update()
    {
        animator.SetFloat("movespeed", Vector3.Distance(positionLastFrame, transform.position)* 1f/Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Z))
            CancelAttack();

        positionLastFrame = transform.position;
    }

    void Reset()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
    }
    
    public void StartAttack()
    {
        animator.SetTrigger("start attack");
    }
    
    public void CancelAttack()
    {
        animator.ResetTrigger("start attack");
        animator.SetTrigger("cancel attack");
    }

    public void StartGather()
    {
        animator.SetTrigger("start attack");
    }

    public void CancelGather()
    {
        animator.ResetTrigger("start attack");
        animator.SetTrigger("cancel attack");
    }
}
