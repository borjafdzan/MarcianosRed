using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class SpawnEnemigos : MonoBehaviour
{
    [SerializeField]
    GameObject enemigo;
    int contadorJugadores = 0;
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
        if (contadorJugadores == 2){
            SpawnEnemigo();
        }
    }

    private void SpawnEnemigo(){
        NetworkManager.Singleton.OnClientConnectedCallback += OnConectarseJugador; 
        GameObject instanciaEnemigo = Instantiate(enemigo, new Vector3(0, 4, 0), Quaternion.identity);
        NetworkObject objetoRed = instanciaEnemigo.GetComponent<NetworkObject>();
        objetoRed.Spawn();
    }
}
