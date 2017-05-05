using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : GenericSingletonClass<AudioManager>
{
        
    private static AudioSource m_AudioSoure;
    private Dictionary<string, AudioClip> m_SoundDictionary= new  Dictionary<string, AudioClip>();

    private  string s_PlayingMusicName;
    private static AudioClip s_PlayingMusic;
    private GameObject m_PlayingMusic;
    //private static ENUM_MUSIC_LIST 

    //void Start()
    //{
    //    print("Start + LoadAllMusics");
    //    LoadAllMusics();
    //    this.gameObject.AddComponent<AudioSource>();
    //    m_AudioSoure = GetComponent<AudioSource>();
    //}

    //º”‘ÿ“Ù¿÷
    public  void LoadAllMusics()
    {
        //Debug.Log(" Resources.LoadAll<AudioClip>()");
        AudioClip[] audioArray = Resources.LoadAll<AudioClip>("Musics");
        foreach (AudioClip item in audioArray)
        {
            m_SoundDictionary.Add(item.name, item);
            Debug.Log("º”‘ÿ“Ù¿÷ : " + item.name);
        }
    }

     //≤•∑≈±≥æ∞“Ù¿÷
    public void PlayBGAudio()
    {
        //try
        //{
        //    print("PlayBGAudio:" + s_PlayingMusicName);
        //    if (m_PlayingMusic)
        //    {
        //        Destroy(m_PlayingMusic);
        //    }
        //    //if (m_SoundDictionary.ContainsKey(s_PlayingMusicName))
        //    {
        //        //m_AudioSoure.clip = m_SoundDictionary[s_PlayingMusicName];
        //        //m_AudioSoure.Play();
        //        //m_AudioSoure.loop = true;
        //        m_PlayingMusic = Instantiate(Resources.Load("Musics/" + s_PlayingMusicName)) as GameObject;
        //    }
        //}
        //catch (System.ArgumentNullException ex)
        //{
        //    Debug.Log(ex.Message);
        //}
        //catch (System.ArgumentException ex)
        //{
        //    Debug.Log(ex.Message);
        //}
        StartCoroutine("PlayBGAudio_IE");
    }
    
    IEnumerator PlayBGAudio_IE()
    {
        print("PlayBGAudio:" + s_PlayingMusicName);
        if (m_PlayingMusic)
        {
            Destroy(m_PlayingMusic);
        }
        //if (m_SoundDictionary.ContainsKey(s_PlayingMusicName))
        {
            //m_AudioSoure.clip = m_SoundDictionary[s_PlayingMusicName];
            //m_AudioSoure.Play();
            //m_AudioSoure.loop = true;
            m_PlayingMusic = Instantiate(Resources.Load("Musics/" + s_PlayingMusicName)) as GameObject;
        }
        yield return null;
    }

    public void PauseBGAudio()
    {
        try
        {
            if (m_AudioSoure)
            {
                m_AudioSoure.Pause();
            }
        }
        catch (System.ArgumentNullException ex)
        {

            Debug.Log(ex.Message);
        }

    }
        public  string PlayingMusicName
        {
            get
            {
                 return s_PlayingMusicName;
            }
            set
            {
                s_PlayingMusicName = value;
            }
    }
}
