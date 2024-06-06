using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject cellPrefab;
    public GameObject enemyPrefab;
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float cellSize = 1.0f;
    public float enemyZOffset = 10f;
    public int enemys;
    public List<Vector2Int> enemyPositions = new List<Vector2Int>();

    public Graph graph; 

    void Start()
    {
        graph = new Graph();
        GenerateGrid();
        GenerateEnemies(enemys);
    }

    void GenerateGrid()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector2 position = new Vector2(x * cellSize, y * cellSize);
                GameObject newCell = Instantiate(cellPrefab, position, Quaternion.identity);
                newCell.transform.SetParent(transform);
                GridCell cell = newCell.GetComponent<GridCell>();
                cell.gridPosition = new Vector2Int(x, y);

                graph.AddNode(cell.gridPosition);

                // Conectar con vecinos
                Vector2Int[] directions = { Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right };
                foreach (var dir in directions)
                {
                    Vector2Int neighborPos = cell.gridPosition + dir;
                    if (neighborPos.x >= 0 && neighborPos.x < gridWidth && neighborPos.y >= 0 && neighborPos.y < gridHeight)
                    {
                        graph.AddEdge(cell.gridPosition, neighborPos);
                    }
                }
            }
        }
    }

    public Node GetNode(Vector2Int position)
    {
        return graph.GetNode(position);
    }

    void GenerateEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            int randomX = Random.Range(0, gridWidth);
            int randomY = Random.Range(0, gridHeight);
            Vector2Int randomPosition = new Vector2Int(randomX, randomY);

            if (randomPosition != GameManager.Instance.playerController.currentGridPosition)
            {
                Vector3 enemyPosition = new Vector3(randomX * cellSize, randomY * cellSize, -enemyZOffset);
                GameObject enemy = Instantiate(enemyPrefab, enemyPosition, Quaternion.identity);
                enemyPositions.Add(randomPosition); 
            }
            else
            {
                i--;
            }
        }
    }
}



