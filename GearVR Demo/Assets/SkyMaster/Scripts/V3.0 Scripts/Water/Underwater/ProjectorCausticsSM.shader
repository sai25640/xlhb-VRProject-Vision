Shader "SkyMaster/CausticsProjector" {
	Properties {
		_Color ("Main Color", Color) = (1,1,1,1)
		_CausticTexture ("Cookie", 2D) = "" {}
		_FalloffTex ("FallOff", 2D) = "" {}
		_Scaling ("Texture scale", Float) = (5,5,5,5)
		_Intensity ("Light intensity", Float) = 0.3
	}
	
	Subshader {
		Tags {"Queue"="Transparent"}
		Pass {
			ZWrite Off
			ColorMask RGB
			Blend DstColor One
			Offset -1, -1
	
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog
			#include "UnityCG.cginc"
			
			struct v2f {
				float4 uvShadow : TEXCOORD0;
				float4 uvFalloff : TEXCOORD1;
			
			//float2 uvShadow : TEXCOORD0;
			//	float2 uvFalloff : TEXCOORD1;
				
				UNITY_FOG_COORDS(2)
				float4 pos : SV_POSITION;
			};
			
			float4x4 _Projector;
			float4x4 _ProjectorClip;
			sampler2D _CausticTexture;
			sampler2D _FalloffTex;
				float4 _CausticTexture_ST;
			float4 _FalloffTex_ST;
			float4 _Scaling;
			float _Intensity;
			
			v2f vert (appdata_base v)//float4 vertex : POSITION)
			{
				v2f o;
				o.pos = mul (UNITY_MATRIX_MVP, v.vertex);
				o.uvShadow = mul (_Projector, v.vertex);
				o.uvFalloff = mul (_ProjectorClip, v.vertex);
				
			//	o.uvShadow = TRANSFORM_TEX(v.texcoord, _CausticTexture);
			//	o.uvFalloff = TRANSFORM_TEX (v.texcoord, _FalloffTex);
				
				UNITY_TRANSFER_FOG(o,o.pos);
				return o;
			}
			
			fixed4 _Color;		
			
			
			fixed4 frag (v2f i) : SV_Target
			{
				//fixed4 texS = 1*tex2Dproj (_CausticTexture, UNITY_PROJ_COORD(i.uvShadow)+float4(1,1,0,0));
				
				float4 PROJ =  UNITY_PROJ_COORD(i.uvShadow);
				
				fixed4 texS = 1*tex2Dproj (_CausticTexture,float4(PROJ.x*_Scaling.x,PROJ.y*_Scaling.y,PROJ.z*_Scaling.z+_Time.x,PROJ.w));
				//fixed4 texS = tex2D (_CausticTexture, float4(i.uvShadow.xy,0,0));
				texS.rgb *= _Color.rgb;
				texS.a = 1.0-texS.a;
				//texS.a*=texS.a;texS.a*=texS.a*10.05;
				//fixed4 texF = tex2Dproj (_FalloffTex, (3*cos(_Time.y/24)+20)+(UNITY_PROJ_COORD(i.uvShadow)+float4(0,0.3*cos(_Time.y/5+1)+0.5*sin(_Time.y/2+3),0,0)));
				fixed4 texF = tex2Dproj (_FalloffTex,(3*cos(_Time.y/24)+20+(_Time.y/62))+(UNITY_PROJ_COORD(i.uvShadow - _Time.y/62)+float4(0,0.3*cos(_Time.y/5+1)+0.5*sin(_Time.y/2+3),_Time.y,0)));
				//fixed4 texF = tex2D (_FalloffTex, float4(i.uvFalloff.xy,0,0));
				
				fixed4 res = texS * texF.a;

				UNITY_APPLY_FOG_COLOR(i.fogCoord, res, fixed4(0,0,0,0));
				return res*_Intensity;				

			}
			ENDCG
		}
	}
}

