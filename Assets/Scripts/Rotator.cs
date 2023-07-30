using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float minRotateAngle;
    [SerializeField]
    private float maxRotateAngle;

    private float angle;

    private void Start()
    {
        angle = Random.Range(minRotateAngle, maxRotateAngle);
    }

    private void Update()
    {
        transform.Rotate(0, 0, angle * Time.deltaTime);
    }
}
