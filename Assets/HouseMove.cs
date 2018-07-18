using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HouseMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Button Pressed Handler 
    bool buttonDown = false;

    public GameObject House;


    private GameObject[] MainCamera;
    private Transform transMainCamera;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {
        if (MainCamera == null)
        {
            MainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
            transMainCamera = MainCamera[0].GetComponent<Transform>();
        }

        if (buttonDown)
        {
            House.gameObject.transform.position += transMainCamera.forward.normalized / 10;
          //  _ShowAndroidToastMessage("Pressed");
        }
	}

    public void House_Forward()
    {
        //House.gameObject.transform.position += new Vector3(1.0f, 0, 0);

        House.gameObject.transform.position += transMainCamera.forward.normalized / 10;
    }

    public void House_Back()
    {
        House.gameObject.transform.position += new Vector3(-1.0f, 0, 0);
    }

    public void House_Left()
    {
        House.gameObject.transform.position += new Vector3(0.0f, 0, 1.0f);
    }

    public void House_Right()
    {
        House.gameObject.transform.position += new Vector3(0.0f, 0, -1.0f);
    }

    public void OnPointerDown(PointerEventData ped)
    {
        buttonDown = true;
    }

    public void OnPointerUp(PointerEventData ped)
    {
        buttonDown = false;
    }

    /// <summary>
    /// Show an Android toast message.
    /// </summary>
    /// <param name="message">Message string to show in the toast.</param>
    private void _ShowAndroidToastMessage(string message)
    {
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

        if (unityActivity != null)
        {
            AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");
            unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
            {
                AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", unityActivity,
                    message, 0);
                toastObject.Call("show");
            }));
        }
    }

}
