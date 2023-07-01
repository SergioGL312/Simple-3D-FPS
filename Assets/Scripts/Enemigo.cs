using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{

    public NavMeshAgent enemigo;
    public Transform Jugador;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemigo != null && Jugador != null)
        {
            enemigo.SetDestination(Jugador.position);
        }
    }

    public void DestruirEnemigo()
    {
        // Agrega cualquier efecto o animación antes de destruir al enemigo
        if (gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
