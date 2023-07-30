using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayManager : Singleton<GamePlayManager>
{
    [SerializeField]
    private CanvasManager canvasManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            canvasManager.Show(true);
        }
    }

    public void OnResume()
    {
        Time.timeScale = 1;
        canvasManager.Hide();
    }

    public void LostAllLifes()
    {
        canvasManager.Show(false);
        Time.timeScale = 0;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
