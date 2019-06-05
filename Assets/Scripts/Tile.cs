using UnityEngine;

public class Tile : MonoBehaviour
{

    public bool dirty = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Move(float speed)
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z <= -10f) {
            dirty = true;
        }
    }
}
