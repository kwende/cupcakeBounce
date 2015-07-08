using UnityEngine;
using System.Collections;

public class BumperBounce : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		Rigidbody2D rigidBody = collisionObject.GetComponent<Rigidbody2D> (); 

		Vector2 offset = collisionObject.transform.position - transform.position; 

		rigidBody.velocity = offset.normalized * rigidBody.velocity.magnitude * 1.1f;  
	}
}
