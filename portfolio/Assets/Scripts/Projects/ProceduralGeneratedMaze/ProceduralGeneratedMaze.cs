using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLocation
{
    public int x, y;

    public MapLocation(int _x, int _y)
    {
        x = _x;
        y = _y;
    }
}

public class ProceduralGeneratedMaze : MonoBehaviour
{
    public List<MapLocation> dir = new List<MapLocation>()
    {
        new MapLocation(1, 0),
        new MapLocation(0, 1),
        new MapLocation(-1, 0),
        new MapLocation(0, -1)
    };

    [SerializeField] private int m_Width;
    [SerializeField] private int m_Height;

    [SerializeField] private float m_Scale;

    [SerializeField] protected byte[,] m_Map;

    [SerializeField] private GameObject wall;

    [SerializeField] private IsButtonPressed press;
    [SerializeField] private InteractButton interactButton;

    private bool isTriggered = false;
    private float time = 0;
    private bool isTime = false;

    private SpriteRenderer sprite;
    private Vector4 orgColor;
    void Start()
    {
        InitializeMap();
        Generate();
        DrawMap();

        sprite = GetComponent<SpriteRenderer>();
        orgColor = sprite.color;
    }

    private void Update()
    {
        if (isTriggered)
        {
            if (press.isPressed())
            {
                sprite.color = new Vector4((orgColor.x - 0.55f), sprite.color.g, sprite.color.b, sprite.color.a);
                isTime = true;
                DeleteMap();
                InitializeMap();
                Generate();
                DrawMap();
                interactButton.SetIsButtonPressed(false);
            }
        }

        if (isTime)
        {
            time += Time.deltaTime;
            if (time >= 0.3f) 
            {
                sprite.color = orgColor;
                isTime = false;
                time = 0;   
            }
        }
    }

    void InitializeMap()
    {
        m_Map = new byte[m_Width, m_Height];
        for (int y = 0; y < m_Height; y++)
        {
            for (int x = 0; x < m_Width; x++)
            {
                m_Map[x, y] = 1;
            }
        }
    }

    public virtual void Generate()
    {
        for (int z = 0; z < m_Width; z++)
            for (int x = 0; x < m_Height; x++)
            {
                if (Random.Range(0, 100) < 50)
                    m_Map[x, z] = 0;
            }
    }

    void DrawMap()
    {
        for (int y = 0; y < m_Height; y++)
        {
            for (int x = 0; x < m_Width; x++)
            {
                if (m_Map[x, y] == 1)
                {
                    Vector3 pos = new Vector3((x * m_Scale) - 5.25f, (y * m_Scale) - 10.5f, 0);
                    Instantiate(wall, pos, Quaternion.identity);
                }
            }
        }
    }

    void DeleteMap()
    {
        GameObject[] walls;

        walls = GameObject.FindGameObjectsWithTag("Maze");

        foreach (GameObject wall in walls)
        {
            if (wall != GameObject.Find("Block"))
                Destroy(wall);
            
        }    
    }

    bool Search2D(int c, int r, int[] pattern)
    {
        int count = 0;
        int pos = 0;

        for (int y = 1; y > -2; y--)
        {
            for (int x = -1; x < 2; x++)
            {
                if (pattern[pos] == m_Map[c + x, r + y] || pattern[pos] == 5)
                {
                    count++;
                }
                pos++;
            }
        }

        return (count == 9);
    }

    public int Count4WayNeighbours(int x, int y)
    {
        int count = 0;

        if (x <= 0 || x >= m_Width - 1 || y <= 0 || y >= m_Height - 1) return 5;

        if (m_Map[x - 1, y] == 0) count++;
        if (m_Map[x + 1, y] == 0) count++;
        if (m_Map[x, y - 1] == 0) count++;
        if (m_Map[x, y + 1] == 0) count++;

        return count;
    }

    public int CountDiagonalNeighbours(int x, in int y)
    {
        int count = 0;

        if (x <= 0 || x >= m_Width - 1 || y <= 0 || y >= m_Height - 1) return 5;

        if (m_Map[x - 1, y - 1] == 0) count++;
        if (m_Map[x + 1, y + 1] == 0) count++;
        if (m_Map[x - 1, y - 1] == 0) count++;
        if (m_Map[x + 1, y + 1] == 0) count++;

        return count;
    }

    public int TotalNeighboors(int x, in int y)
    {
        return Count4WayNeighbours(x, y) + CountDiagonalNeighbours(x, y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            interactButton.SetIsButtonPressed(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTriggered = false;
            interactButton.SetIsButtonPressed(false);
        }
    }
}
