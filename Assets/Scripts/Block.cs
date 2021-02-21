using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;

    // cahed references
    Level level;
    GameSession gameState;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gameState = FindObjectOfType<GameSession>();

        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.5f);
        Destroy(gameObject);
        level.BlockDestroyed();
        gameState.AddToScore();
    }
}
