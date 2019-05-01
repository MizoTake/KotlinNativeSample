using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallKotlinNative : MonoBehaviour
{
    private Text viewableText;

    void Start()
    {
        var pluginMessage = "";
#if UNITY_ANDROID
        using (var plugin = new AndroidJavaObject("com.sample.mizotake.kotlinnativeforunity.common"))
        {
            pluginMessage = plugin.Call<string>("createApplicationScreenMessage");
            Debug.Log(pluginMessage);
        }
#endif
        viewableText = GetComponent<Text>();
        viewableText.text = pluginMessage;
    }
}