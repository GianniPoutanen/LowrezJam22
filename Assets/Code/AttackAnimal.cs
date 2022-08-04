using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class AttackAnimal : MonoBehaviour
{
    [Header("Enemy Attack Stats")]
    public float Damage = 1;
    public float AttackDelay = 1;
    public float ChaseDistance = 1;

    private float _attackTimer = 0;
    private Entity _closestEntity;
    private Entity _entity;
    private Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        _entity = this.GetComponent<Entity>();
        _rb2d = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_closestEntity == null)
            GetClosestEntity();

        if (_attackTimer <= 0 && _closestEntity != null &&
            Vector3.Distance(this.transform.position, _closestEntity.transform.position) > ChaseDistance)
        {

            _rb2d.AddForce(-(this.transform.position - _closestEntity.transform.position).normalized 
                        * _entity.Speed);
            //this.transform.position = Vector3.MoveTowards(this.transform.position,
            //        _closestEntity.transform.position, _entity.Speed * Time.deltaTime);
        }

        if (_attackTimer > 0)
            _attackTimer -= Time.deltaTime;
    }

    private void GetClosestEntity()
    {
        var smallestDist = float.MaxValue;
        foreach (var entity in GameObject.FindObjectsOfType<Entity>())
        {
            if (entity.CompareTag("Animal") && Vector3.Distance(this.transform.position, entity.transform.position) < smallestDist)
            {
                _closestEntity = entity;
                smallestDist = Vector3.Distance(this.transform.position, entity.transform.position);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        var entity = collision.gameObject.GetComponent<Entity>();
        if (_attackTimer <= 0 && entity != null && entity == _closestEntity)
        {
            _attackTimer = AttackDelay;
            collision.gameObject.GetComponent<Entity>().Hit(Damage);
        }
    }
}
