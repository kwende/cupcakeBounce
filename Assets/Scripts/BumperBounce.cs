using UnityEngine;
using System.Collections;

public class BumperBounce : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		Rigidbody2D rigidBody = collisionObject.GetComponent<Rigidbody2D> (); 

		Vector2 newVelocity = (collisionObject.transform.position - transform.position).normalized * 15f; 

		Vector2 flippedOriginalVelocity = rigidBody.velocity.normalized * -1.0f; 
		Vector2 newVelocityNormalized = newVelocity.normalized; 

		float dotProduct = Vector2.Dot (flippedOriginalVelocity, newVelocityNormalized); 

		RaycastHit2D hit = Physics2D.Raycast (rigidBody.transform.position, rigidBody.velocity); 

		Vector2 hitPoint = hit.point; 
		Vector2 centerOfObject = rigidBody.centerOfMass; 

		rigidBody.angularVelocity = dotProduct * rigidBody.velocity.magnitude * -20 * Mathf.Sign(newVelocity.x); 
		rigidBody.velocity = newVelocity; 
	}
}
