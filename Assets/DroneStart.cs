using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneStart : MonoBehaviour {
    public Player OrbitTarget;
    public float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        OrbitAround();
	}
    
    void OrbitAround()
    {
        transform.RotateAround(OrbitTarget.transform.position, new Vector3(0, 1, 0), 90);
    }
}
