using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    [SerializeField]
    GameObject enemigo;
    int contadorJugadores = 0;
    int posicionInicialMarciano = -4;
    // Start is called before the first frame update
    void Start()
    {
        NetworkManager.Singleton.OnClientConnectedCallback += OnConectarseJugador;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnConectarseJugador(ulong idJugador){
        contadorJugadores++;
        if (contadorJugadores == 2 && NetworkManager.Singleton.IsServer){
            for (int i = 0; i < 10; i++)
            {
                SpawnEnemigo(new Vector3(posicionInicialMarciano +i, 4, 0));
            }
            
        }
    }

    private void SpawnEnemigo(Vector3 posicion){
        NetworkManager.Singleton.OnClientConnectedCallback += OnConectarseJugador; 
        GameObject instanciaEnemigo = Instantiate(enemigo, posicion, Quaternion.identity);
        NetworkObject objetoRed = instanciaEnemigo.GetComponent<NetworkObject>();
        objetoRed.Spawn();
    }
}
