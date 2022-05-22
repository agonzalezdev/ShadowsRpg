using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public Vector2 MovementDirection => _movementDirection;

    public bool IsInMovement => _movementDirection.magnitude > 0f;

    [SerializeField] private float speed;


    private Rigidbody2D _rigidbody2D;
    private Vector2 _input;
    private Vector2 _movementDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //X
        switch (_input.x)
        {
            case > 0.1f:
                _movementDirection.x = 1f;
                break;
            case < 0:
                _movementDirection.x = -1f;
                break;
            default:
                _movementDirection.x = 0f;
                break;
        }

        //Y
        switch (_input.y)
        {
            case > 0.1f:
                _movementDirection.y = 1f;
                break;
            case < 0:
                _movementDirection.y = -1f;
                break;
            default:
                _movementDirection.y = 0f;
                break;
        }
    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + _movementDirection * speed * Time.fixedDeltaTime);
    }
}
