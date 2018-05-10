using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnChange : MonoBehaviour
{
	private int BtnTag = 0;	// tag = 0 --- continue动画, 	tag = 1 --- quit动画, 	tag = 2 --- start动画
	private Animator anim;
	void Start ()
	{
		anim = GetComponent<Animator> ();
	}

	void Update () 
	{
		//Debug.Log (tag);
		if (BtnTag == 0)
		{
			anim.SetBool ("continue", true);
			anim.SetBool ("quit", false);
			anim.SetBool ("start", false);
		}
		else if (BtnTag == 1)
		{
			anim.SetBool ("continue", false);
			anim.SetBool ("quit", true);
			anim.SetBool ("start", false);
		}
		else if (BtnTag == 2) 
		{
			anim.SetBool ("continue", false);
			anim.SetBool ("quit", false);
			anim.SetBool ("start", true);
		}
		if (Input.GetKeyDown (KeyCode.DownArrow))
			BtnTag++;
		if (BtnTag > 2)
			BtnTag = 0;
	}
}
