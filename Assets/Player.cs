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
            GameObject bullet = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 150);
            bullet.GetComponent<Rigidbody>().AddForce(transform.up * 450);
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