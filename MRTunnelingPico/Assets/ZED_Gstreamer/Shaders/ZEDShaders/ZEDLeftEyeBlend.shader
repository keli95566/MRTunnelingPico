Shader "Unlit/ZEDLeftEyeBlend"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Transparency("Transparency", Range(0.0,1)) = 0.5
        _Visibility("Visibility", Range(0.0,10.0)) = 10  
    }
    SubShader
    {
        Tags { "Queue"="Background" "RenderType"="Transparent" }
        LOD 100
        Cull Off

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Transparency;
            float _Visibility;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                col.a = clamp((i.uv.x)*_Visibility * i.uv.y*_Visibility * (1-i.uv.y)*_Visibility,0,1);
                return col;
            }
            ENDCG
        }
    }
}
