using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generar_Enemigos : MonoBehaviour
{
    public GameObject enemigo;

    public float tiempoMinimo = 1f; // Tiempo m�nimo para generar un enemigo
    public float tiempoMaximo = 3f; // Tiempo m�ximo para generar un enemigo


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarEnemigos());
    }

    // Update is called once per frame
    void Update()
    {
    }

    // Funci�n para generar enemigos en intervalos aleatorios
    IEnumerator GenerarEnemigos()
    {
        while (true)
        {
            generar(); // Generar un enemigo

            // Esperar un tiempo aleatorio antes de generar el siguiente enemigo
            float tiempoEspera = Random.Range(tiempoMinimo, tiempoMaximo);
            yield return new WaitForSeconds(tiempoEspera);
        }
    }

    // Funci�n para generar un enemigo en una posici�n aleatoria en el plano
    void generar()
    {
        if (enemigo == null)
        {
            Debug.LogWarning("El objeto enemigo es nulo. No se puede instanciar.");
            return;
        }

        // Obtener los l�mites del plano de juego
        float minX = transform.position.x - transform.localScale.x / 2f;
        float maxX = transform.position.x + transform.localScale.x / 2f;
        float minZ = transform.position.z - transform.localScale.z / 2f;
        float maxZ = transform.position.z + transform.localScale.z / 2f;

        // Generar una posici�n aleatoria dentro de los l�mites del plano
        float posX = Random.Range(minX, maxX);
        float posZ = Random.Range(minZ, maxZ);
        Vector3 posicionAleatoria = new Vector3(posX, 0f, posZ);

        // Instanciar un enemigo en la posici�n aleatoria generada
        Instantiate(enemigo, posicionAleatoria, Quaternion.identity);
    }
}
