using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, hInput * rotationSpeed * Time.deltaTime);
    }
}
