using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{

    public class TileMap : MonoBehaviour
    {
        [SerializeField]
        private int row;
        [SerializeField]
        private int column;
        [SerializeField]
        private GameObject tilePrefab;

        public static TileMap instance;


        private void Awake()
        {
            instance = this;
        }

        public void GenerateMap()
        {
            if (row < 2 || column < 2)
            {
                Debug.Log("Map value is not set properly");
                return;
            }
            else
            {
                for (int x = 0; x < row; x++)
                {
                    for (int y = 0; y < column; y++)
                    {
                        GameObject go = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
                        go.transform.SetParent(this.transform);
                        go.name = $"({x}, {y})";
                    }
                }
            }
        }
    }

}

