using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LostLife : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> tankList = new List<GameObject>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        tankList.LastOrDefault().SetActive(false);
        tankList.Remove(tankList.LastOrDefault());
        CameraShookMaker.Instance.StartShook();
        MarsShookMaker.Instance.StartMarsShook();
        AsteroidObjectPool.Instance.ReturnToPool(collision.gameObject);
        
        if (tankList.Count == 0)
        {
            GamePlayManager.Instance.LostAllLifes();
        }
    }
}
