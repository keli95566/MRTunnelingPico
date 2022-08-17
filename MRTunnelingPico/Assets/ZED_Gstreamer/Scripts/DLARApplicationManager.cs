using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DLARApplicationManager : MonoBehaviour
{
    public GameObject LaserMichelle;
    public GameObject AvatarEyeTracking;
    public GameObject TinyYOLO;
    public GameObject ImageEffectScanner;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleLaserMichelle()
    {
        bool active = LaserMichelle.active;
        LaserMichelle.SetActive(!active);
    }

    public void ToggleAvatarEyeTracking()
    {

        bool active = AvatarEyeTracking.active;
        AvatarEyeTracking.SetActive(!active);
    }

    public void ToggleTinyYOLO()
    {

        bool active = TinyYOLO.active;
        TinyYOLO.SetActive(!active);
    }

    public void ToggleImageEffectScanner()
    {

        bool active = ImageEffectScanner.active;
        ImageEffectScanner.SetActive(!active);
    }
}
