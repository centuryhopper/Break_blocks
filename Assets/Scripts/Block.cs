using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // configuration parameters
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkles;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] sprites;

    // cached reference
    Level level;

    // state variables
    [SerializeField] int timesHit;    


// method that generates sparkles
    private void TriggerSparkles()
    {
        GameObject sparkles = Instantiate(blockSparkles, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }

    private void Start()
    {
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (!CompareTag("UNBREAKABLE"))
            level.CountBlocks();
    }

// this method is called every time a gameobject with this script attached collides 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if block is breakable and timesHit equals maxHits
        timesHit++;
        if (!CompareTag("UNBREAKABLE") && timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprites();
        }
    }

    private void ShowNextHitSprites()
    {
        if (timesHit - 1 < sprites.Length)
            GetComponent<SpriteRenderer>().sprite = sprites[timesHit - 1];
        else
        {
            Debug.LogError("all sprites for"+ gameObject.name +" have been rendered.");
            return;
        }
    }

    private void DestroyBlock()
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<GameStatus>().IncreaseScore();
        TriggerSparkles();
        Destroy(gameObject);
        level.BreakBlock();
    }
}


