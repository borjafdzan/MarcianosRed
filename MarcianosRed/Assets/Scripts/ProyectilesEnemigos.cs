using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ProyectilesEnemigos : NetworkBehaviour 
{
    [SerializeField]
    float velocidad = 4;
    NetworkObject objetoRed;
    void Start()
    {
       this.objetoRed = GetComponent<NetworkObject>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.down * (Time.deltaTime * velocidad)); 
        if (this.transform.position.y < -10){
            if (IsServer){
                this.objetoRed.Despawn();
            }
        }
    }

    //Comprobamos si 
}
