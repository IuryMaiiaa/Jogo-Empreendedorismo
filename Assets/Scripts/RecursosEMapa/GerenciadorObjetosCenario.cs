using UnityEngine;
using System.Collections;

public class GerenciadorObjetosCenario : MonoBehaviour {
    //alien Estruturas
    public GameObject laranjaCabana;
    public GameObject laranjaCentro;
    public GameObject laranjaPoste;
    public GameObject laranjaTorre;

    public GameObject roxoCabana;
    public GameObject roxoCentro;
    public GameObject roxoPoste;
    public GameObject roxoTorre;

    public GameObject verdeCabana;
    public GameObject verdeCentro;
    public GameObject verdePoste;
    public GameObject verdeTorre;

    public GameObject azulCabana;
    public GameObject azulCentro;
    public GameObject azulPoste;
    public GameObject azulTorre;

    public GameObject vermelhoCabana;
    public GameObject vermelhoCentro;
    public GameObject vermelhoPoste;
    public GameObject vermelhoTorre;

    //player navePrefab
    public GameObject naveClone;
    public GameObject cabanaClone;

    public GameObject atualCabana;
    public GameObject atualCentro;
    public GameObject atualPoste;
    public GameObject atualTorre;

    public Transform cabanaPosicao;
    public Transform centroPosicao;
    public Transform postePosicao;
    public Transform TorrePosicao;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void retirarEstruturasAtuais()
    {
        Destroy(atualCabana);
        Destroy(atualCentro);
        Destroy(atualPoste);
        Destroy(atualTorre);
    }

    public void colocarObjetosAtuaisEmPosicao()
    {
        atualCabana.transform.position = cabanaPosicao.transform.position;
        atualCentro.transform.position = centroPosicao.transform.position;
        if(atualPoste != null)
        {
            atualPoste.transform.position = postePosicao.transform.position;
            atualTorre.transform.position = TorrePosicao.transform.position;
        }
        
    }

    public void clonesEstruturaEmPosicao()
    {
        retirarEstruturasAtuais();
        atualCentro = Instantiate(naveClone) as GameObject;
        atualCabana = Instantiate(cabanaClone) as GameObject;
        colocarObjetosAtuaisEmPosicao();
    }

    public void roxoColocarEstruturasEmPosicao()
    {
        retirarEstruturasAtuais();
        atualCabana = Instantiate(roxoCabana) as GameObject;
        atualCentro = Instantiate(roxoCentro) as GameObject;
        atualPoste = Instantiate(roxoPoste) as GameObject;
        atualTorre = Instantiate(roxoTorre) as GameObject;
        colocarObjetosAtuaisEmPosicao();
    }

    public void vermelhoColocarEstruturasEmPosicao()
    {
        retirarEstruturasAtuais();
        atualCabana = Instantiate(vermelhoCabana) as GameObject;
        atualCentro = Instantiate(vermelhoCentro) as GameObject;
        atualPoste = Instantiate(vermelhoPoste) as GameObject;
        atualTorre = Instantiate(vermelhoTorre) as GameObject;
        colocarObjetosAtuaisEmPosicao();
    }

    public void verdeColocarEstruturasEmPosicao()
    {
        retirarEstruturasAtuais();
        atualCabana = Instantiate(verdeCabana) as GameObject;
        atualCentro = Instantiate(verdeCentro) as GameObject;
        atualPoste = Instantiate(verdePoste) as GameObject;
        atualTorre = Instantiate(verdeTorre) as GameObject;
        colocarObjetosAtuaisEmPosicao();
    }

    public void laranjaColocarEstruturasEmPosicao()
    {
        retirarEstruturasAtuais();
        atualCabana = Instantiate(laranjaCabana) as GameObject;
        atualCentro = Instantiate(laranjaCentro) as GameObject;
        atualPoste = Instantiate(laranjaPoste) as GameObject;
        atualTorre = Instantiate(laranjaTorre) as GameObject;
        colocarObjetosAtuaisEmPosicao();
    }

    public void azulColocarEstruturasEmPosicao()
    {
        retirarEstruturasAtuais();
        atualCabana = Instantiate(azulCabana) as GameObject;
        atualCentro = Instantiate(azulCentro) as GameObject;
        atualPoste = Instantiate(azulPoste) as GameObject;
        atualTorre = Instantiate(azulTorre) as GameObject;
        colocarObjetosAtuaisEmPosicao();
    }
}
