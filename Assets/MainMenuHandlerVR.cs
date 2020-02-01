using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class MainMenuHandlerVR : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;

    void Awake()
    {
        laserPointer.PointerClick += PointerClick;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        Debug.Log("Clicked: " + e.target.name);
        if(e.target.name == "StartButton")
        {
            Application.LoadLevel("Scenes/MainGameScene");
        }
        else if (e.target.name == "ExitButton")
        {
            Application.Quit();
        }
    }

}
