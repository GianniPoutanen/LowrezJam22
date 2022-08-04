using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeSkin : MonoBehaviour
{
    public Sprite[] Sprites;

    void Start()
    {
        if (Sprites != null && Sprites.Length > 0)
        this.GetComponent<SpriteRenderer>().sprite = Sprites[Random.Range(0,Sprites.Length)];
    }
}
