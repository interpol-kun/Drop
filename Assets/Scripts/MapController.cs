using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    //Гасан, не трогать эти скрипты, если не знаешь, как они работают, а ты не знаешь.
    //TODO: Кеширование тайлов и геймобджектов
    public GameObject[] Tiles;
    public int length;

    public float speed = 1;

    private MeshRenderer root;

    private float size;

    [SerializeField]
    private List<Tile> nearTiles = new List<Tile>();
    void Start()
    {
        Application.targetFrameRate = 50;

        nearTiles.Add(transform.GetChild(0).gameObject.GetComponent<Tile>());
        root = nearTiles[0].gameObject.GetComponent<MeshRenderer>();
        size = root.bounds.size.z;
        CreateNextTile();
    }

    // Update is called once per frame
    void Update()
    {
        foreach(var t in nearTiles)
        {
            if (t.dirty)
            {
                DeleteFirstTile();
                break;
            }
            else
            {
                t.Move(speed);
            }
        }
        if(nearTiles.Count < 3)
        {
            CreateNextTile();
        }
    }

    private void CreateNextTile()
    {
        if(nearTiles.Count >= 3)
        {
            DeleteFirstTile();
        }
        nearTiles.Add((Instantiate(Tiles[Random.Range(0, 2)], new Vector3(nearTiles[0].transform.position.x,
            nearTiles[nearTiles.Count-1].transform.position.y, nearTiles[nearTiles.Count-1].transform.position.z - size),
            nearTiles[nearTiles.Count-1].transform.rotation, transform)).GetComponent<Tile>());
    }

    private void DeleteFirstTile()
    {
        Destroy(nearTiles[0].gameObject);
        nearTiles.RemoveAt(0);
    }
}
