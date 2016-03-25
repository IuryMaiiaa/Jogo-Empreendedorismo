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

    public Nacao[] criarNacoes()
    {
        Nacao[] nacoes = new Nacao[5];
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
        objetivo.setRecurso(recursoEnum.getCouroRecursoString());
        objetivo.setMeta(2000);
        nascao.setObjetivo(objetivo);
        return nascao;
    }
}
