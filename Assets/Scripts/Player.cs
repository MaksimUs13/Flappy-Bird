using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;

    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;
    private int spriteIndex;
    private Vector2 direction;
    private float gravity = -9.8f;
    private float strength = 5f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        inputManager.OnInteractJump += (sender, args) => { Jump(); };
    }

    private void OnDestroy()
    {
        inputManager.OnInteractJump -= (sender, args) => { Jump(); };
    }

    private void FixedUpdate()
    {
        Gravity();
    }

    private void Jump()
    {
        direction = Vector2.up * strength;
    }

    private void Gravity()
    {
        direction.y += gravity * Time.deltaTime;
        transform.position += new Vector3(0f, direction.y, 0f) * Time.deltaTime;
    }
}
