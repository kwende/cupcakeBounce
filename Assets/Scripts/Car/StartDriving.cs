using UnityEngine;
using System.Collections;

public class StartDriving : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter2D(Collider2D collidedWith){
		this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D> ().velocity = 
			new Vector2 (30, 0); 
	}
}
