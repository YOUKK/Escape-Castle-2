using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject RuleUI;

    // TitleManager
    public void Play()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void Quit()
    {
        Debug.LogError("Game Ended");
        Application.Quit();
    }

    // Ending_Succes, Dead
    public void Exit()
    {
        SceneManager.LoadScene("Title");
    }
    public void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Stage Clear
    public void GoStage2()
	{
        SceneManager.LoadScene("Stage2");
    }
    public void GoStage3()
	{
        SceneManager.LoadScene("Stage3");
    }
    public void GoEnding()
	{
        SceneManager.LoadScene("Ending");
    }

    // Rule Scene
    public void Continue()
	{
        RuleUI.SetActive(false);
	}
}
