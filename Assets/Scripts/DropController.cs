using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DropController : MonoBehaviour
{
    public float speed = 15.0f;

    private Rigidbody rb = null;
    private float x;
    private Vector3 direction = Vector3.zero;
    private Camera mainCamera;

    private Vector3 touch;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        touch = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        x = touch.x;
        Debug.Log(touch);
        //x = Input.GetAxis("Horizontal");
        direction = new Vector3(x, 0, 0);
        Move(direction);
    }

    //У компонента Rigidbody выбрать FreezeRotation во всех направлениях. Freeze Position по Y, Z.
    private void Move(Vector3 direction)
    {
        //rb.velocity = (new Vector3(direction.x * speed, 0, 0));
        //rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        //rb.MovePosition(Vector3.Lerp(transform.position, direction, speed*Time.deltaTime));
        rb.MovePosition(Vector3.MoveTowards(transform.position, direction, speed*Time.deltaTime));
    }

    void OnGUI()
    {
        // Compute a fontSize based on the size of the screen width.
        GUI.skin.label.fontSize = (int)(Screen.width / 25.0f);

        GUI.Label(new Rect(20, 20, 300, 300 * 0.25f),
            "x = " + touch.x.ToString("f2") +
            ", y = " + touch.y.ToString("f2"));
    }

}
