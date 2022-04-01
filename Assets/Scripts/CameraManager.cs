using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager instance { get; private set; }

    private CinemachineVirtualCamera VC;

    private float targetOrthographicSize = 2f;

    private void Awake()
    {
        instance = this;
        VC = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (VC.m_Lens.OrthographicSize < targetOrthographicSize)
        {
            VC.m_Lens.OrthographicSize += (Time.deltaTime * .2f);
        }
    }

    public void ZoomOut(float increment)
    {
        targetOrthographicSize += increment;
    }
}
