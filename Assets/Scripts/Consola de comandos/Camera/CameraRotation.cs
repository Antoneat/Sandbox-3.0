using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using System;

public class CameraRotation : MonoBehaviour
{
    [Header("General")]
    public Transform cameraTransform;
    public CinemachineVirtualCamera cinemachineVirtualCamera;

    [Header("Textos")]
    public TMP_Text text_Xrot;
    public TMP_Text text_Yrot;
    public TMP_Text text_Zrot;

    [Header("Rotación")]
    private float xRot;
    private float yRot;
    private float zRot;

    void Start()
    {
        text_Xrot.text = "X:" + cameraTransform.eulerAngles.x;
        text_Yrot.text = "Y:" + cameraTransform.eulerAngles.y;
        text_Zrot.text = "Z:" + cameraTransform.eulerAngles.z;
    }

    public void ChangeRotX(string rotX)
    {
        int rotXNew = Int32.Parse(rotX);
        xRot = rotXNew;

        text_Xrot.text = "X:" + rotX;

        cameraTransform.eulerAngles = new Vector3(rotXNew, yRot, zRot);
    }

    public void ChangeRotY(string rotY)
    {
        int rotYNew = Int32.Parse(rotY);
        yRot = rotYNew;

        text_Yrot.text = "Y:" + rotY;

        cameraTransform.eulerAngles = new Vector3(xRot, rotYNew, zRot);
    }

    public void ChangeRotZ(string rotZ)
    {
        int rotZNew = Int32.Parse(rotZ);
        zRot = rotZNew;

        text_Zrot.text = "Z:" + rotZ;

        cameraTransform.eulerAngles = new Vector3(xRot, yRot, rotZNew);
    }
}
