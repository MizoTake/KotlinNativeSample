using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class CallKotlinNative : MonoBehaviour
{

#if UNITY_IOS
    [DllImport("__Internal")]
    private static extern string createApplicationScreenMessage();
#endif

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
#elif UNITY_IOS
        pluginMessage = createApplicationScreenMessage();
#endif
        viewableText = GetComponent<Text>();
        viewableText.text = pluginMessage;
    }
}