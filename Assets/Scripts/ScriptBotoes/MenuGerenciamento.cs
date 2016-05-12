using UnityEngine;
using System.Collections;

public class MenuGerenciamento : MonoBehaviour {
    public GameObject panelAtual;
    public GameObject naveCurso;
    public GameObject menuPrincipal;


	// Use this for initialization
	void Start () {
        menuPrincipal.SetActive(true);
        menuPrincipal.GetComponent<MenuPrincipalComportamento>().setNaveCursor(naveCurso);
        panelAtual = menuPrincipal;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ativarPanel(GameObject panel)
    {
        panelAtual.SetActive(false);
        panelAtual = panel;
        panelAtual.SetActive(true);
        if(panelAtual.GetComponent<MenuPrincipalComportamento>() != null)
        {
            panelAtual.GetComponent<MenuPrincipalComportamento>().setNaveCursor(naveCurso);
        }
    }
}
