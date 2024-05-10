using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del cubo
    public float jumpForce = 10f; // Fuerza de salto del cubo
    public float sprintMultiplier = 2f; // Multiplicador de velocidad al sprint
    public float sprintJumpForceMultiplier = 1.5f; // Multiplicador de fuerza de salto al sprint
    public float wallCollisionDistance = 0.5f; // Distancia de detección de colisión con paredes
    private Rigidbody rb;
    private bool isGrounded;
    private bool isSprinting;
    private bool hasDoubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Obtener la entrada del jugador en el eje horizontal (izquierda/derecha)
        float moveInput = Input.GetAxis("Horizontal");

        // Obtener entrada para el sprint
        isSprinting = Input.GetKey(KeyCode.LeftShift);

        // Aplica multiplicador de velocidad al sprint
        float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;

        // Calcula la velocidad de movimiento
        Vector3 moveVelocity = new Vector3(moveInput * currentSpeed, rb.velocity.y, 0);

        // Comprobar colisión con paredes
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.right * Mathf.Sign(moveInput), out hit, wallCollisionDistance))
        {
            moveVelocity.x = 0f; // Detener movimiento horizontal si hay una pared cerca
        }

        // Aplica la velocidad de movimiento al Rigidbody del cubo
        rb.velocity = moveVelocity;

        // Rota el cubo para que mire hacia la dirección de movimiento
        if (moveInput > 0) // Si se mueve a la derecha
            transform.rotation = Quaternion.Euler(0, 90, 0); // Rota 90 grados hacia la derecha
        else if (moveInput < 0) // Si se mueve a la izquierda
            transform.rotation = Quaternion.Euler(0, -90, 0); // Rota 90 grados hacia la izquierda

        // Salto
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump(jumpForce);
            }
            else if (!isGrounded && hasDoubleJump)
            {
                Jump(jumpForce * sprintJumpForceMultiplier);
                hasDoubleJump = false;
            }
        }

        // Sprint
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Verifica si el cubo está en el suelo
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            hasDoubleJump = true;
        }
    }

    void Jump(float jumpForce)
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // Elimina cualquier velocidad vertical previa
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }
}

    
