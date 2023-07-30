using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    [SerializeField]
    private int hitToDestroy;
    [SerializeField]
    private bool isBigAsteroid;
    [SerializeField]
    private ParticleSystem explosionEffect;

    private int collisionCounter = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            TryDestroyAsteroid();
            BulletPool.Instance.ReturnToPool(collision.gameObject);
        }
        explosionEffect.Play();
    }

    private void TryDestroyAsteroid()
    {
        if (collisionCounter < hitToDestroy)
        {
            collisionCounter++;
        }
        else
        {
            AsteroidObjectPool.Instance.ReturnToPool(gameObject);
            collisionCounter = 0;
            AudioManager.Instance.PlayDestroyEffect();
            if (isBigAsteroid == true)
            {
                CameraShookMaker.Instance.StartShook();
            }
        }
    }
}
