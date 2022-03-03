using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo :  MonoBehaviour
{
    [SerializeField]
    private float velocidad = 2;
    Vector3 siguientePosicion = Vector3.zero;
    float direccion = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         this.transform.Translate(Vector3.right * Time.deltaTime * direccion * velocidad);
         if (this.transform.position.x > 5 || this.transform.position.x < -5){
             direccion *= -1;
         }
    }
}
