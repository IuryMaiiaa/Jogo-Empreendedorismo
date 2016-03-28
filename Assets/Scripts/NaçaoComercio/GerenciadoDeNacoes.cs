using UnityEngine;
using System.Collections;

public class GerenciadoDeNacoes : MonoBehaviour,SaveInterface {

    private ArrayList nacoes;
    private NacaoFactory nacaoFactory;

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

    }

    public void definirPrecoPadraoRecurso()
    {

    }

}
