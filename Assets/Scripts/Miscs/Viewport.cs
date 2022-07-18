using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viewport : Singleton<Viewport>
{
    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    private void Start()
    {
        Camera mainCamera = Camera.main;

        Vector2 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f));
        Vector2 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f));

        minX = bottomLeft.x;
        maxX = topRight.x;
        minY = bottomLeft.y;
        maxY = topRight.y;
    }

    /// <summary>
    /// 限制玩家移动范围
    /// </summary>
    /// <param name="playerPostion">玩家移动位置</param>
    /// <param name="paddingX">横向 padding</param>
    /// <param name="paddingY">纵向 padding</param>
    /// <returns>限制后玩家位置</returns>
    public Vector3 PlayerMoveablePosition(Vector3 playerPostion, float paddingX, float paddingY)
    {
        var position = Vector3.zero;

        position.x = Mathf.Clamp(playerPostion.x, minX + paddingX, maxX - paddingX);
        position.y = Mathf.Clamp(playerPostion.y, minY + paddingY, maxY - paddingY);

        return position;
    }
}