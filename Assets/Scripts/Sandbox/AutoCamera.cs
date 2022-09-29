using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AutoCamera : MonoBehaviour
{
    private Transform scarletTransform;

    public CinemachineVirtualCamera cinemachineVirtual;

    void Update()
    {
        scarletTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SetCinemachine();
    }

    void SetCinemachine()
    {
        cinemachineVirtual.Follow = scarletTransform;
        cinemachineVirtual.LookAt = scarletTransform;
    }
}
