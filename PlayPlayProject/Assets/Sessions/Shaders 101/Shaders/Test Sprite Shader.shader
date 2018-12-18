Shader "Custom / Test Sprite Shader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Colour", Color) = (1, 1, 1, 1)
	}

	SubShader
		{
			ZWrite Off
			Tags { "Queue" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha

			Pass
			{
				SetTexture [_MainTex] { Combine texture * constant ConstantColor [_Color] }
			}
		}
}