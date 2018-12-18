Shader "Custom / Talk Shader" {
	
	Properties {

		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Tint Colour", Color) = (1, 1, 1, 1)

		_ExtrudeAmount ("Extrude Amount", Range (0, 1)) = 1
	}

	SubShader {

		Pass {

			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			float4 _Color;

			float _ExtrudeAmount;

			struct appdata {

				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			struct v2f
			{
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
				float3 normal : NORMAL;
			};

			v2f vert (appdata IN) {

				v2f OUT;

				IN.vertex.xyz += IN.normal.xyz * _ExtrudeAmount * sin (_Time.y);

				OUT.position = UnityObjectToClipPos (IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			fixed4 frag (v2f IN) : SV_Target {

				float4 textureColor = tex2D (_MainTex, IN.uv);

				return textureColor;
			}

			ENDCG
		}
	}
}