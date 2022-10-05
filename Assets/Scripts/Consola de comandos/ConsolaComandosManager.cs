using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsolaComandosManager : MonoBehaviour
{

    public GameObject panelComandos, buttonsPrincipal, panelPlayerConfig, panelCameraConfig, panelOtherEnemies;

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
            Time.timeScale = 0;
        }
    }

    public void ClosePanelComandos()
    {
        panelComandos.SetActive(false);
        Time.timeScale = 1;
    }

    #region Player
    public void OpenPlayerConfig()
    {
        panelPlayerConfig.SetActive(true);
        buttonsPrincipal.SetActive(false);
    }
    public void ClosePlayerConfig()
    {
        panelPlayerConfig.SetActive(false);
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

    #region Other Enemies
    public void OpenOtherEnemiesConfig()
    {
        panelOtherEnemies.SetActive(true);
        buttonsPrincipal.SetActive(false);
    }
    public void CloseOtherEnemiesConfig()
    {
        panelOtherEnemies.SetActive(false);
        buttonsPrincipal.SetActive(true);

    }

    #endregion
}
