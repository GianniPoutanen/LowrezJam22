using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    [Header("Punch Stats")]
    public float PunchDistance;
    public float PunchDamage;
    public float KnockBack;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PunchClosestEntity();
        }
    }

    private void PunchClosestEntity()
    {
        var smallestDist = float.MaxValue;
        Entity enemy = null;
        foreach (var entity in GameObject.FindObjectsOfType<Entity>())
        {
            if (entity.CompareTag("Enemy") && Vector3.Distance(this.transform.position, entity.transform.position) < smallestDist)
            {
                smallestDist = Vector3.Distance(this.transform.position, entity.transform.position);
                enemy = entity;
            }
        }
        if (enemy != null && smallestDist < PunchDistance)
        {
            // Point Towards
            enemy.Hit(PunchDamage);
            if (enemy.GetComponent<Rigidbody2D>() != null )
            {
                enemy.GetComponent<Rigidbody2D>().velocity =
                    -(this.transform.position - enemy.transform.position).normalized * KnockBack;
            }
        }
    }
}
