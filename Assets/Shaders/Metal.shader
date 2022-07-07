//金属シェーダー
Shader "Custom/Metal"
{
	Properties
	{
		//テクスチャ
		_MainTex("Main Texture (RGB)", 2D) = "white" {}
		//色
		_Color("Diffuse Tint (RGB)", Color) = (1.0, 1.0, 1.0, 1.0)
		//光度
		_Shininess("Shininess", float) = 10
		_Metalness("Metalness", Range(0.0, 1.0)) = 0.0

	}
		SubShader
		{
			Pass
			{
				Tags { "LightMode" = "ForwardBase" }

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag

				#include "UnityCG.cginc"

				struct appdata
				{
					float4 vertex : POSITION;
					half2 uv : TEXCOORD0;
					half3 normal : NORMAL;
				};

				struct v2f
				{
					float4 pos : SV_POSITION;
					half2 uv : TEXCOORD0;
					half3 normal : TEXCOORD1;
					half3 lightDir : TEXCOORD2;
					half3 halfDir : TEXCOORD3;
				};

				sampler2D _MainTex;
				half4 _MainTex_ST;
				  half4 _Color;
				half4 _LightColor0;
				half _Shininess;
				  half _Metalness;

				v2f vert(appdata v)
				{
					v2f o = (v2f)0;
					o.pos = UnityObjectToClipPos(v.vertex);
					half3 worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
					o.uv = TRANSFORM_TEX(v.uv, _MainTex);
					o.normal = UnityObjectToWorldNormal(v.normal);
					half3 viewDir = normalize(_WorldSpaceCameraPos - worldPos);
					o.lightDir = normalize(_WorldSpaceLightPos0.xyz);
					o.halfDir = normalize(viewDir + o.lightDir);
					return o;
				}

				fixed4 frag(v2f i) : SV_Target
				{
					half4 base = tex2D(_MainTex, i.uv) * _Color;
					half3 specColor = lerp(1.0, base.rgb, _Metalness);

					// 拡散反射光
					half3 directDiff = base * (max(0.0, dot(i.normal, i.lightDir)) * _LightColor0.rgb);

					// 鏡面反射光
					half3 directSpec = pow(max(0.0, dot(i.normal, i.halfDir)), _Shininess) * _LightColor0.rgb * specColor;

					fixed4 col;
					// Metalnessに応じてブレンドする
					col.rgb = lerp(directDiff, directSpec, _Metalness);
					return col;
				}
				ENDCG
			}
		}
}
