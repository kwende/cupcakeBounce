using UnityEngine;
using System.Collections;

public class ShowGUI : MonoBehaviour {

	public GameObject Cupcake; 
	public GameObject UIPrefab; 
	private GameObject _windowInstance; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.T) && _windowInstance == null) {
			_windowInstance = Instantiate(UIPrefab); 
			GameObject go = GameObject.Find("TheCanvas"); 
			_windowInstance.transform.SetParent(go.transform, false); 
		} 
		else if (Input.GetKeyDown(KeyCode.T) && _windowInstance != null){
			Destroy(_windowInstance); 
		}

		if (Input.GetKeyDown (KeyCode.B)) {
			GameObject cupcake = Instantiate(Cupcake, new Vector3(0, 10, 0), new Quaternion(0, 0, 0, 0)) as GameObject; 
		}
	}
}
