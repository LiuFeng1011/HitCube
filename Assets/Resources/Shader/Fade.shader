// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/Fade"
{
    Properties
    {
        [KeywordEnum(X, Y)] _FadeWith ("Fade With", Float) = 0
         _Color1 ("Color1", Color) = (1.0,1.0,1.0,1.0)
         _Color2 ("Color2", Color) = (0.0,0.0,0.0,1.0)
        [PowerSlider(1)] _Weights ("Weights", Range (0.0, 2.0)) = 1.0
    }
    SubShader
    {
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

            fixed4 _Color1;
            fixed4 _Color2;
            float _Weights;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            //注意，uv的最大值是(1, 1)
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col;
                float edge = step(i.uv.y,0.5);


                fixed dx = i.uv.x - 0.5;
                fixed dy = i.uv.y - 0.5;

                fixed centerdis =  1-(max(0,sqrt(dx*dx+dy*dy)-0.5)) * _Weights;
                _Color1 = _Color1 * centerdis;
                _Color2 = _Color2 * centerdis;

                col = lerp(_Color1, _Color2, ((i.uv.y - 0.3) * 2.5) * edge + ( i.uv.y + (i.uv.y - 0.5) * 1.5) * (1-edge) );

                return col;
            }
            ENDCG

        }
    }
}