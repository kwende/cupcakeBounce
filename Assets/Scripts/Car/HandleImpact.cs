using UnityEngine;
using System.Collections;

public class HandleImpact : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D collidedWith){

		Rigidbody2D myRigidBody = this.gameObject.transform.parent.gameObject.GetComponent<Rigidbody2D> (); 
		
		float myMomentum = myRigidBody.velocity.magnitude * myRigidBody.mass; 
		float theirMomentum = 0; 

		if (collidedWith.rigidbody != null) {
			theirMomentum = collidedWith.rigidbody.velocity.magnitude * collidedWith.rigidbody.mass; 
		}
		
		if (myMomentum > 2 || 
		    theirMomentum > 2) {
			Car carInstance = this.gameObject.transform.parent.gameObject.GetComponent<Car> (); 
			carInstance.ChangeToSmashed();  
		}
	}
}
