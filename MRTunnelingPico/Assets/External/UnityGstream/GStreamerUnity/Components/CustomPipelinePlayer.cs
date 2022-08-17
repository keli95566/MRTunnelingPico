﻿using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(GstCustomTexture))]
public class CustomPipelinePlayer : MonoBehaviour {

	GstCustomTexture m_Texture;

	public Texture2D BlittedImage;

	public Material TargetMaterial;

	public string pipeline = "";

	public Rect BlitRect=new Rect(0,0,1,1);
	GstImageInfo _img;

	public long position;
	public long duration;
	bool _newFrame=false;

	private Texture2D FrameImage;
    // Use this for initialization
    void Start () {
		m_Texture = gameObject.GetComponent<GstCustomTexture>();
		m_Texture.Initialize ();
		m_Texture.SetPipeline(pipeline + " ! video/x-raw,format=I420 ! videoconvert ! appsink name=videoSink");

		//m_Texture.SetPipeline (pipeline+ " ! videoconvert ! video/x-raw,format=I420  ! appsink name=videoSink sync=false");
		m_Texture.Player.CreateStream ();
		m_Texture.Player.Play ();

		m_Texture.OnFrameBlitted += OnFrameBlitted;

        _img = new GstImageInfo ();
		_img.Create (1, 1, GstImageInfo.EPixelFormat.EPixel_R8G8B8);

		//BlittedImage = new Texture2D(1280, 720, TextureFormat.RGB24, false);//, TextureFormat.ARGB32,false);
		BlittedImage = new Texture2D(1, 1);

		BlittedImage.filterMode = FilterMode.Bilinear;
		BlittedImage.anisoLevel=0;
		BlittedImage.wrapMode=TextureWrapMode.Clamp;

		FrameImage = new Texture2D(1280, 720, TextureFormat.RGB24, false);

		if (TargetMaterial != null)
			TargetMaterial.mainTexture = FrameImage;

		// yield return StartCoroutine("CallPluginAtEndOfFrames");
	}
	void OnFrameBlitted(GstBaseTexture src,int index)
    {
       // if (TargetMaterial != null)
       //     TargetMaterial.mainTexture = m_Texture.PlayerTexture()[0];
        
        //m_Texture.Player.CopyFrame (_img);
        float w=m_Texture.Player.FrameSizeImage.x;
		float h=m_Texture.Player.FrameSizeImage.y;
		
        m_Texture.Player.CopyFrameCropped(_img,(int)(BlitRect.x*w),(int)(BlitRect.y*h),(int)(BlitRect.width*w),(int)(BlitRect.height*h));
		_newFrame = true;
		if (_newFrame)
		{

			//_img.BlitToTexture(BlittedImage);
			//BlittedImage.Apply();
			
			setTextureUnity();
			_newFrame = false;
		}

		//		Debug.Log(String.Format("Frame Copied {0}x{1}",_img.Width,_img.Height));
	}
	
	void setTextureUnity()
    {
		byte[] res = new byte[] { };
		_img.CopyImageData(ref res);
        try
        {

			FrameImage.LoadRawTextureData(res);
			FrameImage.Apply();
		}
        catch
        {
			Debug.Log("can't load texture");
        }
	}
	public void OnGUI()
	{
	}
	void OnDestroy()
	{
		if(_img!=null)
			_img.Destory ();
       		Debug.Log ("Destorying Image");
    }
    
    /*private IEnumerator CallPluginAtEndOfFrames()
    {
        while (true)
        {
            // Wait until all frame rendering is done
            yield return new WaitForEndOfFrame();

            if (_newFrame)
            {
                _img.BlitToTexture(BlittedImage);
                _newFrame = false;
            }
        }
    }*/

    // Update is called once per frame
    void Update ()
    {
        //position =m_Texture.Player.GetPosition ()/1000;
		//duration=m_Texture.Player.GetDuration ()/1000;

		//if (Input.GetKeyDown (KeyCode.LeftArrow)) {
		//	var p = (position - 5000) ;
		//	if (p < 0)
		//		p = 0;
		//	m_Texture.Player.Seek (p * 1000);
		//}
		//if (Input.GetKeyDown (KeyCode.RightArrow)) {
		//	var p = (position + 5000);
		//	if (p >=duration)
		//		p = duration;
		//	m_Texture.Player.Seek (p * 1000);
		//}
		//if (Input.GetKeyDown (KeyCode.S))
		//	m_Texture.Stop ();

		//if (Input.GetKeyDown (KeyCode.P))
		//	m_Texture.Play ();
	}
}
