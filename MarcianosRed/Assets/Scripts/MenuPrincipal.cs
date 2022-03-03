using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    public void OnClickBtnCliente(){

        OcultarGUI();
    }

    public void OnClickBtnServidor(){

        OcultarGUI();
    }

    public void OnClickBtnHost(){

        OcultarGUI();
    }

    private void OcultarGUI(){
        this.panel.gameObject.SetActive(false);
    }
}
