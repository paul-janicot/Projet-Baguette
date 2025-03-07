
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Script : MonoBehaviour
{
    

    [SerializeField] private float patrolRange; //Distance the actor will travel in a straight line (random roam only)
    [SerializeField] private float sightRange; //Distance at which the actor will detect the player
    [SerializeField] private float fieldOfView; //the angle at which the enemy sees
    [SerializeField] private float shootingRange; //At what distance does the enemy shoots ya
    [SerializeField] private float shootingSpeed; //How fast do they shoot

    private NavMeshAgent agent; 
    private Transform _transform;
    private Transform _spawn;
    private bool playerSeen;
    private float eyeCheck; //How often do they check their surrounding for players
    private float shootCheck; //Just a timer for the shooting
    private GameObject _player; 

    public LayerMask playerMask;
    public LayerMask obstacleMask;
    public GameObject projectile;
    

    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _transform = GetComponent<Transform>();
        _player = PlayerMovement.instance.gameObject;
        _spawn = transform.GetChild(0);

    }

    // Update is called once per frame
    void Update()
    {
        eyeCheck -= Time.deltaTime;
        shootCheck -= Time.deltaTime;
        
        if (eyeCheck <= 0) { FieldOfView();  eyeCheck = 0.2f; } //Check for players
        if (!playerSeen && agent.remainingDistance <= agent.stoppingDistance) //When I arrive I pick anoter destination
        {
            Vector3 point;
            if (RandomRoam(_transform.position, patrolRange, out point)) //pass in our centre point and radius of area
            {
                agent.SetDestination(point);
            }
        }
        else if (playerSeen)
        {
            agent.SetDestination(_player.transform.position); //Go to player if you see them


            if (agent.remainingDistance <= shootingRange) //Stop if you're in shooting range and shoot
            {
                if (shootCheck <= 0) { Shoot(); agent.isStopped = true; shootCheck = shootingSpeed; }
            }
            else { agent.isStopped = false; }
        }
        else { agent.isStopped = false; }
    }

       private void Shoot() 
       {
        Debug.Log("Shooting");
        _transform.LookAt(_player.transform); //Shoot in the direction of the player
        Instantiate(projectile, _spawn.position, _spawn.rotation);
        }

        bool RandomRoam(Vector3 center, float range, out Vector3 result)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }

            result = Vector3.zero;
            return false;
        } 
    

        private void FieldOfView()
        {
        Collider[] seeing = Physics.OverlapSphere(_transform.position, sightRange, playerMask);

            if (seeing.Length != 0) //Is the player in the seeing range
            {
                Transform player = seeing[0].transform; //To change for a reference to the player singleton
                Vector3 directionToPlayer = (player.position - _transform.position).normalized;

                if (Vector3.Angle(_transform.forward, directionToPlayer) < fieldOfView / 2) //Is the player in the Field of view
                {
                    float distanceToPlayer = Vector3.Distance(_transform.position, player.position);
                    if (!Physics.Raycast(_transform.position, directionToPlayer, distanceToPlayer, obstacleMask)) //Is there a wall between the player and the enemy
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

