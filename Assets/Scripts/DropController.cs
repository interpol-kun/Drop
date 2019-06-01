using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class DropController : MonoBehaviour
{
    public float speed = 15.0f;

    private Rigidbody rb = null;
    private float x;
    private Vector3 direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //GetKey используется только на устройствах с клавиатурой. Для унифицированного ввода используй Axis в Unity Input.
        //Изменение position у transform и rigidbody равна телепортации объекта. Так лучше не делать за редкими исключениями.

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.position += Vector3.left * speed * Time.deltaTime;

        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    transform.position += Vector3.right * speed * Time.deltaTime;
        //}
        x = Input.GetAxis("Horizontal");
        direction = new Vector3(x, 0, 0);
        Move(direction);
    }

    //У компонента Rigidbody выбрать FreezeRotation во всех направлениях. Freeze Position по Y, Z.
    private void Move(Vector3 direction)
    {
        //rb.velocity = (new Vector3(direction.x * speed, 0, 0));
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
    }
}
