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
            this.objetoRed.Despawn();
        }
    }
}
