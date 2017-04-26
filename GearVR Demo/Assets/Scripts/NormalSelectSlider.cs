using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class NormalSelectSlider : MonoBehaviour
{

    [SerializeField]
    private SelectionSlider m_Slider;         // This controls when the selection is complete.

    private void OnEnable()
    {
        m_Slider.OnBarFilled += HandleSelectionComplete;
    }


    private void OnDisable()
    {
        m_Slider.OnBarFilled -= HandleSelectionComplete;
    }

    private void HandleSelectionComplete()
    {
        Debug.Log(m_Slider.GetComponentInChildren<Text>().text);
        //AudioStaticScript.PlayingMusicName = m_Slider.GetComponentInChildren<Text>().text;
        AudioManager.Instance.PlayingMusicName = m_Slider.GetComponentInChildren<Text>().text;
        //m_PlayAudio.PlayMusic();
    }

}
