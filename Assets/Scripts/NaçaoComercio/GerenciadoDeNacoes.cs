using UnityEngine;
using System.Collections;

public class GerenciadoDeNacoes : MonoBehaviour,SaveInterface {

    private ArrayList nacoes;
    private NacaoFactory nacaoFactory;
    private int quantidadeMaximoRecurso = 2000;

	// Use this for initialization
	void Start () {
        nacaoFactory = new NacaoFactory();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setNacoes(ArrayList nacoes)
    {
        this.nacoes = nacoes;
    }

    public void criarNascoes()
    {
        this.nacoes = nacaoFactory.criarNacoes();
    }

    public void criarNascoesLoad()
    {
        this.nacoes = nacaoFactory.loadNacoes();
    }

    public void save()
    {
        foreach(Nacao nacao in nacoes)
        {
            nacao.save();
        }
    }

    public void turnoCormercioNacoes()
    {
        definirPrecoPadraoRecurso();
        rodadaComercio();
    }

    public void rodadaComercio()
    {
        foreach(Nacao nacao in nacoes)
        {
            if(nacao!=null)
            {
                nacao.realizarComercio(criarSubArrayNacao(nacoes, nacao));
            }
        }
    }

    public ArrayList criarSubArrayNacao(ArrayList nacoes,Nacao nacao)
    {
        ArrayList nascoesSubArray = new ArrayList();
        foreach(Nacao aux in nacoes)
        {
            if(aux!=null && aux!=nacao)
            {
                nascoesSubArray.Add(aux);
            }
        }
        return nascoesSubArray;
    }

    public void definirPrecoPadraoRecurso()
    {
        definirPrecoCouro();
        definirPrecoMeleca();
        definirPrecoPlanta();
    }

    public void definirPrecoPlanta()
    {
        int valorPadraoPago = 0;
        int valorTotalRecurso = 0;
        foreach(Nacao nascao in nacoes)
        {
            valorTotalRecurso += nascao.getArmazem().getPlantas();
        }
        int mediaDoRecurso = valorTotalRecurso / nacoes.Capacity;
        int valorPorcentagem = (mediaDoRecurso * 100) / quantidadeMaximoRecurso;
        valorPadraoPago = (mediaDoRecurso * (valorPorcentagem-100)) / valorPorcentagem;
        foreach (Nacao nascao in nacoes)
        {
            nascao.setPlantaPreco(valorPadraoPago);
        }
    }

    public void definirPrecoCouro()
    {
        int valorPadraoPago = 0;
        int valorTotalRecurso = 0;
        foreach (Nacao nascao in nacoes)
        {
            valorTotalRecurso += nascao.getArmazem().getCouro();
        }
        int mediaDoRecurso = valorTotalRecurso / nacoes.Capacity;
        int valorPorcentagem = (mediaDoRecurso * 100) / quantidadeMaximoRecurso;
        valorPadraoPago = (mediaDoRecurso * (valorPorcentagem - 100)) / valorPorcentagem;
        foreach (Nacao nascao in nacoes)
        {
            nascao.setCouroPreco(valorPadraoPago);
        }
    }

    public void definirPrecoMeleca()
    {
        int valorPadraoPago = 0;
        int valorTotalRecurso = 0;
        foreach (Nacao nascao in nacoes)
        {
            valorTotalRecurso += nascao.getArmazem().getMeleca();
        }
        int mediaDoRecurso = valorTotalRecurso / nacoes.Capacity;
        int valorPorcentagem = (mediaDoRecurso * 100) / quantidadeMaximoRecurso;
        valorPadraoPago = (mediaDoRecurso * (valorPorcentagem - 100)) / valorPorcentagem;
        foreach (Nacao nascao in nacoes)
        {
            nascao.setMelecaPreco(valorPadraoPago);
        }
    }

}
