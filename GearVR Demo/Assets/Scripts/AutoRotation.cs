using UnityEngine;
using System.Collections;

public class AutoRotation : MonoBehaviour {

    private Transform m_Trans;
    public float rotSpeed =2f;
   
	// Use this for initialization
	void Start ()
    {
        m_Trans = this.transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_Trans.Rotate(new Vector3(0, Time.deltaTime * rotSpeed, 0));
	}

}
