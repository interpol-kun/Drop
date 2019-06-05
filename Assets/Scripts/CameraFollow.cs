using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //TODO: Гасан, переверни камеру на 180 градусов
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Vector3 desiredPosition, smoothedPosition;

    void LateUpdate()
    {
        desiredPosition  = transform.position = target.position + offset;
        smoothedPosition  = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.LookAt(target);
    }

}
