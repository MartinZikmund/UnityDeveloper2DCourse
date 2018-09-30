using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip breakSound;
    [SerializeField] private GameObject sparklesEffect;
    [SerializeField] private int maxHits = 1;
    [SerializeField] private Sprite[] hitSprites;

    private Level level;
    private GameSession _gameSession;

    [SerializeField] private int timesHit;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        if (tag == "Breakable")
        {
            level.CountBreakableBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            HandleBreakableHit();
        }
    }

    private void HandleBreakableHit()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[timesHit - 1];
        }
        else
        {
            Debug.LogError("Missing sprite - " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        GameSession.Instance.AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        TriggerSparklesVfx();
    }

    private void TriggerSparklesVfx()
    {
        var sparkles = Instantiate(sparklesEffect, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
