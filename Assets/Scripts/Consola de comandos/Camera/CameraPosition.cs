using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using System;

public class CameraPosition : MonoBehaviour
{
    [Header("General")]
    public Transform cameraTransform;
    public CinemachineVirtualCamera cinemachineVirtualCamera;

    [Header("Textos")]
    public TMP_Text text_Xpos;
    public TMP_Text text_Ypos;
    public TMP_Text text_Zpos;

    [Header("Posción")]
    private float xPos;
    private float yPos;
    private float zPos;

    void Start()
    {
        text_Xpos.text = "X:" + cameraTransform.position.x;
        text_Ypos.text = "Y:" + cameraTransform.position.y;
        text_Zpos.text = "Z:" + cameraTransform.position.z;
    }

    #region Position X

    public void MasUnoPosX()
    {
        xPos++;
        text_Xpos.text = "X:" + xPos;

        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(xPos, yPos, zPos);
    }
    public void ChangePosX(string posX)
    {
        int posXNew = Int32.Parse(posX);
        xPos = posXNew;

        text_Xpos.text = "X:" + posX;

        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(posXNew, yPos, zPos);
    }


    #endregion

    public void ChangePosY(string posY)
    {
        int posYNew = Int32.Parse(posY);
        yPos = posYNew;

        text_Ypos.text = "Y:" + posY;

        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(xPos, posYNew, zPos);
    }
    
    public void ChangePosZ(string posZ)
    {
        int posZNew = Int32.Parse(posZ);
        zPos = posZNew;

        text_Zpos.text = "Z:" + posZ;

        cinemachineVirtualCamera.GetCinemachineComponent<CinemachineTransposer>().m_FollowOffset = new Vector3(xPos, yPos, posZNew);
    }
}
