using UnityEngine;
using System.Collections;

public class RandomRotator : MonoBehaviour {
	public Rigidbody rb;
	public float tumble;
	// Use this for initialization
	void Start () {
		rb.GetComponent<Rigidbody> ();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
