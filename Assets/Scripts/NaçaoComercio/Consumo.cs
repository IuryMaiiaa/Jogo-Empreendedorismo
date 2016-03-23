using UnityEngine;
using System.Collections;

public class Consumo : MonoBehaviour {
    public string recurso;
    public int consumoPeriodico;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setRecurso(string recursoNome)
    {
        this.recurso = recursoNome;
    }

    public void setConsumoPeriodico(int consumoPeriodico)
    {
        this.consumoPeriodico = consumoPeriodico;
    }

    public string getRecurso()
    {
        return recurso;
    }

    public int getConsumoPeriodico()
    {
        return consumoPeriodico;
    }
}
