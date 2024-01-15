using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform carTransform;
    [Range(1, 10)]
    public float followSpeed = 2;
    [Range(1, 10)]
    public float lookSpeed = 5;
    public float verticalOffset = 2f;
    public float fieldOfView = 60f; // Adjust this value to set the field of view
    Vector3 initialCameraPosition;
    Vector3 initialCarPosition;
    Vector3 absoluteInitCameraPosition;

    void Start()
    {
        initialCameraPosition = gameObject.transform.position;
        initialCarPosition = carTransform.position;
        absoluteInitCameraPosition = initialCameraPosition - initialCarPosition;

        // Set the initial field of view
        Camera.main.fieldOfView = fieldOfView;
    }

    void FixedUpdate()
    {
        // Look at car
        Vector3 lookDirection = (new Vector3(carTransform.position.x, carTransform.position.y, carTransform.position.z)) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, lookSpeed * Time.deltaTime);

        // Move to car with a vertical offset
        Vector3 targetPos = carTransform.position - carTransform.forward * absoluteInitCameraPosition.magnitude + Vector3.up * verticalOffset;
        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);

        // Move left or right
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
        {
            Vector3 rightDirection = carTransform.right * horizontalInput;
            Vector3 newPosition = transform.position + rightDirection * followSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);
        }
    }
}
