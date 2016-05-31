using UnityEngine;
using System.Collections;

public class ControladorMenu : MonoBehaviour {

    public GameObject menuPrincipal;

    public GameObject[] menuSazonais;
    public GameObject[] menuFixos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void abrirMenuPrincipal()
    {
        menuPrincipal.SetActive(true);
    }

    public void fecharMenus()
    {
        foreach (GameObject menu in menuSazonais)
        {
            if(menu.active == true)
            {
                menu.SetActive(false);
            }
        }
    }

    public void abrirMenusFixos()
    {
        foreach (GameObject menu in menuFixos)
        {
            if(menu.active == false)
            {
                menu.SetActive(true);
            }
        }
    }
}
