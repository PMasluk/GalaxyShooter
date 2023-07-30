using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : Singleton<BulletPool>
{
    [SerializeField]
    private List<GameObject> spawnedBullet = new List<GameObject>();
    [SerializeField]
    private Vector3 bulletPoolPosition;
    [SerializeField]
    private int maxSpawnAmount;
    [SerializeField]
    private GameObject bullet;

    private void Awake()
    {
        for (int i = 0; i < maxSpawnAmount; i++)
        {
            GameObject bullet = Instantiate(this.bullet, bulletPoolPosition, Quaternion.identity);
            bullet.SetActive(false);
            spawnedBullet.Add(bullet);
        }
    }

    public GameObject GetBullet()
    {
        GameObject bullet;

        if (spawnedBullet.Count > 0)
        {
            bullet = spawnedBullet.FirstOrDefault();
            spawnedBullet.Remove(bullet);
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            bullet = Instantiate(this.bullet);
            bullet.SetActive(true);
            return bullet;
        }

    }
    public void ReturnToPool(GameObject bullet)
    {
        bullet.SetActive(false);
        bullet.transform.position = bulletPoolPosition;
        spawnedBullet.Add(bullet);
    }

}
