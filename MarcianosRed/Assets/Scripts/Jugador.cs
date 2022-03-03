using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Jugador : NetworkBehaviour
{
    [SerializeField]
    private float velocidad = 4;
    [SerializeField]
    private GameObject proyectil;
    float entrada;

    Vector3 siguientePosicion = Vector2.zero;

    void Start()
    {
        SituarAlJugadorEnPantalla();
    }

    // Update is called once per frame
    void Update()
    {
        entrada = Input.GetAxisRaw("Horizontal");
        this.siguientePosicion = this.transform.position + (Vector3.right * (entrada * Time.deltaTime * velocidad));
        if (siguientePosicion.x < 5 && siguientePosicion.x > -5)
        {
            this.transform.Translate(Vector3.right * (entrada * Time.deltaTime * velocidad));
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Disparar();
        }
    }

    //La pantalla tiene un alto de 5 unidades el jugador por defecto esta en alto 0
    //El primer jugador solo se movera 3 unidades hacia abajo y el jugador 2 4 
    //para eso utilizamos el ClientNetworkId
    private void SituarAlJugadorEnPantalla()
    {
        Vector3 posicion = this.transform.position;
        this.transform.position = posicion - (Vector3.up * (2 + OwnerClientId));
    }




    private void Disparar()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            SpawnProyectil();
        }
        else
        {
            if (IsOwner)
            {
                DispararServerRpc();
            }
        }
    }

    [ServerRpc]
    private void DispararServerRpc()
    {
        SpawnProyectil();
    }

    private void SpawnProyectil()
    {
        GameObject objeto = Instantiate(this.proyectil, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);
        NetworkObject objetoRed = objeto.GetComponent<NetworkObject>();
        objetoRed.Spawn();
    }
}
