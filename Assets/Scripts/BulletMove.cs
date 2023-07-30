using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField]
    private int moveSpeed = 3;

    private Vector3 mousePosition;

    private void OnEnable()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        transform.Translate(mousePosition * moveSpeed * Time.deltaTime);
    }
}