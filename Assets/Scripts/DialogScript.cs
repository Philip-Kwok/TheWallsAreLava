using UnityEngine;
using System.Collections;

public class DialogScript : MonoBehaviour
{

    const int ButtonWidth = 256;
    const int ButtonHeight = 64;
    private static bool mYesPressed = false;
    private static bool mNoPressed = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

#if UNITY_ANDROID

    private class PositiveButtonListner : AndroidJavaProxy
    {
        private DialogScript mDialog;

        public PositiveButtonListner(DialogScript d)
         : base("android.content.DialogInterface$OnClickListener")
        {
            mDialog = d;
        }

        public void onClick(AndroidJavaObject obj, int value)
        {
            mYesPressed = true;
            mNoPressed = false;
        }
    }

    // Create the postive action listner class
    // It has to be derived from the AndroidJavaProxy class
    // Make the methods as same as that of DialogInterface.OnClickListener
    private class NegativeButtonListner : AndroidJavaProxy
    {
        private DialogScript mDialog;

        public NegativeButtonListner(DialogScript d)
        : base("android.content.DialogInterface$OnClickListener")
        {
            mDialog = d;
        }

        public void onClick(AndroidJavaObject obj, int value)
        {
            mYesPressed = false;
            mNoPressed = true;
        }
    }

    public bool getChoice()
        {
        if(mYesPressed)
        {
            return true;
        }
        else
        {
            return false;
        }
        }


#endif

    public void showDialog(string message)
    {

#if UNITY_ANDROID
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
            AndroidJavaObject alertDialogBuilder = new AndroidJavaObject("android/app/AlertDialog$Builder", activity);
            alertDialogBuilder.Call<AndroidJavaObject>("setMessage", message);
            alertDialogBuilder.Call<AndroidJavaObject>("setCancelable", true);
            alertDialogBuilder.Call<AndroidJavaObject>("setPositiveButton", "Yes", new PositiveButtonListner(this));
            alertDialogBuilder.Call<AndroidJavaObject>("setNegativeButton", "No", new NegativeButtonListner(this));
            AndroidJavaObject dialog = alertDialogBuilder.Call<AndroidJavaObject>("create");
            dialog.Call("show");
        }));
#endif

    }
}