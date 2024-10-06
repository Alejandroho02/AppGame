using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
      public float speed = 5f;            // Velocidad de movimiento
    public float runSpeed = 10f;        // Velocidad al correr
    public float mouseSensitivity = 2f; // Sensibilidad del ratón

    private float rotationX = 0f;       // Rotación actual en el eje X (vertical)
    public Transform playerCamera;      // La cámara del jugador

    void Start()
    {
        LockCursor(); // Bloquear el cursor al inicio del juego
    }

    void Update()
    {
        // Movimiento del jugador
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * moveHorizontal + transform.forward * moveVertical;

        // Cambiar entre caminar y correr
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : speed;

        // Aplicar movimiento
        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);

        // Rotación de la cámara y del jugador
        HandleMouseLook();

        // Bloquear el cursor si está desbloqueado accidentalmente
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            LockCursor();
        }
    }

    void HandleMouseLook()
    {
        // Movimiento horizontal del ratón (girar el jugador)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;

        // Movimiento vertical del ratón (mirar arriba/abajo)
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Aplicar la rotación horizontal al jugador
        transform.Rotate(Vector3.up * mouseX);

        // Limitar la rotación vertical de la cámara
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Aplicar la rotación a la cámara
        playerCamera.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }

    // Método para bloquear y ocultar el cursor
    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Bloquear el cursor en el centro de la pantalla
        Cursor.visible = false; // Ocultar el cursor
    }
}
