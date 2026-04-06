using UnityEngine;
using StarterAssets;
using UnityEngine.AI;
public class Robot : MonoBehaviour
{
    FirstPersonController controller;
   // [SerializeField] Transform target;
    NavMeshAgent agent;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        controller = FindObjectOfType<FirstPersonController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != null)
        {
            agent.SetDestination(controller.transform.position);
        }
    }
}
