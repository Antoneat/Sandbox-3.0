using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerConfig : MonoBehaviour
{

    [Header("Referencias")]
    public PlayerMovement playerMovement;
    public PlayerDash playerDash;
    public PlayerDmg playerDmg;

    [Header("Generales")]
    public Transform scarletTransform;
    
    public TMP_Text text_speed;
    public TMP_Text text_maxSpeed;
    
    public TMP_Text text_dashForce;
    public TMP_Text text_dashDuration;

    public TMP_Text text_vida;

    //[Header("Posición")]
    private float vlrSpeed;
    private float vlrMaxSpeed;



    void Start()
    {
        //Textos Speed
        text_speed.text = "Speed:" + playerMovement.speed;
        text_maxSpeed.text = "maxSpeed:" + playerMovement.maxSpeed;

        //Textos Dash
        text_dashForce.text = "DashForce:" + playerDash.dashForce;
        text_dashDuration.text = "maxSpeed:" + playerDash.dashDuration;

        text_vida.text = "Vida:" + playerDmg.actualvida;
    }

    ////////////////////////////////////////////////////////////////////////

    #region Speed
    public void ModifySpeed(string vSpeed)
    {
        int vSpeedNew = Int32.Parse(vSpeed);
        vlrSpeed = vSpeedNew;

        text_speed.text = "Speed:" + vSpeed;

        playerMovement.speed = vSpeedNew;
    }
    public void ModifyMaxSpeed(string vMaxSpeed)
    {
        int vMaxSpeedNew = Int32.Parse(vMaxSpeed);
        vlrMaxSpeed = vMaxSpeedNew;

        text_maxSpeed.text = "MaxSpeed:" + vMaxSpeed;

        playerMovement.maxSpeed = vMaxSpeedNew;
    }

    #endregion

    ////////////////////////////////////////////////////////////////////////

    #region Dash
    public void DashForce(string dashF)
    {
        int dashFNew = Int32.Parse(dashF);
        //vlrSpeed = dashFNew;

        text_dashForce.text = "DashForce:" + dashF;

        playerDash.dashForce = dashFNew;
    }
    public void DashDuration(string dashDu)
    {
        int dashDuNew = Int32.Parse(dashDu);
        //vlrSpeed = dashFNew;

        text_dashDuration.text = "DashDura:" + dashDu;

        playerDash.dashDuration = dashDuNew;
    }

    #endregion

    public void VidaPlayer(string vidaPlayer)
    {
        int vidaPlayerNew = Int32.Parse(vidaPlayer);

        text_vida.text = "Vida:" + vidaPlayer;

        playerDmg.actualvida = vidaPlayerNew;
    }
}
