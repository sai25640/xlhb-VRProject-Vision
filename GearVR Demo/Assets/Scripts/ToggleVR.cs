using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class ToggleVR : MonoBehaviour
{
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            VRSettings.enabled = !VRSettings.enabled;
            Debug.Log("Changed VRSettings.enabled to: "+VRSettings.enabled);
        }
	}
}
