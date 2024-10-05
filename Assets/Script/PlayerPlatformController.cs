using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformController : MonoBehaviour
{
    private Transform platformTransform;
    private Vector3 lastPlatformPosition;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            platformTransform = collision.transform;
            lastPlatformPosition = platformTransform.position;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            Vector3 platformMovement = platformTransform.position - lastPlatformPosition;
            transform.position += platformMovement;
            lastPlatformPosition = platformTransform.position;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma"))
        {
            platformTransform = null;
        }
    }
}