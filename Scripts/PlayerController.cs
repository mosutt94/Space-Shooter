using UnityEngine;
using System.Collections;
[System.Serializable]
public class Boundary {
	public float xMin, xMax, zMin, zMax; 
}


public class PlayerController : MonoBehaviour {
	public Boundary boundary;
	public Rigidbody rb;
	public float speed;
	public float tilt;
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	public int score;
	public GUIText scoreText;
	// Use this for initialization
	void Start () {
		rb.GetComponent<Rigidbody> ();

	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetButton("Jump") && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
			GetComponent<AudioSource>().Play();
		}
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.velocity = movement * speed; 
		rb.position = new Vector3 (
			Mathf.Clamp(rb.position.x,boundary.xMin,boundary.xMax),
			0.0f,
			Mathf.Clamp(rb.position.z,boundary.zMin, boundary.zMax)
		);
		rb.rotation = Quaternion.Euler(0.0f,0.0f, rb.velocity.x * -tilt);
	}

	public void AddScore(int newScoreValue){
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore(){
		scoreText.text = "Score: " + score;
	}

}
			