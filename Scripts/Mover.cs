﻿using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public Rigidbody rb;
	public float speed;
	// Use this for initialization
	void Start () {
		rb.GetComponent<Rigidbody> ();
		rb.velocity =transform.forward * speed;
	}
	

}
