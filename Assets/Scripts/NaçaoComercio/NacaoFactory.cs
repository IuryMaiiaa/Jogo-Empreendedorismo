using UnityEngine;
using System.Collections;

public class NacaoFactory : MonoBehaviour,SaveInterface {
    public RecursoEnum recursoEnum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public ArrayList criarNacoes()
    {
        ArrayList nacoes = new ArrayList();
        for(int cont=0;cont<5;cont++)
        {
            Nacao nacao = new Nacao();
            nacao = adicionarConsumo(nacao);
            nacao = adicionarObjetivo(nacao);
            nacao = adicionarProducao(nacao);
            nacao.setNascaoName("nascao"+cont);
            nacoes.Add(nacao);
        }
        return nacoes;
    }

    public void save()
    {
        
    }

    public void load()
    {

    }


    public Nacao adicionarObjetivo(Nacao nascao)
    {
        Objetivo objetivo = new Objetivo();
        objetivo.setRecurso(sortearRecurso());
        objetivo.setMeta(2000);
        nascao.setObjetivo(objetivo);
        return nascao;
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
