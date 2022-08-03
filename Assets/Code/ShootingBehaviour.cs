using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehaviour : MonoBehaviour
{
    public GameObject Bullet;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pew");
            GameObject.Instantiate(Bullet).transform.position = this.transform.position;
        }
    }
}
