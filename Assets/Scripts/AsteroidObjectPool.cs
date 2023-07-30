using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidObjectPool : Singleton<AsteroidObjectPool>
{

    [SerializeField]
    private List<GameObject> typeAsteroid = new List<GameObject>();
    [SerializeField]
    private Vector3 objectPoolPosition;
    [SerializeField]
    private int maxSpawnAmount;
    [SerializeField]
    private List<GameObject> spawnedAsteroid = new List<GameObject>();


    private void Awake()
    {
        foreach (GameObject config in typeAsteroid)
        {
            for (int i = 0; i < maxSpawnAmount; i++)
            {
                GameObject obj = Instantiate(config, objectPoolPosition, Quaternion.Euler(new Vector3(0, 0, 0)));
                obj.SetActive(false);
                spawnedAsteroid.Add(obj);
            }
        }
    }

    public GameObject GetAsteroid()
    {
        int randomIndex = Random.Range(0, spawnedAsteroid.Count);

        GameObject obj;

        if (spawnedAsteroid.Count > 0)
        {
            obj = spawnedAsteroid[randomIndex];
            spawnedAsteroid.Remove(obj);
            obj.SetActive(true);
            return obj;
        }
        else
        {
            int randomTypeAsteroidIndex = Random.Range(0, typeAsteroid.Count);
            obj = Instantiate(typeAsteroid[randomTypeAsteroidIndex]);
            obj.SetActive(true);
            return obj;
        }
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        obj.transform.position = objectPoolPosition;
        spawnedAsteroid.Add(obj);
    }
}