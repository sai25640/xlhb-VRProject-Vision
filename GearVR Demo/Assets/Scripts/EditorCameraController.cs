using UnityEngine;
using System.Collections;

public class EditorCameraController : MonoBehaviour {

    private Transform m_Transform;
    private float m_AnglesZ;
    private float m_AnglesY;
    private float m_AnglesX;
    public float m_MoveSpeed =0.05f;

	// Use this for initialization
	void Start ()
    {
        if (Application.platform != RuntimePlatform.WindowsEditor)
        {
            this.enabled = false;
            return;
        }

        m_Transform = this.transform;
        m_AnglesZ = m_Transform.eulerAngles.z;
        m_AnglesY = m_Transform.eulerAngles.y;
        m_AnglesX = m_Transform.eulerAngles.x;
        Cursor.visible = false;
        
	}
	
	// Update is called once per frame
	void Update () {

        if(!Input.GetKey(KeyCode.LeftAlt) && !Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.visible = true;
            
            return;
        }

        float horizontal = Input.GetAxis("Horizontal") * m_MoveSpeed;
        float vertical = -Input.GetAxis("Vertical") * m_MoveSpeed;

        if (Input.GetKey(KeyCode.LeftAlt))
        {
            Cursor.visible =false;
            m_AnglesZ = 0;
            m_AnglesY += horizontal;
            m_AnglesX += vertical;
        }
        else if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.visible = false;

            m_AnglesZ -= horizontal;
        }
     

        m_Transform.eulerAngles = new Vector3(m_AnglesX, m_AnglesY, m_AnglesZ);
    }

}
