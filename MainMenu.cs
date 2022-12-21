using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Debug.Log("Game Quitted");
        Application.Quit();
    }
    public void OpenDISCORD()
    {
        Application.OpenURL("https://discord.gg/WehqBspD7Q");
    }
    public void OpenIG()
    {
        Application.OpenURL("https://www.instagram.com/agrivilledevs/?hl=en-gb");
    }
    public void OpenYOUTUBE()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=ujHOQxPHINA");
    }
    public void OpenTikTok()
    {
        Application.OpenURL("https://www.tiktok.com/@agriville");
    }
}
