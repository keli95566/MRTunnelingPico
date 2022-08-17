using UnityEngine;
using UnityEngine.UI;
using TMPro;

/**
 * Custom Side By Side 3D Player
 * Using UI Elements to show the both streams to the user
 * Used WVGA video settings from stereolab's ZED camera
 */
[RequireComponent(typeof(GstCustomTexture))]
public class CustomSBSPipelinePlayer : MonoBehaviour
{
    public GstCustomTexture m_Texture;
    public RESOLUTION resolution = RESOLUTION.HD720;
    
    // Need to get the correct transform to get proper aspect ratio
    public Transform LeftFrameTransform;
    public Transform RightFrameTransform;

    public TextMeshProUGUI Framerate;
    public TextMeshProUGUI FramecountText;
    protected Texture2D blittedImageLeft;
	protected Texture2D blittedImageRight;
	public Texture2D LeftEye {
		get{ return blittedImageLeft; }
	}
	public Texture2D RightEye{
		get{ return blittedImageRight; }
	}

	public Material leftUIImage;
    public Material rightUIImage;

	public int Port = 30000;

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
        /// <summary>
        /// percentage of video to be cropped
        /// </summary>
        HD2KCrop
    };

    private GstImageInfo _img_left;
    private GstImageInfo _img_right;

    private bool _newFrame = false;
    private int framecount = 0;
    private int height = 720;
    private int width = 1280;

    // Use this for initialization
    void Start()
    {
        SetupStreaming();

    }
    public void SetupStreaming()
    {
        m_Texture = gameObject.GetComponent<GstCustomTexture>();

        m_Texture.Initialize();

        DetermineResolution();
        string pipeline = "udpsrc port=30000 !  application/x-rtp,clock-rate=90000,payload=96  ! rtph264depay  ! h264parse ! avdec_h264  ! autovideoconvert";//string pipeline = "udpsrc port=" + Port.ToString () + " ! application/x-rtp, encoding-name=H264, payload=96 ! rtph264depay ! h264parse ! avdec_h264";
        m_Texture.SetPipeline(pipeline + $" ! video/x-raw, format=BGRA,width={width}, height={height * 2} ! appsink name=videoSink");

        m_Texture.Player.CreateStream();
        m_Texture.Player.Play();

        m_Texture.OnFrameBlitted += OnFrameBlitted;
        _img_left = new GstImageInfo();
        _img_left.Create(1, 1, GstImageInfo.EPixelFormat.EPixel_B8G8R8A8);
        _img_right = new GstImageInfo();
        _img_right.Create(1, 1, GstImageInfo.EPixelFormat.EPixel_B8G8R8A8);

        blittedImageLeft = new Texture2D(width, height, TextureFormat.BGRA32, false, QualitySettings.activeColorSpace == ColorSpace.Gamma);
        blittedImageLeft.filterMode = FilterMode.Trilinear;
        // blittedImageLeft.wrapMode = TextureWrapMode.Clamp;

        blittedImageRight = new Texture2D(width, height, TextureFormat.BGRA32, false, QualitySettings.activeColorSpace == ColorSpace.Gamma );
        blittedImageRight.filterMode = FilterMode.Trilinear;
        // blittedImageRight.wrapMode = TextureWrapMode.Clamp;


        if (leftUIImage != null)
        {
            leftUIImage.mainTexture = blittedImageLeft;
        }

        if (rightUIImage != null)
        {
            rightUIImage.mainTexture = blittedImageRight;
        }

        framecount = 0;
    }
    public void ResetDefault()
    {
        resolution = RESOLUTION.HD720;
        SetupStreaming();
    }
    void DetermineResolution()
    {
        // default value, HD720 full 
        float scale_x;
        float scale_y;


        if (resolution == RESOLUTION.HD2K)
        {
            scale_x = 0.2034279f;
            scale_y = 0.1144282f;
            width = 2048;
            height = 1152;
            LeftFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
            RightFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
        }

        if (resolution == RESOLUTION.HD1080)
        {
            scale_x = 0.203398f;
            scale_y = 0.1144114f;
            width = 1920;
            height = 1080;
            LeftFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
            RightFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
        }
        if (resolution == RESOLUTION.HD720)
        {
            scale_x = 0.2803709f;
            scale_y = 0.1577086f;
            width = 1280;
            height = 720;
            LeftFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
            RightFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
        }
        if (resolution == RESOLUTION.VGA)
        {
            scale_x = 0.2944051f;
            scale_y = 0.1656029f;
            width = 672;
            height = 376;
            LeftFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
            RightFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
        }

        if (resolution == RESOLUTION.HD1080Crop)
        {

            //float cropPercentage = 30;
            //float percentil = (100 - cropPercentage) / 100;
            scale_x = 0.203398f * 0.60f;
            scale_y = 0.1144114f * 0.85f;

            width = Mathf.RoundToInt(1920 * 0.60f);
            height = Mathf.RoundToInt(1080 * 0.85f);
            LeftFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
            RightFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
        }


        if (resolution == RESOLUTION.HD720Crop)
        {
            float cropPercentage = 20;
            // e.g. 80% cropped => 960*540 
            // crop range: width: 480, 1440; 270;1170
            float percentil = (100 - cropPercentage) / 100;

            scale_x = 0.2803709f * percentil;
            scale_y = 0.1577086f * percentil;

            width = Mathf.RoundToInt(1280 * percentil);
            height = Mathf.RoundToInt(720 * percentil);
            LeftFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
            RightFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
        }

        if (resolution == RESOLUTION.HD2KCrop)
        {
            float xcrop = 20;
            float ycrop = 40;

            scale_x = 0.2034279f * 0.6f;
            scale_y = 0.1144282f * 0.8f;

            width = Mathf.RoundToInt(2048 * 0.6f);
            height = Mathf.RoundToInt(1152* 0.8f);
            LeftFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
            RightFrameTransform.localScale = new Vector3(scale_x, scale_y, 1);
        }

    }
    void OnFrameBlitted(GstBaseTexture src, int index)
    {

        m_Texture.Player.CopyFrame(_img_left);
        m_Texture.Player.CopyFrame(_img_right);
        float w = m_Texture.Player.FrameSizeImage.x;
        float h = m_Texture.Player.FrameSizeImage.y;
    

        // m_Texture.Player.CopyFrameCropped(_img_left, 0, 0, (int)(w), (int)(h/2));
        // m_Texture.Player.CopyFrameCropped(_img_right, 0, (int)(h / 2), (int)(w), (int)(h/2));
        _newFrame = true;

		//can be moved update function in case of performance issues
		if (_newFrame)
		{

            int targetLength = _img_left.Width * _img_left.Height *2;
            
            System.IntPtr ptr = _img_left.GetImageDataPointer();
            blittedImageLeft.LoadRawTextureData(ptr, targetLength);
            blittedImageLeft.Apply(false, false);

            System.IntPtr ptr2 = _img_right.GetImageDataPointer();
            blittedImageRight.LoadRawTextureData(ptr2 + targetLength, targetLength);
            blittedImageRight.Apply(false, false);
            //_img_left.BlitToTexture(blittedImageLeft);
            //_img_right.BlitToTexture(blittedImageRight);

            _newFrame = false;
            framecount += 1;
		}
        if (Framerate != null)
        {
            Framerate.text = m_Texture.GetCaptureRate(index).ToString();
        }

        if( FramecountText != null)
        {
            framecount += 1;
            FramecountText.text = framecount.ToString();
        }
    }

    void OnDestroy()
    {
        if (_img_left != null)
            _img_left.Destory();
        if (_img_right != null)
            _img_right.Destory();
    }

    // Update is called once per frame
    void Update()
	{
       
    }
}
