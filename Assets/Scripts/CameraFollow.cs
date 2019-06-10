using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //TODO: Гасан, переверни камеру на 180 градусов
    public Transform target;

    public float smoothSpeed = 0.125f;

    //(0, 14.5, 0)
    public Vector3 offset;

    private Vector3 desiredPosition, smoothedPosition;

    private void Start()
    {
        transform.Rotate(new Vector3(90, 0, 0));
    }
    void LateUpdate()
    {
        desiredPosition  = transform.position = new Vector3(0, target.position.y, 0) + offset;
        smoothedPosition  = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }

}
