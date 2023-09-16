using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSetter : MonoBehaviour
{
    [SerializeField] private Sprite[] _texture;

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = _texture[Random.Range(0, _texture.Length)];

    }
}
