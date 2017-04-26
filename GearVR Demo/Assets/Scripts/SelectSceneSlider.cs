using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class SelectSceneSlider : MonoBehaviour
{
    //public event Action<MenuButton> OnButtonSelected;                   // This event is triggered when the selection of the button has finished.

    [SerializeField]
    private string m_SceneToLoad;                      // The name of the scene to load.
    [SerializeField]
    private VRCameraFade m_CameraFade;                 // This fades the scene out when a new scene is about to be loaded.
    [SerializeField]
    private SelectionSlider m_Slider;         // This controls when the selection is complete.
    [SerializeField]
    private VRInteractiveItem m_InteractiveItem;       // The interactive item for where the user should click to load the level.
    [SerializeField]
    private UIFader m_Fader;

    private bool m_GazeOver;                                            // Whether the user is looking at the VRInteractiveItem currently.


    private void Start()
    {
        StartCoroutine(m_Fader.InteruptAndFadeIn());
    }

    private void OnEnable()
    {
        m_InteractiveItem.OnOver += HandleOver;
        m_InteractiveItem.OnOut += HandleOut;
        m_Slider.OnBarFilled += HandleSelectionComplete;
    }


    private void OnDisable()
    {
        m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_Slider.OnBarFilled -= HandleSelectionComplete;
    }


    private void HandleOver()
    {
        // When the user looks at the rendering of the scene, show the radial.
        //m_SelectionRadial.Show();

        m_GazeOver = true;
        PopUpMenuManager.m_GazeOver = true;
        //Debug.Log("HandleOver");
        StartCoroutine(m_Slider.WaitForBarToFill());
       
        
    }


    private void HandleOut()
    {
        // When the user looks away from the rendering of the scene, hide the radial.
        //m_SelectionRadial.Hide();
        m_GazeOver = false;
        PopUpMenuManager.m_GazeOver = false;
        //Debug.Log("HandleOut");
        StopCoroutine(m_Slider.WaitForBarToFill());
        
        
    }


    private void HandleSelectionComplete()
    {      
        // If the user is looking at the rendering of the scene when the radial's selection finishes, activate the button.
        if (m_GazeOver)
            StartCoroutine(ActivateButton());

        //Debug.Log("HandleSelectionComplete");
    }

    private IEnumerator ActivateButton()
    {
        // If the camera is already fading, ignore.
        //if (m_CameraFade.IsFading)
        // yield break;

        // If anything is subscribed to the OnButtonSelected event, call it.
        // if (OnButtonSelected != null)
        //OnButtonSelected(this);
   
        // Wait for the camera to fade out.
        yield return StartCoroutine(m_CameraFade.BeginFadeOut(true));

        // Load the level.
        //SceneManager.LoadScene(m_SceneToLoad, LoadSceneMode.Single);
        SMGameEnvironment.Instance.SceneManager.LoadScreen(m_SceneToLoad);




    }
}
