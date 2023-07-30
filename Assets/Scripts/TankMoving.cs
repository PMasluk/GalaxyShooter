using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoving : MonoBehaviour
{
    private Transform tankTransform;
    private Camera gameCamera;
    
    private void Start()
    {
        tankTransform = this.transform;
        gameCamera = Camera.main;
    }
    private void LookAtMouse()
    {
        Vector2 direction = gameCamera.ScreenToWorldPoint(Input.mousePosition) - tankTransform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
        tankTransform.rotation = rotation;
    }

    private void Update()
    {
        LookAtMouse();
    }

}
