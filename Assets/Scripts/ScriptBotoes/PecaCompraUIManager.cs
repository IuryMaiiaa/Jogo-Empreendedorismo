using UnityEngine;
using System.Collections;

public class PecaCompraUIManager : MonoBehaviour {
    public GameObject GeradorAweSome;
    public GameObject turbina;
    public GameObject controleNave;
    public GameObject botaoGravidade;
    public GameObject silverTape;

    public GameObject panelOpenCurrent;

    public GerenciadoDeNacoes gerenciadorNacoes;
    public GerenciadorDeMapas gerenciadorMapas;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void openPanel()
    {
        Nacao nacao = gerenciadorNacoes.getNacaoAlienByPosicao(gerenciadorMapas.posX + "" + gerenciadorMapas.posY);
        if(nacao.getNascaoName().Equals("nascao0"))
        {
            setOpenCurrentPanel(GeradorAweSome);
        } else if (nacao.getNascaoName().Equals("nascao1"))
        {
            setOpenCurrentPanel(silverTape);
        }
        else if (nacao.getNascaoName().Equals("nascao2"))
        {
            setOpenCurrentPanel(turbina);
        }
        else if (nacao.getNascaoName().Equals("nascao3"))
        {
            setOpenCurrentPanel(controleNave);
        }
        else if (nacao.getNascaoName().Equals("nascao4"))
        {
            setOpenCurrentPanel(botaoGravidade);
        }
    }

    private void setOpenCurrentPanel(GameObject panel)
    {
        if(panelOpenCurrent != null)
        {
            panelOpenCurrent.SetActive(false);
            panelOpenCurrent = panel;
            panelOpenCurrent.SetActive(true);
        } else
        {
            panelOpenCurrent = panel;
            panelOpenCurrent.SetActive(true);
        }
            
    }

}
