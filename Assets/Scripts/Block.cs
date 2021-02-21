using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

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
        PlaySFXEffect();
        Destroy(gameObject);
        TriggerSparklesVFX();
        level.BlockDestroyed();
        gameState.AddToScore();
    }

    private void PlaySFXEffect()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position, 0.5f);
    }

    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, 1f);
    }
}
