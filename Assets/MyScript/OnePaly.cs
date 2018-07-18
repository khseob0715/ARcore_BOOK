using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnePaly : MonoBehaviour {

    private float timer = 3.0f;
    private float delay_time = 0;

    private bool check = true;

    private Animator animator;
	// Use this for initialization
	void Start () {
        animator = this.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (GoogleARCore.Examples.HelloAR.HelloARController.OneTree && check)
        {
            delay_time += Time.deltaTime;
            if(timer < delay_time)
            {
                animator.enabled = false;
                check = false;
            }
        }
    }

}
