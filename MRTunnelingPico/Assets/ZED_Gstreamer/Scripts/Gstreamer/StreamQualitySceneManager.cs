using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StreamQualitySceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadHD720()
    {

        SceneManager.LoadScene(sceneName: "HD720");
    }

    public void LoadHD1080()
    {

        SceneManager.LoadScene(sceneName: "HD1080");
    }

    public void LoadHD2K()
    {
        SceneManager.LoadScene(sceneName: "HD2K");

    }
    public void LoadVGA()
    {
        SceneManager.LoadScene(sceneName: "VGA");
    }

    public void LoadI420()
    {
        SceneManager.LoadScene(sceneName: "I420Test");
    }

    public void LoadHD1080Crop()
    {
        SceneManager.LoadScene(sceneName: "Crop_HD1080");
    }

    public void LoadHD720Crop()
    {
        SceneManager.LoadScene(sceneName: "Crop_HD720");
    }

}
