using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Proyectiles : NetworkBehaviour
{
    [SerializeField]
    float velocidad = 4;
    NetworkObject objetoRed;
    // Start is called before the first frame update
    void Start()
    {
        this.objetoRed = GetComponent<NetworkObject>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.up * (Time.deltaTime * velocidad));
        if (this.transform.position.y > 10){
            //Destroy(gameObject);
            if (IsServer){
                this.objetoRed.Despawn();
            }
            
        }
    }



    //Cada vez que un proyectil colisiona con un enemigo el enemigo se muere
    private void OnTriggerEnter2D(Collider2D colisionador){
        Enemigo enemigo = colisionador.gameObject.GetComponent<Enemigo>();
        if (enemigo){
            Debug.Log("el proyectil colisiona con el enemigo");
            //Ahora accederemos al componente de red del enemigo
            enemigo.Morir();
        }
    }
}
