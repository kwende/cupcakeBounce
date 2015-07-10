using UnityEngine;
using System.Collections;

public class BumperBounce : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collisionObject)
	{
		Rigidbody2D rigidBody = collisionObject.GetComponent<Rigidbody2D> (); 
		Rigidbody2D myRigidBody = this.GetComponent<Rigidbody2D> (); 

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

		Vector2 otherCenterOfMass = rigidBody.centerOfMass; 
		Vector2 myCenterOfMass = myRigidBody.centerOfMass; 

		// distance between center of mass of object and me. 
		float distance = (otherCenterOfMass - myCenterOfMass).magnitude; 
	

		Vector2 impactPoint = (myEdgePoint + otherEdgePoint) / 2; 

		Vector2 offset = (impactPoint - otherCenterOfMass); 
		Vector2 offset2 = (otherCenterOfMass - impactPoint); 

		float direction = (impactPoint - otherCenterOfMass).magnitude; 

		Vector2 newVelocity = (collisionObject.transform.position - transform.position).normalized * 15f; 

		Vector2 flippedOriginalVelocity = rigidBody.velocity.normalized * -1.0f; 
		Vector2 newVelocityNormalized = newVelocity.normalized; 

		float dotProduct = Vector2.Dot (flippedOriginalVelocity, newVelocityNormalized); 

		rigidBody.angularVelocity = dotProduct * rigidBody.velocity.magnitude * -20 * Mathf.Sign(direction); 
		rigidBody.velocity = newVelocity; 
	}
}
