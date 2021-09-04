using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Quit()
    {
        Debug.LogError("Game Ended");
        Application.Quit();
    }
    public void LoadRule()
    {
        Debug.Log("Rule");
        SceneManager.LoadScene("SampleScene");
    }
}
