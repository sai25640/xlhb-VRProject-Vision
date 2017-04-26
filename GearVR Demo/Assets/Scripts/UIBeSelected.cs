using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;

public class UIBeSelected : MonoBehaviour
{

    [SerializeField]private VRInteractiveItem m_InterractiveItem;
    [SerializeField]private Transform m_SelectArrow;
    [SerializeField]private Transform m_TargetTransfom;
    [SerializeField]private Vector3 m_OffsetVector;

    private void OnEnable()
    {
        m_InterractiveItem.OnClick += HandleClick;
    }

    private void OnDisable()
    {
        m_InterractiveItem.OnClick -= HandleClick;
    }

    private void HandleClick()
    {
        //Debug.Log("OnClick");
        m_SelectArrow.gameObject.SetActive(true);
        m_SelectArrow.parent = m_TargetTransfom;
        m_SelectArrow.transform.localPosition = m_OffsetVector;//new Vector3(-0.8f , 1f, 0);
        //m_SelectArrow.transform.position = new Vector3(-0.8f+ m_TargetTransfom.position.x, 2.9f+m_TargetTransfom.position.y,3.5f);
    }
}
