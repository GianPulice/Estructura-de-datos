using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Movement : MonoBehaviour
{
    public float speed = 5f;
    public Vector2Int currentGridPosition;

    public void MoveTo(Vector2Int targetPosition)
    {
        if (!GameManager.Instance.gridManager.enemyPositions.Contains(targetPosition))
        {
            List<Vector2Int> path = GameManager.Instance.FindPath(currentGridPosition, targetPosition);
            if (path.Count > 0)
            {
                StartCoroutine(MoveAlongPath(path));
                currentGridPosition = targetPosition;
            }
        }
  
    }

    private IEnumerator MoveAlongPath(List<Vector2Int> path)
    {
        foreach (var position in path)
        {
            Vector3 targetPosition = new Vector3(position.x, position.y, -10);
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                yield return null;
            }
        }
    }
}

