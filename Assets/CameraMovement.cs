using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    
    public float xdistance;
    public float ydistance;
    public float zdistance;
    public Player target;
    void Start () {
		
	}
	
	// Update is called once per frame

    void Zoom(){
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(ydistance <= -6)
            { 
            ydistance = ydistance+2;
            zdistance = zdistance-1;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if(ydistance >= -10)
            {
            ydistance = ydistance - 2;
            zdistance = zdistance + 1;
            }
        }
    }
    void Update()
    {
        Zoom();
        transform.position = new Vector3(target.transform.position.x - xdistance, target.transform.position.y - ydistance, target.transform.position.z - zdistance);
    }
}
