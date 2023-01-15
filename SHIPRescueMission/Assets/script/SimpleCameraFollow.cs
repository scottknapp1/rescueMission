using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour
{
    public GameObject target;
    Vector3 offset;

    private void LateUpdate()
    {
        float desiredAngle = target.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, desiredAngle, 0);
        transform.position = target.transform.position + (rotation * offset);
        transform.LookAt(target.transform);
    }

    private void Start()
    {
        offset = transform.position - target.transform.position;
    }
}
