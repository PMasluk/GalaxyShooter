using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private float timeCounter;
    [SerializeField]
    private TextMeshProUGUI timerText;

    private void Update()
    {
        timeCounter += Time.deltaTime;
        timeCounter = Mathf.Round(timeCounter * 100f) / 100f;
        timerText.text = timeCounter.ToString();
    }

    public float GetTimeCounter()
    {
        return timeCounter;
    }
}
