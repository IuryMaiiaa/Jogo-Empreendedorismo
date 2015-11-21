using UnityEngine;
using System.Collections;

public class MenuControler : MonoBehaviour {
    public GameObject MenuOpcoesRecurso;
    public GameObject MenuJogo;
    public bool menuAberto;
    public float tempoMenuAberto;

    // Use this for initialization
    void Start () {
        menuAberto = false;
        MenuJogo.SetActive(false);
        MenuOpcoesRecurso.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (menuAberto==true)
        {
            tempoMenuAberto = Time.time; 
            menuAberto = false;
        } else if (!menuAberto && tempoMenuAberto>Time.time+1f)
        {
            MenuOpcoesRecurso.SetActive(false);
        }
	
	}

    public void AcinonarMenuOpcoesRecurso(GameObject botaoChamado)
    {
        menuAberto = true;
        MenuOpcoesRecurso.SetActive(true);
        MenuJogo.SetActive(true);
        MenuJogo.transform.position = new Vector3(MenuJogo.transform.position.x,MenuJogo.transform.position.y,botaoChamado.gameObject.transform.position.z);
        MenuOpcoesRecurso.transform.position = botaoChamado.gameObject.transform.position;
    }
}
