using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private float spawnTime;
    [SerializeField]
    private float radius = 10;
    [SerializeField]
    private float speed = 1;

    private GameObject asteroid;

    private void Start()
    {
        StartCoroutine(SpawnAsteroidCouroutine());
    }
    private IEnumerator SpawnAsteroidCouroutine()
    {
        while (true)
        {
            asteroid = AsteroidObjectPool.Instance.GetAsteroid();
            asteroid.transform.position = GetRandomPointOnCircleEdge();
            StartCoroutine(TargetMove(asteroid, new Vector3(0, 0, 0)));
            yield return new WaitForSeconds(spawnTime);
        }
    }
    private Vector3 GetRandomPointOnCircleEdge()
    {
        var vector2 = Random.insideUnitCircle.normalized * radius;
        return new Vector3(vector2.x, vector2.y, 0);
    }

    private IEnumerator TargetMove(GameObject asteroid, Vector3 targetPositon)
    {
        Vector3 startPosition = asteroid.transform.position;
        float t = 0;
        while (t < 1)
        {
            asteroid.transform.position = Vector3.Lerp(startPosition, targetPositon, t);
            t += Time.deltaTime * speed;
            yield return null;
        }

    }

    private void Update()
    {
        if (spawnTime > 0)
        {
            spawnTime -= 0.005f * Time.deltaTime;
            if (spawnTime < 0)
            {
                spawnTime = 0;
            }
        }
    }
}
