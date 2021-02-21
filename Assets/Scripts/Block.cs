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
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();

        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            DestroyBlock();
        }
    }

    private void DestroyBlock()
    {
        AddToScore();
        PlaySFXEffect();
        Destroy(gameObject);
        TriggerSparklesVFX();
        level.BlockDestroyed();
    }

    private void AddToScore()
    {
        FindObjectOfType<GameSession>().AddToScore();
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
