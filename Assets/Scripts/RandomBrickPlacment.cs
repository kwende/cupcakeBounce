using UnityEngine;
using System.Collections;

public class RandomBrickPlacment : MonoBehaviour {

	public GameObject FiveBrick; 
	public GameObject OneBrick; 
	public GameObject ThreeBrick; 

	// Use this for initialization
	void Start () {
	
		/*int numberOfSixBricks = Random.Range (1, 3); 
		int numberOfThreeBricks = Random.Range (1, 4); 
		int numberOfOneBrick = Random.Range (1, 6); 

		for (int c=0; c<numberOfSixBricks; c++) {
			int x = Random.Range(-15, 15); 
			int y = Random.Range(-10, 10); 

			Instantiate(FiveBrick, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0)); 
		}

		for (int c=0; c<numberOfThreeBricks; c++) {
			int x = Random.Range(-15, 15); 
			int y = Random.Range(-10, 10); 
			
			Instantiate(ThreeBrick, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0)); 
		}

		for (int c=0; c<numberOfOneBrick; c++) {
			int x = Random.Range(-15, 15); 
			int y = Random.Range(-10, 10); 
			
			Instantiate(OneBrick, new Vector3(x, y, 0), new Quaternion(0, 0, 0, 0)); 
		}*/
	}
}
