using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockShadow : MonoBehaviour
{
    public Construction Construction { set; private get; }
    public Block Block;

    public Color ColourDefault;
    public Color ColourMouseOver;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.color = ColourDefault;
    }

    void OnMouseEnter()
    {
        _spriteRenderer.color = ColourMouseOver;
    }

    void OnMouseExit()
    {
        _spriteRenderer.color = ColourDefault;
    }
    
    void OnMouseDown()
    {
        Construction.ConstructBlockAtPosition(Block, transform.position);
    }

}
