using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;

    public Animator animator;

    private Vector3 direction;

    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontal, vertical);

        AnimateMovement(direction);
    }

    private void FixedUpdate()
    {
        transform.position += speed * Time.deltaTime * direction.normalized;
    }

    void AnimateMovement(Vector3 direction)
    {
        if (animator == null)
        {
            return;
        }

        if (direction.magnitude > 0)
        {
            animator.SetBool("isMoving", true);

            animator.SetFloat("horizontal", direction.x);
            animator.SetFloat("vertical", direction.y);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }
}
