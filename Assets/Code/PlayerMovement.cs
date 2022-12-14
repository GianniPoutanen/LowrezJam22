using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class PlayerMovement : MonoBehaviour
{
    public Animator animator; 
    private Entity _entity;
    private void Awake()
    {
        _entity = GetComponent<Entity>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(horizontal + vertical ));

        this.transform.position += new Vector3(horizontal * Time.deltaTime * _entity.Speed,
            vertical * Time.deltaTime * _entity.Speed, 0);
    }
}
