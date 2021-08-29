using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending_Dead : MonoBehaviour
{
    // 다른 스크립트 사용
	[SerializeField]
    private PlayerController thePlayerController;

    public GameObject Ending;
    //public AudioManager theAudioManager;

	//public string 브금;

	public void Exit()
	{
        Application.Quit();
	}

	private void Start()
	{

	}

	void Update()
	{
		if (this.gameObject.activeInHierarchy)
		{

		}
	}

}
