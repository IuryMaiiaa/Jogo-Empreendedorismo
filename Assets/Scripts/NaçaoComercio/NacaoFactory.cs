using UnityEngine;
using System.Collections;

public class NacaoFactory {
    public RecursoEnum recursoEnum;
    public static string nascaoPadraoNome = "nascao";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public NacaoFactory()
    {
        recursoEnum = new RecursoEnum();
    }


    public ArrayList criarNacoes(GameObject nacaoPrefab)
    {
        ArrayList nacoes = new ArrayList();
        for(int cont=0;cont<5;cont++)
        {
            GameObject nacaoGameObject = GameObject.Instantiate(nacaoPrefab) as GameObject;
            Nacao nacao = nacaoGameObject.GetComponent<Nacao>().getNacao();
            nacao = adicionarConsumo(nacao);
            nacao = adicionarObjetivo(nacao);
            nacao = adicionarProducao(nacao);
            nacao = adicionarSaveAtual(nacao);
            nacao = adicionarNacaoComercioGerente(nacao);
            nacao = adicionarNacaoArmazem(nacao);
            nacao.setNascaoName(nascaoPadraoNome + cont);
            nacoes.Add(nacao);
        }
        return nacoes;
    }

    public ArrayList loadNacoes(GameObject nacaoPrefab)
    {
        ArrayList nacoes = new ArrayList();
        for(int cont = 0; cont < 5; cont++)
        {
            GameObject nacaoGameObject = GameObject.Instantiate(nacaoPrefab) as GameObject;
            Nacao nacao = nacaoGameObject.GetComponent<Nacao>().getNacao();
            nacao.setNascaoName(nascaoPadraoNome + cont);
            nacao.load();
            nacoes.Add(nacao);
        }
        return nacoes;
    }

    public Nacao adicionarNacaoArmazem(Nacao nacao)
    {
        NacaoArmazem armazem = new NacaoArmazem();
        nacao.setArmazem(armazem);
        return nacao;
    }

    public Nacao adicionarSaveAtual(Nacao nacao)
    {
        nacao.saveAtual = GameObject.FindObjectOfType<SaveAtual>();
        return nacao;
    }

    public Nacao criarNacaoComercioGerente(Nacao nacao)
    {
        nacao.nacaoComercioGerente = new NacaoComercioGerente();
        return nacao;
    }

    public Nacao adicionarObjetivo(Nacao nacao)
    {
        Objetivo objetivo = new Objetivo();
        objetivo.setRecurso(sortearRecurso());
        objetivo.setMeta(2000);
        nacao.setObjetivo(objetivo);
        return nacao;
    }

    public Nacao adicionarConsumo(Nacao nascao)
    {
        Consumo consumo = new Consumo();
        consumo.setRecurso(sortearRecurso());
        consumo.setConsumoPeriodico(20);
        nascao.setConsumo(consumo);
        return nascao;
    }

    public Nacao adicionarProducao(Nacao nascao)
    {
        Producao producao = new Producao();
        producao.setRecurso(sortearRecurso());
        producao.setProducao(40);
        nascao.setProducao(producao);
        return nascao;
    }

    public Nacao adicionarArmaem(Nacao nascao)
    {
        NacaoArmazem armazem = new NacaoArmazem();
        nascao.setArmazem(armazem);
        return nascao;
    }

    public Nacao adicionarNacaoComercioGerente(Nacao nascao)
    {
        NacaoComercioGerente comercio = new NacaoComercioGerente();
        nascao.nacaoComercioGerente = comercio;
        return nascao;
    }

    public void reformularEconomia(Nacao nacao)
    {
        nacao = adicionarConsumo(nacao);
        nacao = adicionarObjetivo(nacao);
        nacao = adicionarProducao(nacao);
    }

    public string sortearRecurso()
    {
        float valor = Random.value * 100000;
        int valorInteiro = (int)valor;
        valorInteiro = valorInteiro % 3;
        if (valorInteiro == 0)
        {
            return recursoEnum.getPlantaRecursoString();
        }
        else if (valorInteiro == 1)
        {
            return recursoEnum.getCouroRecursoString();
        }
        else if (valorInteiro == 2)
        {
            return recursoEnum.getMelecarRecursoString();
        }
        return null;
    }

}
