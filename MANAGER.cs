using UnityEngine;
using System.Collections;

public class MANAGER : MonoBehaviour {

	// PlayerSize used by other scripts
    public static float PlayerSize;


	public GameObject prefab; // Prefab de l'ennemi à spawn


	void Start (){

		InvokeRepeating ("Spawn", 5,5);

	}


	void Spawn(){
	
		int taille = Random.Range (1, 3);
		float health;

		if (taille == 1) {

			health = PlayerSize - 0.25F;

		} else if (taille == 2) {

			health = PlayerSize;
		
		} else {

			health = PlayerSize + 0.25F;
	
		}
		Debug.Log ("Spawned = " + health);
		Vector3 pos = new Vector3 (Camera.main.transform.position.x + Random.Range(-10,10), Camera.main.transform.position.y + Random.Range(-10,10), 0);
		GameObject ennemy =  (GameObject)Instantiate (prefab, pos, Quaternion.identity);
		ennemy.GetComponent<SatelliteScript> ().health = health;
		ennemy.transform.localScale = new Vector3(health, health, health);
		ennemy.GetComponent<SatelliteScript> ().CheckPlayerSize();

	}
}
