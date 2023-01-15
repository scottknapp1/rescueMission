using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crateCollisionAlinger : MonoBehaviour
{
    [SerializeField] private GameObject crate;
    [SerializeField] private GameObject crateSnappingPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box"))
        {
            crate.transform.position = crateSnappingPoint.transform.position;
        }
    }
}
