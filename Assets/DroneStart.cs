using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneStart : MonoBehaviour {
    Player OrbitTarget;

    float speed = (2 * Mathf.PI) / 4;
    float angleOfRotation = 0.0f;
    float radius = 1.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        OrbitAround();
	}
    
    void OrbitAround()
	{
		angleOfRotation += speed * Time.deltaTime;
		OrbitTarget = FindObjectOfType<Player>();
		float x = Mathf.Cos(angleOfRotation) * radius + OrbitTarget.transform.position.x;
		float z = Mathf.Sin(angleOfRotation) * radius + OrbitTarget.transform.position.z;
		transform.position = new Vector3(x, OrbitTarget.transform.position.y + 1, z);
//		transform.position = new Vector3(OrbitTarget.transform.position.x + 2, OrbitTarget.transform.position.y, OrbitTarget.transform.position.z + 2);
//		transform.RotateAround(OrbitTarget.transform.position, new Vector3(0, 1, 0), 90 * Time.deltaTime);
    }
}
