using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending_Dead : MonoBehaviour
{
	//public static Ending_Dead instance;

    // 다른 스크립트 사용
	[SerializeField]
    private PlayerController thePlayerController;

    public GameObject Ending;
	//public AudioManager theAudioManager;

	//public string 브금;

	//private void Awake()
	//{
	//	if(instance == null)
	//	{
	//		DontDestroyOnLoad(this.gameObject);
	//		instance = this;
	//	}
	//	else
	//	{
	//		Destroy(this.gameObject);
	//	}
	//}

	public void Exit()
	{
		SceneManager.LoadScene("Title");
	}

	public void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void Start()
	{

	}

	void Update()
	{
		if (this.gameObject.activeInHierarchy)
		{
			// 브금 재생
		}
	}

}
