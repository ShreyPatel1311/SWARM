using UnityEngine;

public class Swarms : MonoBehaviour
{
    [SerializeField] private float goalDistance;
    [SerializeField] private float colAvoidDistance;
    [SerializeField] private float boidSpeed;

    private GameObject goal;
    private GameObject[] boids;

    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.Find("Goal");
        boids = GameObject.FindGameObjectsWithTag("Boids");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(goal.transform.position, transform.position) >= goalDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, goal.transform.position, boidSpeed * Time.deltaTime);
            transform.LookAt(goal.transform.position);
        }
        foreach (GameObject go in boids)
        {
            if(go != gameObject)
            {
                if(Vector3.Distance(go.transform.position, gameObject.transform.position) <= colAvoidDistance)
                {
                    transform.Translate((transform.position - go.transform.position) * Time.deltaTime);
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 2);
    }
}
