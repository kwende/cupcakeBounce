using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {

	public Sprite CrashedSprite; 

	// Use this for initialization
	void Start () {
	
	}
	
	public void ChangeToSmashed(){
		SpriteRenderer myRenderer = this.gameObject.GetComponent<SpriteRenderer> (); 
		myRenderer.sprite = CrashedSprite; 

		this.gameObject.transform.FindChild ("DriveTrigger").GetComponent<PolygonCollider2D> ().enabled = false; 
	}
}
