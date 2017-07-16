using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    
    float xDistance = 0;
    float yDistance = -7.5f;
    float zDistance = 3.77f;
    float zoomInLimit;
    float zoomOutLimit;
    float zoomFactor = 10.0f;

    Player target;
    void Start () {
        zoomInLimit = yDistance / 2;
        zoomOutLimit = yDistance * 1.5f;
        target = FindObjectOfType<Player>();
    }
	
	// Update is called once per frame

    void Zoom(){
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) {
            if(yDistance <= zoomInLimit) {
                float yIncrement = yDistance / zoomFactor;
                float zIncrement = zDistance / zoomFactor;
                yDistance -= yIncrement;
                zDistance -= zIncrement;
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) { // backwards 
            if(yDistance >= zoomOutLimit) {

                float yIncrement = yDistance / zoomFactor;
                float zIncrement = zDistance / zoomFactor;
                yDistance = yDistance += yIncrement;
                zDistance = zDistance += zIncrement;
            }
        }
    }
    void Update() {
        Zoom();
        transform.position = new Vector3(target.transform.position.x + target.GetComponent<CapsuleCollider>().center.x - xDistance, target.transform.position.y + target.GetComponent<CapsuleCollider>().center.y - yDistance, target.transform.position.z + target.GetComponent<CapsuleCollider>().center.z - zDistance);
    }
}
