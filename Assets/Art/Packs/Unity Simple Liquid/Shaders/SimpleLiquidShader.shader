Shader"Liquid/SimpleLiquidShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _Metallic ("Metallic", Range(0,1)) = 0
        _Smoothness ("Smoothness", Range(0,1)) = 0.3
        _SurfaceLevel ("Liquid Surface Level", Vector) = (0,1,0,0)
        _GravityDirection ("Gravity direction", Vector) = (0,-1,0,0)
    }

    SubShader
    {
        Tags { "Queue" = "Transparent+1" "RenderType" = "Cutout" }

ZWrite Off

Cull Off

Blend SrcAlpha
OneMinusSrcAlpha

        CGPROGRAM
        #pragma surface surf Standard

#include "UnityCG.cginc"

struct Input
{
    float2 uv_MainTex;
};

float4 _GravityDirection;
float4 _SurfaceLevel;
fixed4 _Color;
half _Metallic;
half _Smoothness;

void surf(Input IN, inout SurfaceOutputStandard o)
{
    o.Metallic = _Metallic;
    o.Smoothness = _Smoothness;
    //o.Albedo = _Color.rgb;
    //o.Alpha = _Color.a;
}
        ENDCG

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#include "UnityCG.cginc"

struct appdata
{
    float4 vertex : POSITION;
};

struct v2f
{
    float4 vertex : SV_POSITION;
    float4 worldPos : POSITION1;
};

float4 _GravityDirection;
float4 _SurfaceLevel;
fixed4 _Color;

v2f vert(appdata v)
{
    v2f o;
    o.worldPos = mul(unity_ObjectToWorld, v.vertex);
    o.vertex = UnityObjectToClipPos(v.vertex);
    return o;
}

fixed4 frag(v2f i) : SV_Target
{
    float dotProd1 = dot(_SurfaceLevel - i.worldPos, _GravityDirection);
    if (dotProd1 > 0)
        discard;

    return _Color;
}
            ENDCG
        }
    }

FallBack"Diffuse"
}
