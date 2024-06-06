using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    public GridManager gridManager;
    public C_Movement playerController;
    public Vector2Int initialPlayerPosition = new Vector2Int(0, 0);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        
        playerController.transform.position = new Vector3(initialPlayerPosition.x * gridManager.cellSize, initialPlayerPosition.y * gridManager.cellSize,-10);
        playerController.currentGridPosition = initialPlayerPosition;
    }

    public void MovePlayerTo(Vector2Int position)
    {
        playerController.MoveTo(position);
    }

    public List<Vector2Int> FindPath(Vector2Int start, Vector2Int target)
    {
        return Dijkstra.FindPath(gridManager.graph, start, target, gridManager.enemyPositions);
    }
}
