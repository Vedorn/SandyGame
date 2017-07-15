using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneStart : MonoBehaviour {
    public Player FollowTarget;
    public float speed;
    public float hoverForce;
    public float hoverHeight;
    private Rigidbody droneRigidbody;
    public float followDistance;
    // Use this for initialization
    void Awake()
    {
        droneRigidbody = GetComponent<Rigidbody>();
    }

    void Start () {
		
	}
	
	void Update () {
        Follow();
	}

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) / hoverHeight;
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;
            droneRigidbody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }
    }

    void Follow()
    {       
        FollowTarget = FindObjectOfType<Player>();
        transform.position = (transform.position - FollowTarget.transform.position).normalized * followDistance + FollowTarget.transform.position;
        
    }
}
