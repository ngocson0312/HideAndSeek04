using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CamZoomVir : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera virtualCamera;
    public float zoomOut = 8f;
    public float zoomInMax = 4f;
    static float t = 0f;


    private void LateUpdate()
    {
        if (GameManager.instance.zoomCam == true)
        {
            
            StartCoroutine(TimeZoomOut());
        }
    }


    IEnumerator Lerp(float start, float end)
    {
        t = 0f;
        while(virtualCamera.m_Lens.OrthographicSize != end)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(start, end, t);
            t += Time.deltaTime*0.1f;
            yield return null;
        }
        yield return null;
    }

    IEnumerator Lerp01(float start, float end)
    {
        while (virtualCamera.m_Lens.OrthographicSize != end)
        {
            virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(start, end, 0.05f);

            yield return null;
        }
        yield return null;
    }

    IEnumerator TimeZoomOut()
    {
        StartCoroutine(Lerp(virtualCamera.m_Lens.OrthographicSize, zoomInMax));
        yield return new WaitForSeconds(3f);
        
        StartCoroutine(Lerp01(virtualCamera.m_Lens.OrthographicSize, zoomOut));
        GameManager.instance.zoomCam = false;
    }
}
