using UnityEngine;
using System.Collections;

public class BumperBounce : MonoBehaviour {
	
	void OnMouseDown()
	{
		Debug.Log ("MouseDown."); 
	}

	void OnMouseDrag()
	{
		Vector3 currentPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition); 
		currentPosition.z = transform.position.z; 

		transform.position = currentPosition; 
	}

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

		AudioSource source = this.GetComponent<AudioSource>(); 
		
		if(!source.isPlaying)
		{
			source.Stop(); 
		}
		source.Play(); 

		Vector2 newVelocity = (collisionObject.transform.position - transform.position).normalized * 15f; 
		Vector2 centerOfObject = rigidBody.centerOfMass; 

		rigidBody.AddForceAtPosition(-newVelocity * 2, centerOfObject); 
		rigidBody.velocity = newVelocity; 
	}
}
