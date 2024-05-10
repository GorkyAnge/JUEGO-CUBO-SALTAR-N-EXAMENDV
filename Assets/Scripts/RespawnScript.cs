using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public Transform respawnPoint;
    public float fallThreshold = -10f;

    private void Update()
    {
        // Detectar si el personaje ha ca�do por debajo del umbral de ca�da
        if (transform.position.y < fallThreshold)
        {
            // Resetear la posici�n del personaje al punto de respawn
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // Restablecer la posici�n del personaje al punto de respawn
        transform.position = respawnPoint.position;

        // Tambi�n puedes restablecer otros aspectos del personaje, como la rotaci�n o la velocidad
    }
}
