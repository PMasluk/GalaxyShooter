using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField]
    private GameObject resumeButton;
    [SerializeField]
    private GameObject restartButton;
    [SerializeField]
    private TextMeshProUGUI highScore;
    [SerializeField]
    private Timer timer;


    public void Show(bool isPause)
    {
        gameObject.SetActive(true);
        //if (isPause == true)
        //{
        //    resumeButton.SetActive(true);
        //    restartButton.SetActive(false);
        //}
        //else
        //{
        //    resumeButton.SetActive(false);
        //    restartButton.SetActive(true);
        //}
        resumeButton.SetActive(isPause);
        restartButton.SetActive(!isPause);

        highScore.gameObject.SetActive(!isPause);
        if (isPause == false)
        {
            float highScore = PlayerPrefs.GetFloat("HIGHSCORE", 0);
            if (highScore < timer.GetTimeCounter())
            {
                PlayerPrefs.SetFloat("HIGHSCORE", timer.GetTimeCounter());
            }
            this.highScore.text = "HIGHSCORE: " + PlayerPrefs.GetFloat("HIGHSCORE", 0);
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }


}
