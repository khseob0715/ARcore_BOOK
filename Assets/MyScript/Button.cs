using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour {

    public Color defaultColor;
    public Color selectedColor;

    private Material mat;
    

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

	void OnTouchDown()
    {
        this.gameObject.SetActive(false);
    }

    void OnTouchUP()
    {
        mat.color = defaultColor;
    }

    void OnTouchStay()
    {
        mat.color = selectedColor;
    }
    void OnTouchExit()
    {
        mat.color = defaultColor;
    }
}
