using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Enemigo :  NetworkBehaviour
{
    [SerializeField]
    private float velocidad = 2;
    [SerializeField]
    private GameObject proyectil;
    Vector2 posicionInicial;
    Vector3 siguientePosicion = Vector3.zero;
    float direccion = 1;
    NetworkObject objetoRed;
    // Start is called before the first frame update
    void Start()
    {
        this.objetoRed = GetComponent<NetworkObject>();
       this.posicionInicial = this.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
         this.transform.Translate(Vector3.right * Time.deltaTime * direccion * velocidad);
         if (this.transform.position.x > this.posicionInicial.x + 2 || this.transform.position.x < this.posicionInicial.x - 2){
             direccion *= -1;
         }
         int valorAleatorio = Random.Range(0, 1000);
         if (valorAleatorio == 1){
             if (NetworkManager.Singleton.IsServer){
                 SpawnProyectil();
             } else {
                 if (IsOwner){
                     SpawnProyectilServerRpc();
                 }
             }
         }
    }

    //Si es el servidor entonces eliminadmos el objeto
    public void Morir(){
        if (IsServer){
            this.objetoRed.Despawn();
        }
    }

    [ServerRpc]
    private void SpawnProyectilServerRpc(){
        SpawnProyectil();
    }
    private void SpawnProyectil(){
        GameObject objeto = Instantiate(this.proyectil, new Vector3(this.transform.position.x, this.transform.position.y + 0.1f, this.transform.position.z), Quaternion.identity);
        NetworkObject objetoRed = objeto.GetComponent<NetworkObject>();
        objetoRed.Spawn();
    }
}
