using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool isGrounded;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Enter collision with:{collision.gameObject}");
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
