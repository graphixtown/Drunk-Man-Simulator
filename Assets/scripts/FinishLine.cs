using System.Runtime.CompilerServices;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.CallLevel2();
        }
    }
}
