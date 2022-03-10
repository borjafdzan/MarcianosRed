using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo :  MonoBehaviour
{
    [SerializeField]
    private float velocidad = 2;
    Vector2 posicionInicial;
    Vector3 siguientePosicion = Vector3.zero;
    float direccion = 1;
    // Start is called before the first frame update
    void Start()
    {
       this.posicionInicial = this.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
         this.transform.Translate(Vector3.right * Time.deltaTime * direccion * velocidad);
         if (this.transform.position.x > this.posicionInicial.x + 2 || this.transform.position.x < this.posicionInicial.x - 2){
             direccion *= -1;
         }
    }
}
