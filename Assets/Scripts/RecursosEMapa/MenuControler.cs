using UnityEngine;
using System.Collections;

public class MenuControler : MonoBehaviour {
    public GameObject MenuOpcoesRecurso;
    public GameObject MenuJogo;
    public bool menuAberto;
    public float tempoMenuAberto;
    public AnimationOpenPanel animationPanel;
    

    // Use this for initialization
    void Start () {
        this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x,
                                                         this.gameObject.transform.position.y,
                                                         this.gameObject.transform.position.z-90);
        animationPanel = this.gameObject.GetComponent<AnimationOpenPanel>();
        menuAberto = true;
        MenuOpcoesRecurso.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (!menuAberto)
        {
            tempoMenuAberto = Time.time; 
            menuAberto = true;
        } else if (menuAberto && tempoMenuAberto + 6f < Time.time )
        {
            
            MenuOpcoesRecurso.SetActive(false);
            menuAberto = true;
        }

    }

    public void AcinonarMenuOpcoesRecurso(GameObject botaoChamado)
    {
        menuAberto = false;
        MenuJogo.SetActive(true);
        MenuOpcoesRecurso.SetActive(true);
        MenuOpcoesRecurso.transform.position = new Vector3(botaoChamado.gameObject.transform.position.x, botaoChamado.gameObject.transform.position.y, botaoChamado.gameObject.transform.position.z - 1);
        MenuJogo.transform.position = new Vector3(MenuJogo.transform.position.x,MenuJogo.transform.position.y,botaoChamado.gameObject.transform.position.z-5);
    }

    public void TextBotao()
    {
        Debug.Log("apertado");
    }

    public void menuOpcoesAbertura(GameObject panel)
    {
        animationPanel.menuOpcoesAbertura(panel);
    }

    public void menuOpcoesFechamento(GameObject panel)
    {
        animationPanel.menuOpcoesFechamento(panel);
    }

    public void FecharMenus()
    {
        
    }



}
