using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject PauseMenu;
    public static bool _Paused = true;
    public void Pause()
    {
        Time.timeScale = 0f;
        _Paused = true;
        PauseMenu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        StartCoroutine(FreezeTime());
    }
    public void QuitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public IEnumerator FreezeTime()
    {
        yield return new
        WaitForSeconds(3);
        MenuScript._Paused = false;
    }
    public void Retry()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }
    public void Shop()
    {
        SceneManager.LoadScene("Shop");
        Time.timeScale = 1f;
    }


}
