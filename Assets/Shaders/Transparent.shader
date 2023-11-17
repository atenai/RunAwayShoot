//透明シェーダー
Shader "Unlit/Transparent"
{ 
	SubShader
	{
		Tags { "Queue" = "Transparent" }
		LOD 200

		//プログラム開始
		CGPROGRAM
		//関数宣言
		//透明度をいじるため
		#pragma surface surf Standard alpha:fade 
		#pragma target 3.0

		struct Input 
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutputStandard o) {
			o.Albedo = fixed4(0.6f, 0.7f, 0.4f, 1);
			o.Alpha = 0.6;
		}

		//プログラム終了
		ENDCG
	}
	FallBack "Diffuse"
}
