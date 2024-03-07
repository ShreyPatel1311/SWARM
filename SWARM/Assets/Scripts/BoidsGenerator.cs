using UnityEngine;

public class BoidsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject fishie;
    [SerializeField] private float numInstances;
    [SerializeField] private float positionLimit;
    [SerializeField] private float rotationLimit;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numInstances; i++)
        {
            Instantiate(fishie, new Vector3(transform.position.x + Random.Range(0, positionLimit), transform.position.y + Random.Range(0, positionLimit), transform.position.z + Random.Range(0, positionLimit)), Quaternion.Euler(new Vector3(transform.eulerAngles.x + Random.Range(0, rotationLimit), transform.eulerAngles.y + Random.Range(0, rotationLimit), transform.eulerAngles.z + Random.Range(0, rotationLimit))));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
