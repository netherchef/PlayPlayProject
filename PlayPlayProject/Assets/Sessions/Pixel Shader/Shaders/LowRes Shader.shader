// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom / LowRes Shader"
{

    Properties
    {
        _MainTex ("Main Texture", 2D) = "white"
        _Columns ("Pixel Columns", float) = 64
        _Rows ("Pixel Rows", float) = 64
    }

    SubShader
    {

        Pass
        {
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float2 uv : TEXCOORD0;
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata IN)
            {
                v2f o;
                o.uv = IN.uv;
                o.vertex = UnityObjectToClipPos(IN.vertex);
                return o;
            }

            sampler2D _MainTex;
            float _Columns;
            float _Rows;

            fixed4 frag (v2f IN) : SV_Target
            {
                float2 uv = IN.uv;
                uv.x *= _Columns;
                uv.y *= _Rows;
                uv.x = round (uv.x);
                uv.y = round (uv.y);
                uv.x /= _Columns;
                uv.y /= _Rows;

                fixed4 OUT = tex2D (_MainTex, uv);
                return OUT;
            }

            ENDCG
        }

    }

}