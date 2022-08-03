using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class RandomWonder : MonoBehaviour
{
    public float Direction;
    private protected Entity _entity;

    [Header("Avoidance Stats")]
    public float AvoidanceWeighting = 5;

    private void Start()
    {
        _entity = GetComponent<Entity>();
    }

    private void Update()
    {
        var newDir = Vector3.zero;
        //newPos += AngleToVector(Direction) ;
        newDir += Avoidance();

        this.transform.position += newDir;
    }

    public Vector3 Avoidance()
    {
        var entities = GameObject.FindObjectsOfType<Entity>();
        int count = 0;
        Vector3 AvoidanceVector = Vector3.zero;
        foreach (Entity entity in entities)
        {
            if (entity.CompareTag("Player") && Vector3.Distance(entity.transform.position, this.transform.position) < 10f)
            {
                AvoidanceVector -= (entity.transform.position - this.transform.position).normalized /
                     Mathf.Pow(Vector3.Distance(entity.transform.position, this.transform.position), 1.5f);
                count++;
            }
            else if (entity != _entity && Vector3.Distance(entity.transform.position, this.transform.position) < 4f)
            {
                AvoidanceVector -= (entity.transform.position - this.transform.position).normalized /
                     Mathf.Pow(Vector3.Distance(entity.transform.position, this.transform.position), 3f);
                count++;
            }
        }
        return AvoidanceVector;
    }

}
