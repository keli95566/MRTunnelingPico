using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public GameObject ImageSliders;
    public GameObject TaskDescription;
    public GameObject EmbededBrowser;
    // Start is called before the first frame update
    private bool displaySliders = false;
    private bool displayDescriotion = false;
    private bool displayBrowser = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleImageSliders()
    {
        displaySliders = !displaySliders;
        ImageSliders.SetActive(displaySliders);
        TaskDescription.SetActive(false);
        EmbededBrowser.SetActive(false);
    }

    public void ToggleDescription()
    {
        displayDescriotion = !displayDescriotion;
        TaskDescription.SetActive(displayDescriotion);
        ImageSliders.SetActive(false);
        EmbededBrowser.SetActive(false);
    }

    public void ToggleBrowser()
    {
        displayBrowser = !displayBrowser;
        EmbededBrowser.SetActive(displayBrowser);
        ImageSliders.SetActive(false);
        TaskDescription.SetActive(false);
    }

}
