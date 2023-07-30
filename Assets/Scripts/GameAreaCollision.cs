using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAreaCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletPool.Instance.ReturnToPool(collision.gameObject);
    }
}
