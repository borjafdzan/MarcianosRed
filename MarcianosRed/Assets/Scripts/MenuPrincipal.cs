using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField]
    GameObject panel;

    public void OnClickBtnCliente(){
        NetworkManager.Singleton.StartClient();
        OcultarGUI();
    }

    public void OnClickBtnServidor(){
        NetworkManager.Singleton.StartServer();
        OcultarGUI();
    }

    public void OnClickBtnHost(){
        NetworkManager.Singleton.StartHost();
        OcultarGUI();
    }

    private void OcultarGUI(){
        this.panel.gameObject.SetActive(false);
    }
}
