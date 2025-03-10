﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name; // 사운드의 이름

    public AudioClip clip; // 사운드 파일
    private AudioSource source; // 사운드 플레이어

    public float Volumn;
    public bool loop;
   // public float Blend;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.loop = loop;
        source.volume = Volumn;
        //source.spatialBlend = Blend;
    }

    public void SetVolumn()
    {
        source.volume = Volumn;
    }

    public void Play()
    {
        if (source != null)
        {
            source.Play();
        }
    }

    public void Stop()
    {
        source.Stop();
    }

    public void SetLoop()
    {
        source.loop = true;
    }

 //   public void SetSpatialBlend()
	//{
 //       source.spatialBlend = 1;
	//}

    public void SetLoopCancel()
    {
        source.loop = false;
    }
}


public class AudioManager : MonoBehaviour
{

    static public AudioManager instance;

    [SerializeField]
    public Sound[] sounds;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    void Start()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            GameObject soundObject = new GameObject("사운드 파일 이름 : " + i + " = " + sounds[i].name);
            sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform);
        }
    }

    public void Play(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Play();
                return;
            }
        }
    }

    public void Stop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Stop();
                return;
            }
        }
    }

    public void SetLoop(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].SetLoop();
                return;
            }
        }
    }

    public void SetLoopCancel(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].SetLoopCancel();
                return;
            }
        }
    }

    public void SetVolumn(string _name, float _Volumn)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Volumn = _Volumn;
                sounds[i].SetVolumn();
                return;
            }
        }
    }

 //   public void SetBlend(string _name)
	//{
 //       for (int i = 0; i < sounds.Length; i++)
 //       {
 //           if (_name == sounds[i].name)
 //           {
 //               sounds[i].SetSpatialBlend();
 //               return;
 //           }
 //       }
 //   }
}
