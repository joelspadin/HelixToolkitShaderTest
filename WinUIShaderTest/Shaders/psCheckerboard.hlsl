#ifndef PSCHECKERBOARD_HLSL
#define PSCHECKERBOARD_HLSL

#define CLIPPANE
#define MESH

#include "Common.hlsl"
#include "DataStructs.hlsl"

static const float Size = 8;
    
static const float Dark = 180.0 / 255.0;
static const float Light = 1;
    
static const float4 DarkColor = { Dark, Dark, Dark, 1 };
static const float4 LightColor = { Light, Light, Light, 1 };
static const float4 LightOffset = LightColor - DarkColor;

float4 main(PSInput input) : SV_Target
{    
    float2 pos = floor(input.p.xy / Size);
    float mask = fmod(pos.x + fmod(pos.y, 2), 2);

    return DarkColor + LightColor * mask;
}

#endif