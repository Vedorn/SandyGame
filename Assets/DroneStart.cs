using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneStart : MonoBehaviour {
    Player OrbitTarget;

    float speed = (2 * Mathf.PI) / 4;
    float angleOfRotation = 0.0f;
    float radius = 2.0f;
    Vector3 position;

    bool spawnAnimation = true;

	// Use this for initialization
	void Start () {      
		OrbitTarget = FindObjectOfType<Player>();
	}
	
	// Update is called once per frame
	void Update () {

		angleOfRotation += speed * Time.deltaTime;
		float x = Mathf.Cos(angleOfRotation) * radius + OrbitTarget.transform.position.x;
		float z = Mathf.Sin(angleOfRotation) * radius + OrbitTarget.transform.position.z;

		if (spawnAnimation) {
			StartCoroutine(Spawn(x, z));
		}
//		transform.GetComponent<Rigidbody>().useGravity = true;
        OrbitAround(x, z);
	}

	IEnumerator Spawn (float x, float z) {
		position = new Vector3(x, OrbitTarget.transform.position.y + 1, z);
		float timeSinceStarted = 0f;
		while(true) {
			timeSinceStarted += Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, position, timeSinceStarted / 20);
			if (transform.position == position) {
				yield break;
			}
			yield return null;
		}
	}

    void OrbitAround(float x, float z) {
		position = new Vector3(x, OrbitTarget.transform.position.y + 1, z);
		transform.position = Vector3.Lerp(transform.position, position, Time.deltaTime);

//		transform.position = new Vector3(OrbitTarget.transform.position.x + 2, OrbitTarget.transform.position.y, OrbitTarget.transform.position.z + 2);
//		transform.RotateAround(OrbitTarget.transform.position, new Vector3(0, 1, 0), 90 * Time.deltaTime);
    }
}
