using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneStart : MonoBehaviour {
    public float hoverForce;
    public float hoverHeight;
    private Rigidbody droneRigidbody;

    Player OrbitTarget;
    float speed = (2 * Mathf.PI) / 4;
    float angleOfRotation = 0.0f;
    float radius = 2.0f;
    Vector3 position;

    bool spawnAnimation = true;
    void Awake()
    {
        droneRigidbody = GetComponent<Rigidbody>();
    }

    void Start () {
		
		OrbitTarget = FindObjectOfType<Player>();
	}
	
	void Update () {
		if (spawnAnimation) {
			Quaternion angle = Quaternion.LookRotation(OrbitTarget.transform.forward);
			Quaternion target = Quaternion.LookRotation(Vector3.right);

			var forwardA = angle * Vector3.forward;
			var forwardB = target * Vector3.forward;

			var angleA = Mathf.Atan2(forwardA.x, forwardA.z);
			var angleB = Mathf.Atan2(forwardB.x, forwardB.z);

			angleOfRotation = Mathf.DeltaAngle(angleA, angleB);

			float x = Mathf.Cos(angleOfRotation) * radius + OrbitTarget.transform.position.x;
			float z = Mathf.Sin(angleOfRotation) * radius + OrbitTarget.transform.position.z;
			float y = OrbitTarget.transform.position.y + 1;
			StartCoroutine(Spawn(x, y, z));
		} else {
	//		transform.GetComponent<Rigidbody>().useGravity = true;
			angleOfRotation += speed * Time.deltaTime;
			float x = Mathf.Cos(angleOfRotation) * radius + OrbitTarget.transform.position.x;
			float z = Mathf.Sin(angleOfRotation) * radius + OrbitTarget.transform.position.z;
			float y = OrbitTarget.transform.position.y + 1;
	        OrbitAround(x, y, z);
		}
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

	IEnumerator Spawn (float x, float y, float z) {
		position = new Vector3(x, y, z);
		float timeSinceStarted = 0f;
		spawnAnimation = false;
		while(true) {
			timeSinceStarted += Time.deltaTime;
			transform.position = Vector3.Lerp(transform.position, position, timeSinceStarted / 20);
			if (transform.position == position) {
				yield break;
			}
			yield return null;
		}
	}

	void OrbitAround(float x, float y, float z) {
		position = new Vector3(x, y, z);
		transform.position = Vector3.Lerp(transform.position, position, 5 * Time.deltaTime);
    }
}
