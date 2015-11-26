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
        float cont3 = -0.1f;
        GameObject losango = GameObject.Instantiate(LosangoBase) as GameObject;
        losango.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
                                                this.transform.position.z);
        losangoCelulaBase = losango.GetComponent<Celula>();
        float disposicaoCelularVertical = (mapLargura()/ losangoCelulaBase.GetLargura());
        float disposicaoCelularHorizontal =  (mapAltura() /  losangoCelulaBase.GetAltura());
        Destroy(losango.gameObject);
            
        for (cont2 = 2; cont2 <= 2 * disposicaoCelularHorizontal; cont2 = cont2 + 2)
        {

            for (cont = 2; cont <= 2*disposicaoCelularVertical; cont = cont + 2)
            {
                
                losango = GameObject.Instantiate(LosangoBase) as GameObject;
                losango.transform.position = new Vector3(-mapLargura() + (cont * losango.GetComponent<Celula>().GetLargura()),
                                                        (mapAltura() - (cont2 * losango.GetComponent<Celula>().GetAltura())) + losango.GetComponent<Celula>().GetAltura(),
                                                        this.transform.position.z+cont3);
                celulasLosango.Add(losango);
            }
            losango = GameObject.Instantiate(LosangoBase) as GameObject;
            losango.transform.position = new Vector3(-mapLargura(),
                                                    (mapAltura() - (cont2 * losango.GetComponent<Celula>().GetAltura()) + losango.GetComponent<Celula>().GetAltura()),
                                                    this.transform.position.z+cont3);
            celulasLosango.Add(losango);
            cont3 = cont3 - 0.2f;
        }
    }

    private void GerarGradienteLosangoInterno()
    {
        int cont = 0;
        int cont2 = 0;
        float cont3 = -0.2f;
        GameObject losango = GameObject.Instantiate(LosangoBase) as GameObject;
        losango.transform.position = new Vector3(this.transform.position.x, this.transform.position.y,
                                                this.transform.position.z);
        losangoCelulaBase = losango.GetComponent<Celula>();
        float disposicaoCelularVertical = (mapLargura()-losangoCelulaBase.GetLargura()) / losangoCelulaBase.GetLargura();
        float disposicaoCelularHorizontal = (mapAltura() - losangoCelulaBase.GetAltura()) / losangoCelulaBase.GetAltura();
        Destroy(losango.gameObject);

        for (cont2 = 2; cont2 <= 2 * disposicaoCelularHorizontal; cont2 = cont2 + 2)
        {

            for (cont = 2; cont <= 2 * disposicaoCelularVertical; cont = cont + 2)
            {
                losango = GameObject.Instantiate(LosangoBase) as GameObject;
                losango.transform.position = new Vector3((-mapLargura() + losangoCelulaBase.GetLargura()) + (cont * losangoCelulaBase.GetLargura()),
                                                        (mapAltura() - cont2 * losangoCelulaBase.GetAltura()),
                                                        this.transform.position.z+cont3);
                celulasLosango.Add(losango);
            }
            losango = GameObject.Instantiate(LosangoBase) as GameObject;
            losango.transform.position = new Vector3((-mapLargura() + losangoCelulaBase.GetLargura()),
                                                    (mapAltura() - (cont2 * losangoCelulaBase.GetAltura())),
                                                      this.transform.position.z+cont3);
            celulasLosango.Add(losango);
            cont3 = cont3 - 0.2f;
        }
    }

    public float mapLargura()
    {
        return largura.transform.position.x - this.transform.position.x;
    }

    public float mapAltura()
    {
        return altura.transform.position.y - this.transform.position.y;
    }
}
