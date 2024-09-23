using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private  Transform _camera;
    [SerializeField] private float _offsetPriority;
    
    private SpriteRenderer _spriteRenderer;
    private Vector2 _offset;
    private float _distanceScaling = 20f;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        _offset = new Vector2(_camera.position.x / _distanceScaling / _offsetPriority, 0f);
        _spriteRenderer.material.mainTextureOffset = _offset;
    }
}
