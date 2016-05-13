using UnityEngine;
using System.Collections;

public class botaoStatusRecurso : MonoBehaviour {
    public GameObject panelAtivar;
    public bool ativar;

	// Use this for initialization
	void Start () {
        ativar = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ativarDesativarBotao()
    {
        if(ativar == false)
        {
            panelAtivar.SetActive(true);
            ativar = true;
        } else if (ativar == true)
        {
            panelAtivar.SetActive(false);
            ativar = false;
        }
    }
}
