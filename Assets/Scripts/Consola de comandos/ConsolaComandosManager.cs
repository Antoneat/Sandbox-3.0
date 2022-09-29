using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolaComandosManager : MonoBehaviour
{

    public GameObject panelComandos, buttonsPrincipal, panelPlayerConfig, panelCameraConfig;

    public GameObject panelReinicio;

    private PlayerDmg playerDmg;

    private void Start()
    {
        playerDmg = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDmg>();
    }

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

    #region Player
    public void OpenPlayerConfig()
    {
        panelPlayerConfig.SetActive(true);
        buttonsPrincipal.SetActive(false);
    }
    public void ClosePlayerConfig()
    {
        panelCameraConfig.SetActive(false);
        buttonsPrincipal.SetActive(true);

    }

    #endregion

    #region Camera
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

    #endregion
}
