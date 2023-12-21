using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private string currentColor;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    [SerializeField] private Color _colorCyan;
    [SerializeField] private Color _colorYellow;
    [SerializeField] private Color _colorMagenta;
    [SerializeField] private Color _colorPink;
    private bool _isJumping;
    void Start()
    {
        SetRandomColor();
        _rb.gravityScale = 0f;
    }

    void Update()
    {
        if (!_isJumping)
        {
            // Fare tıklaması
            if (Input.GetMouseButtonDown(0))
            {
                _rb.velocity = Vector2.up * _jumpForce;
                _isJumping = true;
                _rb.gravityScale = 1f;
            }
        }

        // Fare tıklaması bırakıldığında veya zıplama hâlâ devam ediyorsa
        if (Input.GetMouseButtonUp(0) || _isJumping)
        {
            _isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ColorChanger"))
        {
            SetRandomColor();
            Destroy(other.gameObject);
            return; 
        }
        if (!other.CompareTag(currentColor) && !other.CompareTag("Block"))
        {
            Debug.Log("Game over");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);
        switch (index)
        {
            case 0:
                currentColor = "Cyan";
                _spriteRenderer.color = _colorCyan;
                break;
            case 1:
                currentColor = "Yellow";
                _spriteRenderer.color = _colorYellow;
                break;
            case 2:
                currentColor = "Magenta";
                _spriteRenderer.color = _colorMagenta;
                break;
            case 3:
                currentColor = "Pink";
                _spriteRenderer.color = _colorPink;
                break;
        }
    }
}
