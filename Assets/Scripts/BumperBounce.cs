using UnityEngine;
using System.Collections;

public class BumperBounce : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		Rigidbody2D rigidBody = collisionObject.GetComponent<Rigidbody2D> (); 

		PolygonCollider2D me = this.GetComponent<PolygonCollider2D> (); 
		PolygonCollider2D other = collisionObject as PolygonCollider2D; 

		Vector2[] myPoints = me.points; 
		Vector2[] otherPoints = other.points; 

		Vector2 myEdgePoint = new Vector2(), otherEdgePoint = new Vector2(); 
		float closestDistance = float.MaxValue; 

		foreach (Vector2 myPoint in myPoints) {
			foreach(Vector2 otherPoint in otherPoints){
				float mag = (myPoint - otherPoint).sqrMagnitude; 

				if(mag < closestDistance){
					myEdgePoint = myPoint; 
					otherEdgePoint = otherPoint; 

					closestDistance = mag;
				}
			}
		}

		Vector2 newVelocity = (collisionObject.transform.position - transform.position).normalized * 15f; 

		Vector2 flippedOriginalVelocity = rigidBody.velocity.normalized * -1.0f; 
		Vector2 newVelocityNormalized = newVelocity.normalized; 

		float dotProduct = Vector2.Dot (flippedOriginalVelocity, newVelocityNormalized); 

		RaycastHit2D hit = Physics2D.Raycast (rigidBody.transform.position, rigidBody.velocity); 

		Vector2 hitPoint = hit.point; 
		Vector2 centerOfObject = rigidBody.centerOfMass; 

		//rigidBody.angularVelocity = dotProduct * rigidBody.velocity.magnitude * -20 * Mathf.Sign(newVelocity.x); 
		rigidBody.AddForceAtPosition(-newVelocity * 2, centerOfObject); 
		rigidBody.velocity = newVelocity; 
	}
}
