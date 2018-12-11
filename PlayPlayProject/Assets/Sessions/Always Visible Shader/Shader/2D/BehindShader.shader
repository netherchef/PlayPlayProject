Shader "Unlit/BehindShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
        _Color ("Main Color", Color) = (1,1,1,1)
	}

    Category
    {
        SubShader
        {
            Tags
            {"Queue" = "Overlay+1"
            "RenderType" = "Transparent"
            }

            Pass
            {
                ZWrite Off
                ZTest Greater
                Lighting Off
                Color [_Color]
            }

            Pass
            {
                Blend SrcAlpha OneMinusSrcAlpha
                ZTest Less
                SetTexture [_MainTex] {combine texture}
            }
        }
    }

    Fallback "Specular", 1
}
