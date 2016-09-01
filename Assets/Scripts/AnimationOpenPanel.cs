using UnityEngine;
using System.Collections;

public class AnimationOpenPanel : MonoBehaviour {
    public GameObject panel;
    public GameObject pontoEsquerdo;
    public bool MenuAberto;
    public bool MenuPanelAbertura;

    // Use this for initialization
    void Start () {
        MenuPanelAbertura = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        if (MenuPanelAbertura && 
            panel.GetComponent<PanelPadraoMenuOpcoes>().largura.transform.position.x>pontoEsquerdo.transform.position.x)
        {
            panel.transform.position = new Vector3(panel.transform.position.x-0.5f,
                                                  panel.transform.position.y, 
                                                  panel.transform.position.z);
            MenuAberto = true;
        } else if (!MenuPanelAbertura &&
                    panel.GetComponent<PanelPadraoMenuOpcoes>().largura.transform.position.x < 
                    pontoEsquerdo.transform.position.x+ 2*panel.GetComponent<PanelPadraoMenuOpcoes>().getLargura())
        {
            panel.transform.position = new Vector3(panel.transform.position.x + 0.5f,
                                                  panel.transform.position.y,
                                                  panel.transform.position.z);
            MenuAberto = false;
        }
        else if (!MenuPanelAbertura &&
                  panel.GetComponent<PanelPadraoMenuOpcoes>().largura.transform.position.x >=
                  pontoEsquerdo.transform.position.x + 2 * panel.GetComponent<PanelPadraoMenuOpcoes>().getLargura())
        {
            panel.SetActive(false);
        }

    }

    public void menuOpcoesAbertura(GameObject panel)
    {
        if (MenuPanelAbertura)
        {
            this.panel.transform.position = new Vector3(pontoEsquerdo.transform.position.x + 2 * this.panel.GetComponent<PanelPadraoMenuOpcoes>().getLargura(),
                                                        this.panel.transform.position.y, this.panel.transform.position.z);
            panel.SetActive(false);
        } 
        panel.SetActive(true);
        this.panel = panel;
        MenuPanelAbertura = true;
    }

    public void menuMapaAbertura(GameObject panel)
    {
        if (MenuPanelAbertura)
        {
            panel.SetActive(false);
        }
        panel.SetActive(true);
        this.panel = panel;
        //MenuPanelAbertura = true;
    }

    public void menuOpcoesFechamento(GameObject panel)
    {
        MenuPanelAbertura = false;
    }
}
