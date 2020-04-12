Shader "Unlit/Depth_Write_FromLegacy"
{
    Properties
    {
		_DepthTex("Depth Texture", 2D) = "white" {}
		_RenderedTex("Rendered Image", 2D) = "white" {}
		_NormalTex("Normal Texture", 2D) = "white" {}
		_EmissiveTex("Emissive Texture", 2D) = "white" {}
		_ShadowTex("Shadow Texture", 2D) = "white" {}
		_Near("Near clipping plane", Float) = 1
		_Far("Far clipping plane", Float) = 40
		_Color("Color", Color) = (1,1,1,1)
		_Ambient_Multiplier("Ambient Multiplier", Float) = 5
		_Metallic("Metallic", Range(0, 1)) = 1
		_Gloss("Gloss", Range(0, 1)) = 0.8
	}
		SubShader
		{
			Pass
			{
				Tags {"LightMode" = "Deferred"}

				CGPROGRAM
				#pragma vertex vertex_shader
				#pragma fragment pixel_shader
				#pragma exclude_renderers nomrt
				#pragma multi_compile ___ UNITY_HDR_ON
				#pragma target 3.0

				#include "UnityPBSLighting.cginc"

				sampler2D _CameraDepthNormalsTexture;
				uniform sampler2D _LightBuffer;

				float4 _Color;
				float _Metallic;
				float _Gloss;
				float _Ambient_Multiplier;

				uniform sampler2D _DepthTex;
				uniform sampler2D _RenderedTex;
				uniform sampler2D _NormalTex;
				uniform sampler2D _EmissiveTex;
				uniform float _Near;
				uniform float _Far;

				// Declare Struct for Vertex.
				struct structureVS
				{
					float4 pos:SV_POSITION;
					float2 uv:TEXCOORD0;
					float3 normal : TEXCOORD1;
				};

				// Initialize Vertex Program. 
				structureVS vertex_shader(appdata_base input)
				{
					structureVS output;
					// pos
					output.pos = UnityObjectToClipPos(input.vertex);

					// normal
					output.normal = UnityObjectToWorldNormal(input.normal);

					// uv
					output.uv = input.texcoord.xy;
					return output;
				}

				// Declare Struct for Fragment.
				// Apparently the float value doesn't have hdr, but half4 does.
				struct structurePS
				{
					float4 albedo : SV_Target0;
					float4 specular : SV_Target1;
					float4 normal : SV_Target2;
					float4 emission : SV_Target3;
					float depthSV : Depth;
				};

				// Function for Processing Depth Texture and turning it into a linear Float value.
				float ProcessDepth(structureVS inputVS)
				{
					// Read the depth from the depth texture
					float4 imageDepth4 = tex2D(_DepthTex, inputVS.uv);
					float imageDepth = -imageDepth4.x;

					// Go back to clip space by computing the depth as the depth of the pixel from the camera
					float4 temp = float4(0, 0, (imageDepth * (_Far - _Near) - _Near), 1); // W = 1, therefore a position.
					float4 clipSpace = mul(unity_CameraProjection, temp); // unity_CameraProjection is the same as camera.projectionmatrix.

					// Carry out the perspective division and map into screen space (DirectX)					
					// We only care about z
					clipSpace.z /= clipSpace.w;
					clipSpace.z = 0.5*(1.0 - clipSpace.z);
					float z = clipSpace.z;

					return z;
				}

				float3 ProcessEmission(float3 colourInput)
				{
					// Return Emissive GBuffer.
					float4 emissionTemp = float4(0, 0, 0, 1);

					float3 indirectDiffuse = float3(0, 0, 0);
					indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb;

					// Original was ps.emission.rgb += indirectDiffuse * (colourFloat4.rgb) * _Ambient_Multiplier;
					return emissionTemp.rgb += indirectDiffuse * colourInput * _Ambient_Multiplier;
				}

				// Initialize Fragment Program. 
				structurePS pixel_shader(structureVS vs)
				{
					structurePS ps;

					// For EXR use linear colour space mode.
					// For JPG, PNG, Bitmap etc use gamma colour space mode.
					// Write out the pre-computed color and the correct depth.

					// Function for Processing Depth Texture and Returning the Depth as a Float.
					float z = ProcessDepth(vs);

					/////////////
					// RETURNs //
					/////////////
					// Define Prerendered Texture Float4's.

					// Return Albedo GBuffer.
					float4 colourFloat4 = tex2D(_RenderedTex, vs.uv);
					ps.albedo = colourFloat4 * _Color;

					// Return Specular GBuffer.
					float3 specular;
					ps.specular = float4(specular, _Gloss);

					// Return Normal GBuffer.
					// Okay, so the * 0.5 + 0.5 is very important.
					// The below result gives the best result for Normal Textures rendered in Maya.
					// This answer also makes sense as in the original problem with the texture, the r value was inverted.
					float4 normalFloat4 = tex2D(_NormalTex, vs.uv);
					float3 normalDirectionTex = normalize(normalFloat4.rgb);
					float3 inputNormal = float3(normalDirectionTex.r * -1, normalDirectionTex.g, normalDirectionTex.b);
					ps.normal = float4(inputNormal * 0.5 + 0.5, 1);
					
					// Return Emissive GBuffer.
					ps.emission = float4(0, 0, 0, 1);
					ps.emission.rgb = ProcessEmission(colourFloat4.rgb);
					
					#ifndef UNITY_HDR_ON
					ps.emission.rgb = exp2(-ps.emission.rgb);
					#endif

					// Return Depth GBuffer.
					ps.depthSV = z;
					
					return ps;
				}
            ENDCG
        }
    }
}
