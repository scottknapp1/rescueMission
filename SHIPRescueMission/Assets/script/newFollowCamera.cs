using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newFollowCamera : MonoBehaviour
{
    private Transform targetTransform = null;

    [Range(1, 10)]

    [SerializeField] private float smoothSpeed = 5;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 minValue, maxValue;

    private void Start()
    {
        targetTransform = GameObject.FindGameObjectWithTag("ship").transform;
    }

    private void LateUpdate()
    {
        Vector3 desiredPos = targetTransform.TransformPoint(offset);

        Vector3 clampPos = new Vector3(
            Mathf.Clamp(desiredPos.x, minValue.x, maxValue.x),
            Mathf.Clamp(desiredPos.y, minValue.y, maxValue.y),
            Mathf.Clamp(desiredPos.z, minValue.z, maxValue.z));

        Vector3 smoothPos = Vector3.Lerp(transform.position, clampPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;

        transform.LookAt(targetTransform);
    }
}
