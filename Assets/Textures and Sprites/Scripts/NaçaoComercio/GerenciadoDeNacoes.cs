using UnityEngine;
using System.Collections;

public class GerenciadoDeNacoes : MonoBehaviour,SaveInterface {

    public ArrayList nacoes;
    public GameObject NacaoPrefab;
    private NacaoFactory nacaoFactory;
    private int quantidadeMaximoRecurso = 2000;
    public float timerGerarProducao=0;
    public float timerRealizarComercio=0;
    public bool prontoParaJogar;

	// Use this for initialization
	void Start () {
        prontoParaJogar = false;
        nacaoFactory = new NacaoFactory();
        float timerGerarProducao = Time.time;
        float timerRealizarComercio = Time.time;

	}
	
	// Update is called once per frame
	void Update () {
        if(prontoParaJogar == true)
        {
            rotacaoTimerProducao();
            rotacaoTimerIANacao();
            chegarObjetivoNacoes();
        }
        
        
	}

    public void chegarObjetivoNacoes()
    {
        foreach(Nacao nacao in nacoes)
        {
            if(nacao.getObjetivo().objetivoCompleto(nacao.getArmazem()))
            {
                reformularEconomiaNacao(nacao);
            }
        }
    }

    public void reformularEconomiaNacao(Nacao nacao)
    {
        nacaoFactory.reformularEconomia(nacao);
    }

    public void rotacaoTimerIANacao()
    {
        if(timerRealizarComercio+2 < Time.time)
        {
            foreach(Nacao nacao in nacoes)
            {
                Debug.Log("nome: " + nacao.nascaoNome + " couro: " + nacao.getArmazem().getCouro() +
                                                       " Meleca: " + nacao.getArmazem().getMeleca() +
                                                       " planta: " + nacao.getArmazem().getPlantas() +
                                                       " Dinheiro: " + nacao.getArmazem().getDinheiro());
            }
            turnoCormercioNacoes();
            timerRealizarComercio = Time.time;
        }
    }

    public void rotacaoTimerProducao()
    {
        if(timerGerarProducao+1< Time.time)
        {
            turnoGerarProducaoConsumo();
            timerGerarProducao = Time.time;
        }
    }

    public void turnoGerarProducaoConsumo()
    {
        foreach(Nacao nacao in nacoes)
        {
            if(nacao!=null)
            {
                nacao.GerarProducaoConsumo();
            }
        }
    }

    public void setNacoes(ArrayList nacoes)
    {
        this.nacoes = nacoes;
    }

    public void criarNascoes()
    {
        this.nacoes = nacaoFactory.criarNacoes(NacaoPrefab);
        foreach (Nacao nacao in nacoes) {
            Debug.Log("nome:"+nacao.nascaoNome +" producao:" + nacao.getProducao().getRecurso() + 
                                "consumo:"  + nacao.getConsumo().getRecurso() + " Objetivo:" +nacao.getObjetivo().getRecurso() );
        }
        save();
        prontoParaJogar = true;
    }

    public void criarNascoesLoad()
    {
        this.nacoes = nacaoFactory.loadNacoes(NacaoPrefab);
        foreach (Nacao nacao in nacoes)
        {
            Debug.Log("nome:" + nacao.nascaoNome + " producao:" + nacao.getProducao().getRecurso() +
                                "consumo:" + nacao.getConsumo().getRecurso() + " Objetivo:" + nacao.getObjetivo().getRecurso());
        }
        definirPrecoPadraoRecurso();
        save();
        prontoParaJogar = true;
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
        int mediaDoRecurso = valorTotalRecurso / nacoes.Count;
        int valorPorcentagem = (mediaDoRecurso * 100) / quantidadeMaximoRecurso;
        if (valorPorcentagem == 0)
        {
            valorPadraoPago = 0;
        }
        else
        {
            float valorAuxDivisao = valorPorcentagem / 80;
            valorAuxDivisao = mediaDoRecurso / valorAuxDivisao;
            valorPadraoPago = (int)(valorAuxDivisao / valorPorcentagem);
        }
        foreach (Nacao nascao in nacoes)
        {
            nascao.setPlantaPreco(valorPadraoPago);
        }
    }

    public void definirPrecoCouro()
    {
        
        int valorPadraoPago = 0;
        int valorTotalRecurso = 0;
        foreach (Nacao nacao in nacoes)
        {
            valorTotalRecurso += nacao.getArmazem().getCouro();         
        }
        int mediaDoRecurso = valorTotalRecurso / nacoes.Count;
        int valorPorcentagem = (mediaDoRecurso * 100) / quantidadeMaximoRecurso;
        if(valorPorcentagem == 0)
        {
            valorPadraoPago = 0;
        } else
        {
            float valorAuxDivisao = valorPorcentagem / 80;
            valorAuxDivisao = mediaDoRecurso / valorAuxDivisao;
            valorPadraoPago = (int)(valorAuxDivisao / valorPorcentagem);
        }
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
            valorTotalRecurso = valorTotalRecurso + nascao.getArmazem().getMeleca();
        }
        int mediaDoRecurso = valorTotalRecurso / nacoes.Count;
        int valorPorcentagem = (mediaDoRecurso * 100) / quantidadeMaximoRecurso;
        if (valorPorcentagem == 0)
        {
            valorPadraoPago = 0;
        } else
        {
            float valorAuxDivisao = valorPorcentagem / 40;
            valorPadraoPago = (int)(mediaDoRecurso / valorAuxDivisao);
            //valorAuxDivisao = mediaDoRecurso / valorAuxDivisao;
            //valorPadraoPago = (int)(valorAuxDivisao / valorPorcentagem);
        }
        foreach (Nacao nascao in nacoes)
        {
            nascao.setMelecaPreco(valorPadraoPago);
        }
    }

}
