using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using UnityEngine.UI;
using Unity.XR.PXR;
using UnityEngine.XR;
using UnityEngine.XR.Management;

[RequireComponent(typeof(GstCustomTexture))]
public class VSTGstreamerRenderPlane : MonoBehaviour
{
	public GstCustomTexture m_Texture;

	protected Texture2D BlittedImage;

	public Material TargetMaterial;

	public string pipeline = "";

	public RESOLUTION resolution = RESOLUTION.HD720;

	private int FrameRate = 30;

	/// <summary>
	/// Percentage of video to be cropped, if select HD1080Crop, HD720Crop
	/// </summary>
	[Range(1f, 80.0f)]
	public float cropPercentage=0;

	/// <summary>
	/// Represents the available resolution options.
	/// </summary>
	public enum RESOLUTION
	{
		/// <summary>
		/// 2208*1242. Supported frame rate: 15 FPS.
		/// </summary>
		HD2K,
		/// <summary>
		/// 1920*1080. Supported frame rates: 15, 30 FPS.
		/// </summary>
		HD1080,
		/// <summary>
		/// 1280*720. Supported frame rates: 15, 30, 60 FPS.
		/// </summary>
		HD720,
		/// <summary>
		/// 672*376. Supported frame rates: 15, 30, 60, 100 FPS.
		/// </summary>
		VGA,
		/// <summary>
		/// percentage of video to be cropped
		/// </summary>
		HD1080Crop,
		/// <summary>
		/// percentage of video to be cropped
		/// </summary>
		HD720Crop,
	};


	private int ImgWidth=1280; //= 672; //default VGA width and height
	private int ImgHeight=720; //= 376; //default VGA width and height
	//private int FrameRate; //= 30; // default VGA framerate
	private float scale_x = 0.2803709f;
	private float scale_y = 0.1656029f;

	GstImageInfo _img;

	public long position;
	public long duration;
	bool _newFrame = false;
	private Texture2D FrameImage;


	void Start()
	{
		setupGstreamerTexture();

	}

	public void setupGstreamerTexture()
    {

		// start with the default 
		//SetImageProperties();
		//Debug.Log("img width: " + ImgWidth + "img height " + ImgHeight );
		// Gstreamer related
		m_Texture = gameObject.GetComponent<GstCustomTexture>();
		m_Texture.Initialize();
		//udpsrc port=5000 ! application/x-rtp,clock-rate=90000,payload=96 ! queue ! rtph264depay  ! h264parse ! avdec_h264 !  queue ! autovideoconvert 
		m_Texture.SetPipeline(pipeline + $" ! video/x-raw, format=BGRA,width={ImgWidth}, height={ImgHeight} ! appsink name=videoSink");
		m_Texture.Player.CreateStream();
		m_Texture.Player.Play();
		m_Texture.OnFrameBlitted += OnFrameBlitted;
		_img = new GstImageInfo();
		_img.Create(1, 1, GstImageInfo.EPixelFormat.EPixel_B8G8R8A8);
		BlittedImage = new Texture2D(ImgWidth, ImgHeight, TextureFormat.BGRA32, false);

		if (TargetMaterial != null)
			TargetMaterial.mainTexture = BlittedImage;
	}

    private void OnEnable()
    {
		setupGstreamerTexture();
	}



    void SetImageProperties()
	{
		if (resolution == RESOLUTION.HD2K)
		{
			scale_x = 0.2034279f;
			scale_y = 0.1144282f;
			ImgWidth = 2048;
			ImgHeight = 1152;
		//	FrameRate = 15;
			transform.localScale = new Vector3(scale_x, scale_y, 1);
		}

		if (resolution == RESOLUTION.HD1080)
		{
			scale_x = 0.203398f;
			scale_y = 0.1144114f;
			ImgWidth = 1920;
			ImgHeight = 1080;
		//	FrameRate = 15;
			transform.localScale = new Vector3(scale_x, scale_y, 1);
		}
		if (resolution == RESOLUTION.HD720)
		{
			scale_x = 0.2803709f;
			scale_y = 0.1577086f;
			ImgWidth = 1280;
			ImgHeight = 720;
		//	FrameRate = 15;
			transform.localScale = new Vector3(scale_x, scale_y, 1);
		}
		if (resolution == RESOLUTION.VGA)
		{
			scale_x = 0.2944051f;
			scale_y = 0.1656029f;
			ImgWidth = 672;
			ImgHeight = 376;
		//	FrameRate = 60;
			transform.localScale = new Vector3(scale_x, scale_y, 1);
		}

		if(resolution == RESOLUTION.HD1080Crop)
        {
			// e.g. 50% cropped => 960*540 
			// crop range: width: 480, 1440; 270;1170
			cropPercentage = 50;
			float percentil = (100 - cropPercentage) / 100;
			scale_x = 0.203398f * percentil;
			scale_y = 0.1144114f * percentil;

			ImgWidth = Mathf.RoundToInt(1920* percentil);
			ImgHeight =Mathf.RoundToInt(1080* percentil);
			transform.localScale = new Vector3(scale_x, scale_y, 1);
		}


		if (resolution == RESOLUTION.HD720Crop)
		{
			cropPercentage = 20;
			// e.g. 80% cropped => 960*540 
			// crop range: width: 480, 1440; 270;1170
			float percentil = (100 - cropPercentage) / 100;

			scale_x = 0.2803709f * percentil;
			scale_y = 0.1577086f * percentil;


			ImgWidth =  Mathf.RoundToInt(1280 * percentil);
			ImgHeight = Mathf.RoundToInt(720 * percentil);
			transform.localScale = new Vector3(scale_x, scale_y, 1);
		}
	}
	void OnFrameBlitted(GstBaseTexture src, int index)
	{
		m_Texture.Player.CopyFrame(_img);
		//float w = m_Texture.Player.FrameSizeImage.x;
		//float h = m_Texture.Player.FrameSizeImage.y;
		_newFrame = true;
		if (_newFrame)
		{
			_img.BlitToTexture(BlittedImage);

			//m_Texture.Player.BlitTexture(FrameImage.GetNativeTexturePtr(), ImgWidth, ImgHeight);
			//setTextureUnity();
			_newFrame = false;
		}

	}

	void setTextureUnity()
	{
		//byte[] res = new byte[] { };
		//_img.CopyImageData(ref res);

		int targetLength = _img.Width * _img.Height * 4;
		System.IntPtr ptr = _img.GetImageDataPointer();
		BlittedImage.LoadRawTextureData(ptr, targetLength);
		BlittedImage.Apply(false, false);

	}
	void OnDestroy()
	{
		if (_img != null)
			_img.Destory();
	}

    private void Update()
    {


	}

}
