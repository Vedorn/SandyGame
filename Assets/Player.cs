using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Player : MonoBehaviour
{
    NavMeshAgent navAgent;
    public GameObject projectile;

    // Use this for initialization
    void throwDrone()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
        	Vector3 droneSpawnPos = new Vector3(transform.position.x + transform.forward.x, transform.position.y + 1, transform.position.z + transform.forward.z);
            GameObject drone = Instantiate(projectile, droneSpawnPos, Quaternion.identity) as GameObject;
        }
    }
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void clickToMove()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0)) // 0 is Left-Click, 1 is Right-Click
        {
            if (Physics.Raycast(ray, out hit, 100))
            {
                navAgent.SetDestination(hit.point);
            }
        }
    }
    void Update()
    {
        clickToMove();
        throwDrone();
    }
}