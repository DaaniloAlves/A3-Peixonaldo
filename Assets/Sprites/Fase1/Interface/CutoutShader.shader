Shader "Unlit/CutoutShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _CutoutCenter ("Cutout Center", Vector) = (0.5, 0.5, 0, 0)
        _CutoutRadius ("Cutout Radius", Float) = 0.2
        _Color ("Color", Color) = (0, 0, 0, 0.8)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _CutoutCenter;
            float _CutoutRadius;
            float4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float dist = distance(uv, _CutoutCenter.xy);

                if (dist < _CutoutRadius)
                {
                    // Transparente dentro do recorte
                    return float4(0, 0, 0, 0);
                }

                // Cor escura fora do recorte
                return _Color;
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}