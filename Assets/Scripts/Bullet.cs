using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private bool collided;
    private Enemigo enemigoScript;

    public void InitiateCollisionDetection()
    {
        collided = false;
    }

    private void Awake()
    {
        enemigoScript = FindObjectOfType<Enemigo>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collided)
        {
            if (collision.gameObject.CompareTag("Enemigo"))
            {
                collided = true;
                enemigoScript.DestruirEnemigo();
            }

            Destroy(gameObject);
        }
    }
}
