
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Script : MonoBehaviour
{
    private NavMeshAgent agent;

    [SerializeField] private float travelRange; //Distance the actor will travel in a straight line (random roam only)
    [SerializeField] private float sightRange; //Distance at which the actor will detect the player
    [SerializeField] private float fieldOfView; //the angle at which the enemy sees
    private Transform _transform;


    public LayerMask playerMask;
    public LayerMask obstacleMask;

    public GameObject _player; //Placeholder until singleton

    private bool playerSeen;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _transform = GetComponent<Transform>();
        _player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Invoke("FieldOfView", 0.2f);

        if (!playerSeen && agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomRoam(_transform.position, travelRange, out point)) //pass in our centre point and radius of area
            {
                agent.SetDestination(point);
            }
        }
        else if (playerSeen)
        {
            agent.SetDestination(_player.transform.position);
        }
        Debug.Log(playerSeen);

    }

        bool RandomRoam(Vector3 center, float range, out Vector3 result)
        {

            Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                //the 1.0f is the max distance from the random point to a point on the navmesh, might want to increase if range is big
                //or add a for loop like in the documentation
                result = hit.position;
                return true;
            }

            result = Vector3.zero;
            return false;
        } 
    

        private void FieldOfView()
        {
        Debug.Log(playerSeen);
        Collider[] seeing = Physics.OverlapSphere(_transform.position, sightRange, playerMask);

            if (seeing.Length != 0) //Is the player in the seeing range
            {
                Transform player = seeing[0].transform; //To change for a reference to the player singleton
                Vector3 directionToPlayer = (player.position - _transform.position).normalized;

                if (Vector3.Angle(_transform.forward, directionToPlayer) < fieldOfView / 2) //Is the player in the Field of view
                {
                    float distanceToPlayer = Vector3.Distance(_transform.position, player.position);
                    if (!Physics.Raycast(_transform.position, directionToPlayer, distanceToPlayer, obstacleMask))
                    {
                        playerSeen = true;
                    }
                    else { playerSeen = false; }
                }
                else { playerSeen = false; }
            }
            else { playerSeen = false; }
        }
    }

