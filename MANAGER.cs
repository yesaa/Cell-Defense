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
		float x = Camera.main.transform.position.x + Random.Range (-10, 10);
		float y = Camera.main.transform.position.y + Random.Range (-10, 10);


		if (x < PlayerSize / 2 && x > -PlayerSize / 2 && x >= 0) {

			x = PlayerSize / 2 + 1;		
		}

		if (x < PlayerSize / 2 && x > -PlayerSize / 2 && x < 0) {

			x = -PlayerSize / 2 - 1;		
		}

		if (y < PlayerSize / 2 && y > -PlayerSize / 2 && y >= 0) {

			y = PlayerSize / 2 + 1;		
		}

		if (y < PlayerSize / 2 && y > -PlayerSize / 2 && y < 0) {

			y = -PlayerSize / 2 - 1;		
		}

		Vector3 pos = new Vector3 (x, y, 0);
		GameObject ennemy =  (GameObject)Instantiate (prefab, pos, Quaternion.identity);
		ennemy.GetComponent<SatelliteScript> ().health = health;
		ennemy.transform.localScale = new Vector3(health, health, health);
		ennemy.GetComponent<SatelliteScript> ().CheckPlayerSize();

	}
}
