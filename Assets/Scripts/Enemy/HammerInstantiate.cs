using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerInstantiate : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    float _currentDistance;
    void Update()
    {
        HammerFuncion();
    }

    void HammerFuncion()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
        _currentDistance += speed * Time.deltaTime;

        if (_currentDistance >= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
