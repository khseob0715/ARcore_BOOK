using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    bool buttonDown = false;

    public GameObject Change_Tree_To_Portal;
    private GameObject Disable_Object;
    private float Change_time = 10.0f;
    private float Start_time = 0.0f;

    public GameObject ArrowButtonGroup;
    private GameObject UserObject;

    void Start()
    {
        ArrowButtonGroup.SetActive(false);
    }

    void Update()
    {
        if (buttonDown)
        {
            if(UserObject == null)
            {
                UserObject = GameObject.Find("Set(Clone)").transform.GetChild(0).gameObject;
            }
            UserObject.transform.position += new Vector3(0, 0.5f, 0);
            Walking_Rope_anim.enable_check = !Walking_Rope_anim.enable_check;
            Start_time += Time.deltaTime;
            if (Start_time >= Change_time)
            {
                Disable_Object = GameObject.Find("Set(Clone)");
                Disable_Object.SetActive(false);
                Change_Tree_To_Portal.SetActive(true);
                ArrowButtonGroup.SetActive(true);
                GameObject.Find("Button (1)").SetActive(false);
            }
        }
    }

    public void OnPointerDown(PointerEventData ped)
    {
        buttonDown = true;
    }
    public void OnPointerUp(PointerEventData ped)
    {
        buttonDown = false;
    }
}