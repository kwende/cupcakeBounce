using UnityEngine;
using System.Collections;

public class Cannon : MonoBehaviour {

	public GameObject ToFire; 

	private bool _fuseLit = false; 
	private int _count = 0; 

	public void LightFuse(){
		_fuseLit = true; 
	}

	private void Fire(){
		Rigidbody2D rigidBody = this.gameObject.GetComponent<Rigidbody2D> (); 
		rigidBody.AddForce (new Vector2 (-1000, 0)); 

		GameObject cannonBall = Instantiate (ToFire); 

		GameObject emitter = this.gameObject.transform.FindChild ("emitter").gameObject;  

		AudioSource source = this.GetComponent<AudioSource>(); 
		
		if(!source.isPlaying)
		{
			source.Stop(); 
		}
		source.Play(); 

		Rigidbody2D rigidCannoBall = cannonBall.GetComponent<Rigidbody2D> (); 
		rigidCannoBall.position = emitter.transform.position;
		rigidCannoBall.velocity = new Vector2 (35, 5); 
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (_fuseLit) {
			_count++; 

			if(_count > 60){
				Fire (); 

				_fuseLit = false; 
			}
		}
	}
}
