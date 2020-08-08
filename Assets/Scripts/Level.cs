using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] int BreakableBlocks;

    SceneLoader sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlocks()
    {
        ++BreakableBlocks;
    }

    public void BreakBlock()
    {
        --BreakableBlocks;
        if (BreakableBlocks <= 0)
        {
            Debug.Log("You Win!");
            sceneLoader.LoadNextScene();
        }
    }

}
