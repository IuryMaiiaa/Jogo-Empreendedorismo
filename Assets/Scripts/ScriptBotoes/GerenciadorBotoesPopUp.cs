using UnityEngine;
using System.Collections;

public class GerenciadorBotoesPopUp : MonoBehaviour {
    public GameObject menuPopUpNave;
    public GameObject menuPopUpAlien;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void abrirMenuNavePopUp()
    {
        menuPopUpNave.SetActive(true);
        Transform posicao = GameObject.FindObjectOfType<GerenciadorObjetosCenario>().atualCentro.transform;
        menuPopUpNave.transform.position = new Vector3(posicao.position.x, posicao.position.y, menuPopUpNave.transform.position.z); 
    }

    public void fecharMenuNavePopUp()
    {
        menuPopUpNave.SetActive(false);
    }

    public void abrirMenuAlienPopUp()
    {
        menuPopUpAlien.SetActive(true);
        Transform posicaoCentroAlien = GameObject.FindObjectOfType<GerenciadorObjetosCenario>().atualCentro.transform;
        menuPopUpAlien.transform.position = new Vector3(posicaoCentroAlien.position.x-5, posicaoCentroAlien.position.y, menuPopUpAlien.transform.position.z);
    }

    public void fecharMenuAlienPopUp()
    {
        menuPopUpAlien.SetActive(false);
    }
}
