using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFaceDirection : MonoBehaviour
{
    //Todo Delay
    public float FuzzinessDistance;
    private float _fuzzCheck;
    public bool Flip;
    private Vector3 _prevPosition;
    [Header("Sprites To Flip")]
    public SpriteRenderer[] SpriteRenderers;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_prevPosition.Equals(this.transform.position))
            if (_fuzzCheck <= 0)
            {
                _fuzzCheck = FuzzinessDistance;
                foreach (SpriteRenderer sr in SpriteRenderers)
                    sr.flipX = (!Flip) && _prevPosition.x > this.transform.position.x ||
                        (Flip) && _prevPosition.x < this.transform.position.x;
            }
            else
                _fuzzCheck -= Mathf.Abs((_prevPosition - this.transform.position).magnitude);
        _prevPosition = this.transform.position;
    }
}
