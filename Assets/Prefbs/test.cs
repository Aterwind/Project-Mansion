using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [SerializeField]private List<GameObject> targets = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
    }
}
