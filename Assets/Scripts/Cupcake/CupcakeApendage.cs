using UnityEngine;
using System.Collections;

public class CupcakeApendage : MonoBehaviour {

	void Start(){
	}

	void OnCollisionEnter2D(Collision2D collidedWith){
		if (collidedWith.rigidbody != null && 
		    collidedWith.rigidbody.velocity.magnitude > 10) {
			// splinter. 
			DistanceJoint2D joint = this.gameObject.GetComponent<DistanceJoint2D> (); 
			joint.enabled = false;
		}
	}
}
