Shader "Custom / Talk Sprite Shader" {

	Properties {

		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Colour", Color) = (1, 1, 1, 1)
	}

	SubShader {

			Cull Off
			Blend One OneMinusSrcAlpha

			Pass {

				CGPROGRAM

				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata {

					float4 vertex : POSITION;
					float2 uv : TEXCOORD0;
				};

				struct v2f {

					float4 position : SV_POSITION;
					float2 uv : TEXCOORD0;
				};

				sampler2D _MainTex;

				v2f vert (appdata IN) {

					v2f OUT;

					OUT.position = UnityObjectToClipPos (IN.vertex);
					OUT.uv = IN.uv;

					return OUT;
				}

				fixed4 frag (v2f IN) : SV_Target {

					half4 color = tex2D (_MainTex, IN.uv);
					color.rgb *= color.a;

					return color;
				}

				ENDCG
			}
		}
}