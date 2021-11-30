Shader "Custom/Unlit/Grid" {
    Properties{
        _LineColor("Line Color", Color) = (1,1,1,1)
        [NoScaleOffset] _MainTex("Texture", 2D) = "white" {}
        [IntRange] _SplitCount("Split Count", Range(1, 100)) = 10
        _LineSize("Line Size", Range(0.01, 1)) = 0.1
        _CpPosition("CenterPoint Position", Vector) = (0,0,0,1)
        _MinThreshold("Min Distance Threshold", Float) = 10
        _MaxThreshold("Max Distance Threshold", Float) = 100
        _FarColor("Far Color", Color) = (0,0,0,1)
    }
        SubShader{
            Tags { "RenderType" = "Opaque" }

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
                    float3 vertex_world :TEXCOORD1;
                };

                sampler2D _MainTex;

                fixed4 _LineColor;
                float _SplitCount;
                float _LineSize;

                fixed4 _FarColor;
                float4 _CpPosition;
                float _MinThreshold;
                float _MaxThreshold;

                v2f vert(appdata v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    o.vertex_world = mul(unity_ObjectToWorld, v.vertex).xyz;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                     float dst = length(i.vertex_world - _CpPosition);
                     float fadelevel = (dst - _MinThreshold) / (_MaxThreshold - _MinThreshold);
                     fadelevel = clamp(fadelevel, 0, 1);

                    return lerp(
                        tex2D(_MainTex, i.uv),
                        _LineColor,
                        saturate(
                            (frac(i.uv.x * (_SplitCount + _LineSize)) < _LineSize) +
                            (frac(i.uv.y * (_SplitCount + _LineSize)) < _LineSize)
                        )
                    ) * (1 - fadelevel) + _FarColor * fadelevel;
                }
                ENDCG
            }
        }
}