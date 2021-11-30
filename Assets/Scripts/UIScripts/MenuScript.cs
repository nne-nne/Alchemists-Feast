using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{

    public GameObject menuCanvas;
    public GameObject pauseCanvas;
    //public GameObject pauseButtonCanvas;
    public GameObject endCanvas;
    public GameObject winText;
    public GameObject loseText;
    public GameObject video;

    private void HideMenu()
    {
        menuCanvas.gameObject.SetActive(false);
    }

    private void HidePause()
    {
        pauseCanvas.gameObject.SetActive(false);
    }

    private void ShowPause()
    {
        pauseCanvas.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        menuCanvas.gameObject.SetActive(true);
        HidePause();
        endCanvas.gameObject.SetActive(false);
        video.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        menuCanvas.gameObject.SetActive(true);
        HidePause();
        endCanvas.gameObject.SetActive(false);
    }

    public void ResumeGame()
    {
        HidePause();
    }

    public void StartGame()
    {
        Debug.Log("start");
        HideMenu();
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        ShowPause();
    }

    public void HideAll()
    {
        HidePause();
        HideMenu();
        endCanvas.gameObject.SetActive(false);
    }

    public void WinGame(bool val)
    {
        if (val)
        {
            winText.gameObject.SetActive(true);
            loseText.gameObject.SetActive(false);
        }
        else
        {
            winText.gameObject.SetActive(false);
            loseText.gameObject.SetActive(true);
        }
        endCanvas.gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
        else if (Input.GetKey(KeyCode.Return))
            WinGame(true);
        else if (Input.GetKey(KeyCode.Backspace))
            WinGame(false);
    }

    public void EndGame()
    {
        HideAll();
        Destroy(endCanvas);
        //MusicManager.instance.Stop();
        video.gameObject.SetActive(true);
        Debug.Log("Ending");
    }

    public void QuitGame()
    {
        Debug.Log("Quittig");
        Application.Quit();
    }
}
