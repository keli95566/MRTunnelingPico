Shader "Unlit/BasicZed"
{
	Properties{
		_MainTex("Main texture", 2D) = "" {}
	}
		SubShader
		{
			ZWrite On
			Pass
			{


				Cull Off
				CGPROGRAM



				#pragma target 4.0

				#pragma vertex vert_surf
				#pragma fragment frag_surf


				#include "HLSLSupport.cginc"
				#include "UnityShaderVariables.cginc"

				#define UNITY_PASS_FORWARDBASE
				#include "UnityCG.cginc"

				sampler2D _MainTex;

				struct Input {
					float2 uv_MainTex;
				};

				struct v2f_surf {
					float4 pos : SV_POSITION;
					float4 pack0 : TEXCOORD0;
				};



				float4 _MainTex_ST;

				// vertex shader
				v2f_surf vert_surf(appdata_full v) 
				{

					v2f_surf o;
					UNITY_INITIALIZE_OUTPUT(v2f_surf,o);
					o.pos = UnityObjectToClipPos(v.vertex);
					o.pack0.xy = TRANSFORM_TEX(v.texcoord, _MainTex);

					o.pack0.y = 1 - o.pack0.y;
					o.pack0.w = 1 - o.pack0.w;

					return o;
				}

				// fragment shader
				void frag_surf(v2f_surf IN, out fixed4 outColor : SV_Target, out float outDepth : SV_Depth) 
				{
					UNITY_INITIALIZE_OUTPUT(fixed4,outColor);
					float4 uv = IN.pack0;


					fixed4 c = 0;
					float4 color = tex2D(_MainTex, uv.xy).bgra;

					c.a = 0;
					outColor.rgb = c;

				}

	ENDCG

			}
		}
}
