Shader "Custom/InstancedHealthBar"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
        _Color ("Full Health Color", Color) = (0, 1, 0, 1)
        _EmptyColor ("Empty Health Color", Color) = (1, 0, 0, 1)
        _FillAmount ("Fill Amount", Range(0, 1)) = 1.0
    }

    SubShader
    {
        Tags 
        { 
            "Queue"="Transparent" 
            "IgnoreProjector"="True" 
            "RenderType"="Transparent" 
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        }

        Cull Off
        Lighting Off
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing

            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex   : POSITION;
                float4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f
            {
                float4 vertex   : SV_POSITION;
                fixed4 color    : COLOR;
                float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            sampler2D _MainTex;

            UNITY_INSTANCING_BUFFER_START(Props)
                UNITY_DEFINE_INSTANCED_PROP(fixed4, _Color)
                UNITY_DEFINE_INSTANCED_PROP(fixed4, _EmptyColor)
                UNITY_DEFINE_INSTANCED_PROP(float, _FillAmount)
            UNITY_INSTANCING_BUFFER_END(Props)

            v2f vert(appdata_t IN)
            {
                v2f OUT;
                UNITY_SETUP_INSTANCE_ID(IN);
                UNITY_TRANSFER_INSTANCE_ID(IN, OUT);

                OUT.vertex = UnityObjectToClipPos(IN.vertex);
                OUT.texcoord = IN.texcoord;
                OUT.color = IN.color;
                return OUT;
            }

            fixed4 frag(v2f IN) : SV_Target
            {
                UNITY_SETUP_INSTANCE_ID(IN);


                float fill = UNITY_ACCESS_INSTANCED_PROP(Props, _FillAmount);
                fixed4 fullColor = UNITY_ACCESS_INSTANCED_PROP(Props, _Color);
                fixed4 emptyColor = UNITY_ACCESS_INSTANCED_PROP(Props, _EmptyColor);

                fixed4 finalColor = (IN.texcoord.x <= fill) ? fullColor : emptyColor;

                fixed4 texColor = tex2D(_MainTex, IN.texcoord);
                return finalColor * texColor * IN.color;
            }
            ENDCG
        }
    }
}