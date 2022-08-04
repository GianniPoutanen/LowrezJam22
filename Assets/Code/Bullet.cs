using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public float Speed;
    private Vector3 _direction = Vector3.zero;

    public SpriteRenderer[] SpriteRenderers;

    private void Start()
    {
        this.transform.position = LittleMaths.ZeroZVector(this.transform.position);
        _direction = (LittleMaths.ZeroZVector(Camera.main.ScreenToWorldPoint(Input.mousePosition)) - this.transform.position).normalized;

        foreach (var renderer in SpriteRenderers)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            renderer.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.RoundToInt(rotation_z / 45) * 45);
        }
        this.transform.position += _direction;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += _direction * Time.deltaTime * Speed;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        var entity = collision.gameObject.GetComponent<Entity>();
        if (entity != null)
        {
            collision.gameObject.GetComponent<Entity>().Hit(Damage);
            GameObject.Destroy(this.gameObject);
        }
    }
}
