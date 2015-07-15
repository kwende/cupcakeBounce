using UnityEngine;
using System.Collections;
using System.Linq; 

public class Dynamite : MonoBehaviour {

	private bool _timerStarted = false; 
	private int _timerCount= 0; 
	private bool _kaboomed = false; 

	private void SetLight(bool set){
		Renderer[] childRenderers = this.gameObject.GetComponentsInChildren<Renderer> (); 
		foreach (Renderer childRenderer in childRenderers) {
			if(childRenderer.gameObject.name == "spark")
			{
				childRenderer.enabled = set; 
			}
			else if(childRenderer.gameObject != this.gameObject){
				childRenderer.enabled = false; 
			}
		}
	}

	private void SetKaboom(bool set){
		Renderer[] childRenderers = this.gameObject.GetComponentsInChildren<Renderer> (); 
		foreach (Renderer childRenderer in childRenderers) {
			if(childRenderer.gameObject.name == "kaboom")
			{
				childRenderer.enabled = set; 
			}
			else if(childRenderer.gameObject){
				childRenderer.enabled = false; 
			}
		}
	}

	void Start(){
		SetLight (false); 
	}

	void Update(){
		if (_timerStarted) {
			_timerCount++; 

			if(_timerCount > 30 * 6){
				Destroy (this.gameObject); 
			}
			else if(_timerCount > 30 * 5 && !_kaboomed){
				SetKaboom(true); 
				TossNearbyObjects(); 

				_kaboomed = true; 
			}
		}
	}

	private void TossNearbyObjects(){
		AudioSource source = this.GetComponent<AudioSource>(); 
		
		if(!source.isPlaying)
		{
			source.Stop(); 
		}
		source.Play(); 

		Rigidbody2D[] rigidBodies = GameObject.FindObjectsOfType<Rigidbody2D> (); 

		Vector3 myPosition = this.gameObject.transform.position; 

		foreach (Rigidbody2D rigidBody in rigidBodies) {
			Vector3 offsetVector = (rigidBody.position - (Vector2)myPosition);

			if(offsetVector.magnitude < 10){
				rigidBody.velocity = offsetVector.normalized * 20; 
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collidedWith){

		Rigidbody2D rigidBody = this.gameObject.GetComponent<Rigidbody2D> (); 
		if (rigidBody.velocity.magnitude > 1) {
			Debug.Log ("I hit something.");
			_timerStarted = true; 
			SetLight(true); 
		}

		Rigidbody2D otherRigidBody = collidedWith.gameObject.GetComponent<Rigidbody2D> () as Rigidbody2D;  

		bool isNull = otherRigidBody == null; 
		bool isNotNull = otherRigidBody != null; 

		if (otherRigidBody != null) {
			if(otherRigidBody.velocity.magnitude > 1){
				Debug.Log("Something hit me at velocity " + otherRigidBody.velocity.magnitude.ToString()); 
				_timerStarted = true;
				SetLight(true); 
			}
		}
	}
}
