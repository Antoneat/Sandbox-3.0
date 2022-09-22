using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using System;

public class CameraConfig : MonoBehaviour
{
    [Header("General")]
    public Transform cameraTransform;
    public CinemachineVirtualCamera cinemachineVirtualCamera;

    [Header("Textos")]
    public TMP_Text text_X;
    public TMP_Text text_Y;
    public TMP_Text text_Z;
    public TMP_Text text_FOV;
    
    [Header("Rotación")]
    public float x;
    public float y;
    public float z;

    [Header("FOV")]
    public float FOV;

    void Start()
    {
        //cameraTransform = GetComponent<Transform>();
        //mainCamera = GetComponent<Camera>();

        text_X.text = "X:" + cameraTransform.position.x;
        text_Y.text = "Y:" + cameraTransform.position.y;
        text_Z.text = "Z:" + cameraTransform.position.z;

        text_FOV.text = "FOV:" + cinemachineVirtualCamera.m_Lens.FieldOfView;
    }

    public void ChangePosX(string posX)
    {
        int posXNew = Int32.Parse(posX);
        x = posXNew;

        text_X.text = "X:" + posX;

        cameraTransform.eulerAngles = new Vector3(posXNew, y, z);
    }
    
    public void ChangePosY(string posY)
    {
        int posYNew = Int32.Parse(posY);
        x = posYNew;

        text_Y.text = "Y:" + posY;

        cameraTransform.eulerAngles = new Vector3(x, posYNew, z);
    }
    
    public void ChangePosZ(string posZ)
    {
        int posZNew = Int32.Parse(posZ);
        x = posZNew;

        text_Z.text = "Z:" + posZ;

        cameraTransform.eulerAngles = new Vector3(x, y, posZNew);
    }
    public void ChangeFOVCamara(string FOVCamara)
    {
        int FOVCamaraNew = Int32.Parse(FOVCamara);

        cinemachineVirtualCamera.m_Lens.FieldOfView = FOVCamaraNew;
        text_FOV.text = "#:" + FOVCamara;
    }

}
