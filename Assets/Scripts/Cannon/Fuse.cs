using UnityEngine;
using System.Collections;

public class Fuse : MonoBehaviour {

	private GameObject _cannon; 

	void Start(){
		_cannon = this.gameObject.transform.parent.gameObject; 
	}

	void OnTriggerEnter2D(Collider2D collidedWith){
		Renderer renderer = this.gameObject.GetComponentInChildren<Renderer> (); 
		renderer.enabled = true; 

		Cannon cannonObject = _cannon.GetComponent<Cannon> (); 
		cannonObject.LightFuse (); 
	}
}
