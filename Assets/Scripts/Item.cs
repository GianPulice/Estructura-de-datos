using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int itemId;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            Destroy(gameObject); 
        }
    }

    public void SetColorByItemId(int itemId)
    {
        Renderer rend = GetComponent<Renderer>();
        switch (itemId)
        {
            case 0:
                rend.material.color = Color.white;
                break;
            case 1:
                rend.material.color = Color.red;
                break;
            case 2:
                rend.material.color = Color.blue;
                break;
            case 3:
                rend.material.color = Color.green;
                break;
            case 4:
                rend.material.color = Color.yellow;
                break;
            case 5:
                rend.material.color = Color.magenta;
                break;
            case 6:
                rend.material.color = Color.cyan;
                break;
            default:
                rend.material.color = Color.gray;
                break;
        }
    }
}