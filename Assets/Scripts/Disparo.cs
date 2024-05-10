using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{

    [SerializeField] private GameObject balaPrefab;
    [SerializeField] private Transform puntoDisparo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetKeyDown(Clic izquierdo)
        
        if (Input.GetButtonUp("Fire1"))
        {
            Disparar();
        }

    }

    void Disparar()
    {
        Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
    }
}
