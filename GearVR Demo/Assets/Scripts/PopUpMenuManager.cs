using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;
using System;

public class PopUpMenuManager : MonoBehaviour
{
    [SerializeField]
    private Reticle m_Reticle;
    [SerializeField]
    private SelectionRadial m_Radial;
    [SerializeField]
    private UIFader m_DotFader;
    [SerializeField]
    private SelectionSlider m_DotSlider;

    [SerializeField]
    private UIFader m_SwitchMenuFader;
    [SerializeField]
    private SelectionSlider m_SwitchMusicSlider;
    [SerializeField]
    private SelectionSlider m_SwitchSceneSlider;
    [SerializeField]
    private SelectionSlider m_HomeSlider;
    [SerializeField]
    private UIFader m_SceneItemCollectorFader;
    [SerializeField]
    private SelectionSlider[] m_SceneItemCollectorSlider;
    [SerializeField]
    private UIFader m_MusicItemCollectorFader;
    [SerializeField]
    private SelectionSlider[] m_MusicItemCollectorSlider;

    [SerializeField]
    private GameObject m_PrompMessage;

    public static bool m_GazeOver = false;
    private Coroutine m_Coroutine;

    [SerializeField]
    private AutoRotation m_AutoRotation;
    private IEnumerator Start()
    {
        m_PrompMessage.SetActive(true);
        m_Reticle.Show();
        m_Radial.Hide();
        
        yield return StartCoroutine(m_SwitchMenuFader.InteruptAndFadeOut());
        yield return StartCoroutine(m_MusicItemCollectorFader.InteruptAndFadeOut());
        yield return StartCoroutine(m_SceneItemCollectorFader.InteruptAndFadeOut());

        AudioManager.Instance.PlayBGAudio();
        m_PrompMessage.SetActive(false);

        yield return StartCoroutine(m_DotFader.InteruptAndFadeIn());    
        yield return StartCoroutine(m_DotSlider.WaitForBarToFill());
        yield return StartCoroutine(m_DotFader.InteruptAndFadeOut());

        //m_Coroutine = StartCoroutine("Timer");
        StartCoroutine("Timer");
        yield return StartCoroutine(m_SwitchMenuFader.InteruptAndFadeIn());
        //StopCoroutine(m_Coroutine); StartCoroutine("Timer");
        yield return StartCoroutine(m_SwitchMusicSlider.WaitForBarToFill());
        //StartCoroutine(m_HomeSlider.WaitForBarToFill());
        yield return StartCoroutine(m_SwitchMenuFader.InteruptAndFadeOut());

        

    }

    private IEnumerator Timer()
    {
        if(m_AutoRotation)
            m_AutoRotation.rotSpeed = 0f;
        //do
        //{
        //    Debug.Log("WaitAndPrint " + Time.time);
        //    yield return new WaitForSeconds(8f);

        //} while (m_GazeOver);
        while (m_GazeOver)
        {
            //Debug.Log("WaitAndPrint " + Time.time);
            yield return new WaitForSeconds(8f);
        }

        yield return StartCoroutine(m_SwitchMenuFader.InteruptAndFadeOut());
        yield return StartCoroutine(m_MusicItemCollectorFader.InteruptAndFadeOut());
        yield return StartCoroutine(m_SceneItemCollectorFader.InteruptAndFadeOut());

        m_PrompMessage.SetActive(false);
        if (m_AutoRotation)
            m_AutoRotation.rotSpeed = 3f;
        yield return StartCoroutine(m_DotFader.InteruptAndFadeIn());
        yield return StartCoroutine(m_DotSlider.WaitForBarToFill());
        yield return StartCoroutine(m_DotFader.InteruptAndFadeOut());

        //Coroutine coroutine = StartCoroutine("Timer");
        StartCoroutine("Timer");
        yield return StartCoroutine(m_SwitchMenuFader.InteruptAndFadeIn());
        //StopCoroutine(coroutine); StartCoroutine("Timer");
        yield return StartCoroutine(m_SwitchMusicSlider.WaitForBarToFill());
        //StartCoroutine(m_HomeSlider.WaitForBarToFill());

        
    }

    private void OnEnable()
    {
        for (int i = 0; i < m_MusicItemCollectorSlider.Length; i++)
        {
            m_MusicItemCollectorSlider[i].OnBarFilled += HandleBarFilled;
            //m_MusicItemCollectorSlider[i].
        }
        m_SwitchMusicSlider.OnBarFilled += MusicBarFilled;
        m_HomeSlider.OnBarFilled += HomeBarFilled;
        m_SwitchSceneSlider.OnBarFilled += SceneBarFilled;
    }

    private void OnDisable()
    {
        for (int i = 0; i < m_MusicItemCollectorSlider.Length; i++)
        {
            m_MusicItemCollectorSlider[i].OnBarFilled -= HandleBarFilled;
        }
        m_SwitchMusicSlider.OnBarFilled -= MusicBarFilled;
        m_HomeSlider.OnBarFilled -= HomeBarFilled;
        m_SwitchSceneSlider.OnBarFilled -= SceneBarFilled;
    }

    private void SceneBarFilled()
    {
        StopCoroutine(m_HomeSlider.WaitForBarToFill());
        StopCoroutine(m_SwitchMusicSlider.WaitForBarToFill());
        StartCoroutine("SceneItemFadeIn");
        StartCoroutine(m_SwitchMenuFader.InteruptAndFadeOut());

    }
    private void MusicBarFilled()
    {
        StopCoroutine(m_HomeSlider.WaitForBarToFill());
        StopCoroutine(m_SwitchSceneSlider.WaitForBarToFill());
        StartCoroutine("MusicItemFadeIn");
        StartCoroutine(m_SwitchMenuFader.InteruptAndFadeOut());
    }
    private void HomeBarFilled()
    {
        //SceneManager.LoadScene("VRDemo_Login", LoadSceneMode.Single);
        SMGameEnvironment.Instance.SceneManager.LoadScreen("VRDemo_Login");
    }

    private IEnumerator SceneItemFadeIn()
    {
        yield return StartCoroutine(m_SceneItemCollectorFader.InteruptAndFadeIn());
        foreach (SelectionSlider item in m_SceneItemCollectorSlider)
        {
            yield return StartCoroutine(item.WaitForBarToFill());
        }
    }
    private IEnumerator MusicItemFadeIn()
    {
        yield return StartCoroutine(m_MusicItemCollectorFader.InteruptAndFadeIn());
        foreach (SelectionSlider item in m_MusicItemCollectorSlider)
        {
            yield return StartCoroutine(item.WaitForBarToFill());
        }
    }

    private void HandleBarFilled()
    {
        foreach (SelectionSlider item in m_MusicItemCollectorSlider)
        {
            StopCoroutine(item.WaitForBarToFill());
        }
        StartCoroutine("Start");
    }

 


}
