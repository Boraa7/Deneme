using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GeneralMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
        StartCoroutine(FreezeTime());

    }
    public void Quit()
    {
        Application.Quit();
    }
    public IEnumerator FreezeTime()
    {
        yield return new
        WaitForSeconds(3);
        MenuScript._Paused = false;
    }
    

}
