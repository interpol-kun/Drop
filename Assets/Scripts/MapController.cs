using UnityEngine;
using System.Collections.Generic;

public class MapController : MonoBehaviour
{
    //Гасан, не трогать эти скрипты, если не знаешь, как они работают, а ты не знаешь.
    //TODO: Кеширование тайлов и геймобджектов
    public GameObject[] Tiles;
    public int length;

    private DropController drop;
    private float speed = 1;

    private MeshRenderer root;
    private Vector3 rootPosition;

    private float size;

    [SerializeField]
    private List<Tile> nearTiles = new List<Tile>();
    void Start()
    {
        Application.targetFrameRate = 50;
        DropController.OnDeath += ReloadMap;
        StartMap();
    }

    void StartMap()
    {
        CreateRootTile();

        if (drop == null)
        {
            drop = GameObject.FindGameObjectWithTag("Player").GetComponent<DropController>();
        }
        speed = drop.speed;
        drop.transform.position = new Vector3(0, 0, 0);

        //Debug.Break();
    }

    void ReloadMap()
    {
        drop.transform.position = Vector3.zero;

        for (int i = nearTiles.Count - 1; i >= 0; i--)
        {
            GameObject.Destroy(nearTiles[i].gameObject);
            nearTiles.RemoveAt(i);
        }

        StartMap();
    }
    // Update is called once per frame
    void Update()
    {
        if (nearTiles.Count > 1)
        {
            speed = drop.speed;

            foreach (var t in nearTiles)
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
            if (nearTiles.Count < 3)
            {
                CreateNextTile();
            }
        }
    }

    private void CreateNextTile()
    {
        if (nearTiles.Count >= 3)
        {
            DeleteFirstTile();
        }
        //Упростил, но можно вернуть считывание позиций для новых объектов по всем осям, а не только по Z, если в будущем будет нужна такой функционал
        nearTiles.Add((Instantiate(Tiles[Random.Range(0, 2)], new Vector3(rootPosition.x,
            rootPosition.y, nearTiles[nearTiles.Count - 1].transform.position.z - size),
            nearTiles[nearTiles.Count - 1].transform.rotation, transform)).GetComponent<Tile>());
    }

    private void CreateRootTile()
    {
        nearTiles.Add((Instantiate(Tiles[Random.Range(0, 2)], Vector3.zero, transform.rotation, transform)).GetComponent<Tile>());

        root = nearTiles[0].gameObject.GetComponent<MeshRenderer>();
        rootPosition = root.transform.position;
        size = root.bounds.size.z;

        CreateNextTile();
    }

    private void DeleteFirstTile()
    {
        Destroy(nearTiles[0].gameObject);
        nearTiles.RemoveAt(0);
    }
}
