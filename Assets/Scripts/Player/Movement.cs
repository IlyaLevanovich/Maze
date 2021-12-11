using System.Collections;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private NavMeshAgent _agent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine(BeginMove());
    }
    private IEnumerator BeginMove()
    {
        yield return new WaitForSeconds(2);
        _agent.SetDestination(_target.position);
    }
}
