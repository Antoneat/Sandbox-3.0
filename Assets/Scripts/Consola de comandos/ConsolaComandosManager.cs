using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolaComandosManager : MonoBehaviour
{

    public GameObject panelComandos, buttonsPrincipal, panelCameraConfig;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            panelComandos.SetActive(true);
        }
    }

    public void ClosePanelComandos()
    {
        panelComandos.SetActive(false);
    }

    public void OpenCameraConfig()
    {
        panelCameraConfig.SetActive(true);
        buttonsPrincipal.SetActive(false);
    }
    public void CloseCameraConfig()
    {
        panelCameraConfig.SetActive(false);
        buttonsPrincipal.SetActive(true);

    }
}
