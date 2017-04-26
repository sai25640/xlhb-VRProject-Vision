using UnityEngine;
using System.Collections;
using UnityEngine.VR;

public class VerificationDevice : MonoBehaviour {

    private string deviceID;
    private GUIStyle style = new GUIStyle();

    void Start()
    {
        deviceID = SystemInfo.deviceUniqueIdentifier;
        //Debug.Log(deviceID);
        deviceID = MD5Encryption.Hash(deviceID);
        //Debug.Log(deviceID);
    }

    
    void OnGUI()
    { 
        if(deviceID != "fc68e1c087d02e5567bcf4374bc01839")
        {
            style.fontSize = 20;
            GUI.Label(new Rect(Screen.width/2-100, Screen.height/2-30, 300, 30), "抱歉，你使用的是未授权设备!", style);
        }       
       
    }
}
