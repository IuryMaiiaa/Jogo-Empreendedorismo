using UnityEngine;
using System.Collections;
using System;

public class ComprasPanelGerencia : MonoBehaviour {
    public GameObject panelComprarMelecas;
    public GameObject panelComprarPlantas;
    public GameObject panelComprarCouro;

    public UnityEngine.UI.Text quantidadeRecursoMelecas;
    public UnityEngine.UI.Text quantidadeRecursoPlantas;
    public UnityEngine.UI.Text quantidadeRecursoCouro;

    public UnityEngine.UI.Text valorRecursoMelecas;
    public UnityEngine.UI.Text valorRecursoPlantas;
    public UnityEngine.UI.Text valorRecursoCouro;

    public UnityEngine.UI.InputField inputValorMelecas;
    public UnityEngine.UI.InputField inputValorPlantas;
    public UnityEngine.UI.InputField inputValorCouro;

    public GerenciadorDeMapas gerenciadorMapas;
    public GerenciadoDeNacoes gerenciadorNacoes;
    public ArmazemGerenciamento armazemPlayer;
    
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void fecharTodosPanelCompra()
    {
        panelComprarPlantas.SetActive(false);
        panelComprarCouro.SetActive(false);
        panelComprarMelecas.SetActive(false);
    }

    public void abriPanelComprasMelecas()
    {
        Nacao nacao = gerenciadorNacoes.getNacaoAlienByPosicao(gerenciadorMapas.posX + "" + gerenciadorMapas.posY);
        panelComprarMelecas.SetActive(true);
        quantidadeRecursoMelecas.text = nacao.getArmazem().getMeleca()+"";
        valorRecursoMelecas.text = nacao.nacaoComercioGerente.getMelecaPreco() + "";
        panelComprarPlantas.SetActive(false);
        panelComprarCouro.SetActive(false);
    }

    public void abriPanelComprasPlantas()
    {
        Nacao nacao = gerenciadorNacoes.getNacaoAlienByPosicao(gerenciadorMapas.posX + "" + gerenciadorMapas.posY);
        panelComprarPlantas.SetActive(true);
        quantidadeRecursoPlantas.text = nacao.getArmazem().getPlantas() + "";
        valorRecursoPlantas.text = nacao.nacaoComercioGerente.getPlantaPreco() + "";
        panelComprarMelecas.SetActive(false);
        panelComprarCouro.SetActive(false);
    }

    public void abrirPanelComprasCouro()
    {
        Nacao nacao = gerenciadorNacoes.getNacaoAlienByPosicao(gerenciadorMapas.posX + "" + gerenciadorMapas.posY);
        panelComprarCouro.SetActive(true);
        quantidadeRecursoCouro.text = nacao.getArmazem().getCouro() + "";
        valorRecursoCouro.text = nacao.nacaoComercioGerente.getCouroPreco() + "";
        panelComprarPlantas.SetActive(false);
        panelComprarMelecas.SetActive(false);
    }

    public void comprarRecursos(String recurso)
    {
        String valorInput = getInputValor();
        int valorInteiro = Int32.Parse(valorInput);
        Nacao nacao = gerenciadorNacoes.getNacaoAlienByPosicao(gerenciadorMapas.posX+""+gerenciadorMapas.posY);
        if (nacao.getArmazem().getQuantidadeRecurso(recurso) <= valorInteiro){
            if((nacao.nacaoComercioGerente.getPrecoRecurso(recurso)*valorInteiro) <= armazemPlayer.dinheiro)
            {
                nacao.getArmazem().setQuantidadeRecurso(recurso, nacao.getArmazem().getQuantidadeRecurso(recurso) - valorInteiro);
                nacao.getArmazem().setDinheiro(nacao.getArmazem().getDinheiro() + 
                                               nacao.nacaoComercioGerente.getPrecoRecurso(recurso) * valorInteiro);
                armazemPlayer.adicionarRecurso(recurso, valorInteiro);
                armazemPlayer.dinheiro = armazemPlayer.dinheiro - nacao.getArmazem().getDinheiro() +
                                                                  nacao.nacaoComercioGerente.getPrecoRecurso(recurso) * valorInteiro;
                fecharTodosPanelCompra();
            }
        }
    }

    public string getInputValor()
    {
        if(inputValorCouro.IsActive() == true)
        {
            return inputValorCouro.text.ToString();
        } else if (inputValorMelecas.IsActive() == true)
        {
            return inputValorMelecas.text.ToString();
        } else if (inputValorPlantas.IsActive() == true)
        {
            return inputValorPlantas.text.ToString();
        }
        return null;
    }


}
