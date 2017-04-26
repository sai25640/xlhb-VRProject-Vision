using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class UIEvent : MonoBehaviour {

    [SerializeField]private VRInteractiveItem m_Item;
    [SerializeField]private Animator m_Ani;

	void Update ()
    {
        if (m_Item.IsOver)
        {
            Debug.Log("m_Item.IsOver");
            m_Ani.Play("ShinyUI");

        }
        else
        {
            Debug.Log("m_Item.IsOut");
            m_Ani.Stop();
 
        }
            

    }
}
