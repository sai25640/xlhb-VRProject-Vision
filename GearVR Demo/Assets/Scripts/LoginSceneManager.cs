﻿using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginSceneManager : MonoBehaviour
{
    [SerializeField]
    private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
    [SerializeField]private Reticle m_Reticle;
    [SerializeField]private SelectionRadial m_Radial;
    [SerializeField]private UIFader m_Fader;
    [SerializeField]private SelectionSlider m_Slider;
    [SerializeField]private string m_MenuSceneName = "VRDemo_Meditation";
    private IEnumerator Start()
    {
        m_Reticle.Show();
        m_Radial.Hide();

        yield return StartCoroutine(m_Fader.InteruptAndFadeIn());   
        yield return StartCoroutine(m_Slider.WaitForBarToFill());
        //yield return StartCoroutine(m_Fader.InteruptAndFadeOut());
        
        //SceneManager.LoadScene(m_MenuSceneName, LoadSceneMode.Single);
        SMGameEnvironment.Instance.SceneManager.LoadScreen(m_MenuSceneName);
 
    }

}
