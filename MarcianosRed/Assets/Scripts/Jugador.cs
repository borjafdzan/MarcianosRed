using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField]
    private float velocidad = 4;
    float entrada;

    Vector3 siguientePosicion = Vector2.zero;
    // Start is called before the first frame update
    void Start()
    {

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
    }
}
