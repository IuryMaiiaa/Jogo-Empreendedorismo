using UnityEngine;
using System.Collections;
using System;

public class VendasPanelGerencia : MonoBehaviour {

    public UnityEngine.UI.Text ValorMeleca;
    public UnityEngine.UI.Text valorPlanta;
    public UnityEngine.UI.Text valorCouro;

    public UnityEngine.UI.InputField inputValorMeleca;
    public UnityEngine.UI.InputField inputValorPlanta;
    public UnityEngine.UI.InputField inputValorCouro;

    public GameObject panelMelecaVenda;
    public GameObject panelPlantaVenda;
    public GameObject panelCouroVenda;

    public GerenciadorDeMapas gerenciadorMapas;
    public GerenciadoDeNacoes gerenciadorNacoes;
    public ArmazemGerenciamento armazemPlayer;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void fecharTodosPaineisVenda()
    {
        panelMelecaVenda.SetActive(false);
        panelPlantaVenda.SetActive(false);
        panelCouroVenda.SetActive(false);
    }

    public void abrirPanelVendaMeleca()
    {
        fecharTodosPaineisVenda();
        Nacao nacao = gerenciadorNacoes.getNacaoAlienByPosicao(gerenciadorMapas.posX + "" + gerenciadorMapas.posY);
        panelMelecaVenda.SetActive(true);
        ValorMeleca.text = nacao.nacaoComercioGerente.getMelecaPreco()+"";

    }

    public void abrirPanelVendaPlanta()
    {
        fecharTodosPaineisVenda();
        Nacao nacao = gerenciadorNacoes.getNacaoAlienByPosicao(gerenciadorMapas.posX + "" + gerenciadorMapas.posY);
        panelPlantaVenda.SetActive(true);
        valorPlanta.text = nacao.nacaoComercioGerente.getPlantaPreco() + "";
    }

    public void abrirPanelVendaCouro()
    {
        fecharTodosPaineisVenda();
        Nacao nacao = gerenciadorNacoes.getNacaoAlienByPosicao(gerenciadorMapas.posX + "" + gerenciadorMapas.posY);
        panelCouroVenda.SetActive(true);
        valorCouro.text = nacao.nacaoComercioGerente.getCouroPreco() + "";
    }

    public void VenderRecurso(string recurso)
    {
        Debug.LogWarning("chego");
        string valorInput = getInputValor();
        int valorInteiro = Int32.Parse(valorInput);
        Nacao nacao = gerenciadorNacoes.getNacaoAlienByPosicao(gerenciadorMapas.posX + "" + gerenciadorMapas.posY);
        if(armazemPlayer.getRecurso(recurso) <= valorInteiro)
        {
            armazemPlayer.setRecurso(recurso, armazemPlayer.getRecurso(recurso) - valorInteiro);
            armazemPlayer.dinheiroAdicioanr(armazemPlayer.dinheiro +
                                            (nacao.nacaoComercioGerente.getPrecoRecurso(recurso) * valorInteiro));
            nacao.getArmazem().setQuantidadeRecurso(recurso, nacao.getArmazem().getQuantidadeRecurso(recurso)+valorInteiro);
            nacao.getArmazem().setDinheiro(nacao.getArmazem().getDinheiro()-
                                          (nacao.nacaoComercioGerente.getPrecoRecurso(recurso) * valorInteiro));
            fecharTodosPaineisVenda();
        }
    }


    public string getInputValor()
    {
        if (inputValorCouro.IsActive() == true)
        {
            return inputValorCouro.text.ToString();
        }
        else if (inputValorMeleca.IsActive() == true)
        {
            return inputValorMeleca.text.ToString();
        }
        else if (inputValorPlanta.IsActive() == true)
        {
            return inputValorPlanta.text.ToString();
        }
        return null;
    }
}
