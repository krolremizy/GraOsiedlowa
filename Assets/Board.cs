using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Board : MonoBehaviour
{

    public int Width;
    public int Height;
    public GameObject Tile;
    public float Size;

    // Start is called before the first frame update
    void Start()
    {
        var center = new Vector3(Width - 1, 0, Height - 1) * Size * 0.5f;
        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Instantiate(Tile, new Vector3(i * Size, 0, j * Size) - center, Quaternion.identity).transform.parent = gameObject.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
