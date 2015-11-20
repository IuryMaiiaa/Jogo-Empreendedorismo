using UnityEngine;
using System.Collections;

public class Mapa : MonoBehaviour {
	public SpriteRenderer imagemMapa;
    public Transform largura;
    public Transform altura;
    public ArrayList celulasLosango;
    public GameObject LosangoBase;
    public Celula losangoCelulaBase;

	// Use this for initialization  
	void Start () {
        celulasLosango = new ArrayList();
        GerarGradienteLosango();
        GerarGradienteLosangoInterno();

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void GerarGradienteLosango() {
        int cont = 0;
        int cont2 = 0;
        GameObject losango = GameObject.Instantiate(LosangoBase) as GameObject;
        losango.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
                                                this.transform.position.z);
        losangoCelulaBase = losango.GetComponent<Celula>();
        float disposicaoCelularVertical = (2 * largura.position.x) / (2 * losangoCelulaBase.largura.transform.position.x);
        float disposicaoCelularHorizontal = (2 * altura.position.y) / (2 * losangoCelulaBase.altura.transform.position.y);
        Destroy(losango.gameObject);
            
        for (cont2 = 2; cont2 <= 2 * disposicaoCelularHorizontal; cont2 = cont2 + 2)
        {

            for (cont = 2; cont <= 2 * disposicaoCelularVertical; cont = cont + 2)
            {
                losango = GameObject.Instantiate(LosangoBase) as GameObject;
                losango.transform.position = new Vector3(-largura.position.x + (cont * losango.GetComponent<Celula>().GetLargura()) + losango.GetComponent<Celula>().GetLargura(),
                                                        (altura.position.y - cont2 * losango.GetComponent<Celula>().GetAltura()) + losango.GetComponent<Celula>().GetAltura(),
                                                        this.transform.position.z);
                celulasLosango.Add(losango);
            }
            losango = GameObject.Instantiate(LosangoBase) as GameObject;
            losango.transform.position = new Vector3(-largura.position.x + losango.GetComponent<Celula>().GetLargura(),
                                                        (altura.position.y - (cont2 * losango.GetComponent<Celula>().GetAltura()) + losango.GetComponent<Celula>().GetAltura()),
                                                        this.transform.position.z);
            celulasLosango.Add(losango);
        }
    }

    private void GerarGradienteLosangoInterno()
    {
        int cont = 0;
        int cont2 = 0;
        GameObject losango = GameObject.Instantiate(LosangoBase) as GameObject;
        losango.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
                                                this.transform.position.z);
        losangoCelulaBase = losango.GetComponent<Celula>();
        float disposicaoCelularVertical = ((2 * largura.position.x)- losangoCelulaBase.largura.transform.position.x) / (2 * losangoCelulaBase.largura.transform.position.x);
        float disposicaoCelularHorizontal = ((2 * altura.position.y)- losangoCelulaBase.altura.transform.position.y) / (2 * losangoCelulaBase.altura.transform.position.y);
        Destroy(losango.gameObject);

        for (cont2 = 2; cont2 <= 2 * disposicaoCelularHorizontal; cont2 = cont2 + 2)
        {

            for (cont = 2; cont <= 2 * disposicaoCelularVertical; cont = cont + 2)
            {
                losango = GameObject.Instantiate(LosangoBase) as GameObject;
                losango.transform.position = new Vector3((-largura.position.x+ losango.GetComponent<Celula>().GetLargura()) + (cont * losango.GetComponent<Celula>().GetLargura()) + losango.GetComponent<Celula>().GetLargura(),
                                                        ((altura.position.y- losango.GetComponent<Celula>().GetAltura()) - cont2 * losango.GetComponent<Celula>().GetAltura()) + losango.GetComponent<Celula>().GetAltura(),
                                                        this.transform.position.z);
                celulasLosango.Add(losango);
            }
            losango = GameObject.Instantiate(LosangoBase) as GameObject;
            losango.transform.position = new Vector3((-largura.position.x + losango.GetComponent<Celula>().GetLargura()) + losango.GetComponent<Celula>().GetLargura(),
                                                    ((altura.position.y - losango.GetComponent<Celula>().GetAltura()) - (cont2 * losango.GetComponent<Celula>().GetAltura()) + losango.GetComponent<Celula>().GetAltura()),
                                                      this.transform.position.z);
            celulasLosango.Add(losango);
        }
    }
}
