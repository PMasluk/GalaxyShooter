﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarsShookMaker : Singleton<MarsShookMaker>
{
    [SerializeField]
    private float shookTime;
    [SerializeField]
    private float pingPongLength;

    private Vector3 startPosition;
    private void Awake()
    {
        startPosition = transform.position;
    }

    public void StartMarsShook()
    {
        StartCoroutine(ShookMarsMove());
        AudioManager.Instance.PlayDestroyEffect();
    }
    private IEnumerator ShookMarsMove()
    {
        float counter = 0;
        while (counter < shookTime)
        {
            float pingPong = Mathf.PingPong(Time.time, pingPongLength);
            transform.position = new Vector3(startPosition.x - pingPong, startPosition.y + pingPong, startPosition.z);
            counter += Time.deltaTime;
            yield return null;
        }
    }
}
