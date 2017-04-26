using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class BasicMove : MonoBehaviour {

    [SerializeField]private Transform m_Boat;
    [SerializeField]private Transform m_Watch;
    [SerializeField]private Transform[] m_Cave;
    
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);

        m_Boat.DOMove(new Vector3(0, 3.3f, -7.5f), 2f).SetLoops(-1, LoopType.Yoyo);
        m_Watch.DORotate(new Vector3(0,0,45f), 4f).SetLoops(-1, LoopType.Yoyo);
        //m_Watch.DOShakeRotation(4f).SetLoops(-1, LoopType.Yoyo);

        if (SceneManager.GetActiveScene().name != "VRDemo_MeditationScene2")
        {
            m_Cave[0].DOLocalRotate(new Vector3(0, 0, 90f), 2f).SetLoops(-1, LoopType.Yoyo);
            m_Cave[1].DOLocalRotate(new Vector3(0, 0, -90f), 2f).SetLoops(-1, LoopType.Yoyo);
        }
        
    }
	

}
