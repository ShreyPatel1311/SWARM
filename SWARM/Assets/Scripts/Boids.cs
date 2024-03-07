using TMPro;
using UnityEngine;

public class Boids : MonoBehaviour
{
    [SerializeField] private float colAvoidDistance;
    [SerializeField] private float perceptionRadius;
    [SerializeField] private float boidLength;
    [SerializeField] private float boidSpeed;
    [SerializeField] private LayerMask layer;

    private Vector3 seperationForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * boidSpeed * Time.deltaTime;
        if (DetectNearbyBoidsOrObstacles())
        {
            AvoidNearbyBoidsAndObstacles();
        }
    }

    private bool DetectNearbyBoidsOrObstacles()
    {
        RaycastHit hit;
        if(Physics.SphereCast(transform.position, boidLength, transform.forward, out hit, perceptionRadius))
        {
            return true;
        }
        return false;
    }

    private void AvoidNearbyBoidsAndObstacles()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, boidLength, transform.forward, perceptionRadius, layer);
        float maxDis = 0;
        Vector3 targetHit = Vector3.zero;

        foreach (RaycastHit hit in hits)
        {
            if (Vector3.Distance(hit.point, transform.position) >= maxDis && hit.point != Vector3.zero)
            {
                maxDis = Vector3.Distance(hit.point, transform.position);
                targetHit = hit.normal;
            }
        }
        Vector3 offset = transform.position - targetHit;
        seperationForce += offset.normalized * boidSpeed;
        transform.position += seperationForce * Time.deltaTime;
        transform.Rotate(transform.up, 180);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, perceptionRadius);
    }
}
