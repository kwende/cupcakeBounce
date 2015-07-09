using UnityEngine;
using System.Collections;

public class BumperBounce : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		Rigidbody2D rigidBody = collisionObject.GetComponent<Rigidbody2D> (); 

		Vector2 offset = collisionObject.transform.position - transform.position; 

		Vector2 newVelocity = offset.normalized * 15f; //rigidBody.velocity.magnitude * 1.1f;
		Vector2 originalVelocity = rigidBody.velocity.normalized; 

		Vector2 flippedOriginalVelocity = originalVelocity * -1.0f; 
		Vector2 newVelocityNormalized = newVelocity.normalized; 

		float dotProduct = Vector2.Dot (flippedOriginalVelocity, newVelocityNormalized); 

		float angleInRadians = Mathf.Acos (dotProduct); 

		float angularVelocityInDegrees = angleInRadians * 180.0f / Mathf.PI;  

		rigidBody.angularVelocity = -2 * angularVelocityInDegrees * Mathf.Sign(newVelocity.x); 

		rigidBody.velocity = newVelocity; 
	}
}
