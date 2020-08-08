using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] int minX = 1, maxX = 15;

    // Update is called once per frame
    void Update()
    {
        float getMousePositionX = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePosition = new Vector2(Mathf.Clamp(getMousePositionX, minX, maxX), transform.position.y);
        transform.position = paddlePosition;
    }
}
