using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField]private Vector2 scrollVelocity; // 滚动速度
    
    private Material m_Material;

    private void Awake()
    {
        m_Material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        m_Material.mainTextureOffset += scrollVelocity * Time.deltaTime;
    }
}
