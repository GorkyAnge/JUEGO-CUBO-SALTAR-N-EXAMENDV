using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float velocidad;

    void Update()
    {
        // Mover la bala hacia adelante
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    // M�todo para detectar colisiones
    void OnTriggerEnter(Collider other)
    {
        // Verificar si la bala ha colisionado con otro objeto
        // En este caso, simplemente destruimos la bala y el objeto con el que colision�
        Destroy(gameObject); // Destruye la bala
        Destroy(other.gameObject); // Destruye el objeto con el que colision� la bala
    }

    // M�todo para destruir la bala despu�s de 2 segundos
    void Start()
    {
        Invoke("DestruirBala", 2f);
    }

    void DestruirBala()
    {
        Destroy(gameObject);
    }
}
