using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float speed;
	public Text countText;
	public Text winText;
	private int count;

	void Start() {
		count = 0;
		this.UpdateCountText();
		this.winText.text = "";
	}

	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		rigidbody.AddForce(movement * this.speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);	
			this.count++;
			this.UpdateCountText();
		}
	}

	void UpdateCountText() {
		this.countText.text = "Count: " + count.ToString();

		if (this.count >= 12)
			this.winText.text = "You Win";
	}
}
