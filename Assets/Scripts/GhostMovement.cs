using UnityEngine;
using System.Collections;

public class GhostMovement : MonoBehaviour {


    public NavMeshAgent navMeshAgent;
    Vector3 point;

    public float range = 10.0f;


    bool RandomPoint(Vector3 center, float range, out Vector3 result) {
        for (int i = 0; i < 30; i++) {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;

            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(navMeshAgent.destination);
        if (RandomPoint(transform.position, range, out point)) {
            //Debug.Log(point);
            Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f);
            navMeshAgent.SetDestination(point);
        }
	}
}
