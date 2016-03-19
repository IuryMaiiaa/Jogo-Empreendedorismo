using UnityEngine;
using System.Collections;

public class NacaoArmazem : MonoBehaviour,SaveInterface {
    private int recursoPlanta;
    private int recursoMeleca;
    private int recursoCouro;
    private int dinheiro;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setRecursoPlanta(int quanidade)
    {
        this.recursoPlanta = quanidade;
    }

    public void setRecursoMeleca(int quanidade)
    {
        this.recursoMeleca = quanidade;
    }

    public void setRecursoCouro(int quanidade)
    {
        this.recursoCouro = quanidade;
    }

    public void setDinheiro(int quanidade)
    {
        this.dinheiro = quanidade;
    }

    public int getPlantas()
    {
        return recursoPlanta;
    }

    public int getMeleca()
    {
        return recursoMeleca;
    }

    public int getCouro()
    {
        return recursoCouro;
    }

    public int getDinheiro()
    {
        return dinheiro;
    }

    public void save()
    {

    }

    public void load()
    {

    }
}
