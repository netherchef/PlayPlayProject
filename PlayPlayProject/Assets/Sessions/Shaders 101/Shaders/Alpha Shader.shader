// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Define the shader category and name.

Shader "Shaders101 / Alpha"
{
    Properties
    {

        // This will be the main texture for the shader.

        _MainTex ("Texture", 2D) = "white"
    }

    SubShader
    {
        Tags
        {

            // Set the Queue tag so we render with all other Transparent objects.
            // Transparent objects render after Opaque ones.

            "Queue" = "Transparent"
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            // This struct stores mesh data.

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            // This struct stores fragment data.

            struct v2f
            {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos (v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;

            float4 frag (v2f i) : SV_Target
            {
                float4 color = tex2D (_MainTex, i.uv);
                return color;
            }

            ENDCG
        }
    }
}