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

        MainCamera = GameObject.FindGameObjectsWithTag("MainCamera");
        transMainCamera = MainCamera[0].GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
		if(House == null)
        {
            House = GameObject.Find("GameObject(Clone)");
        }


        if (buttonDown)
        {
            House.gameObject.transform.position += transMainCamera.forward.normalized / 10;
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

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonDown = false;
    }
}
