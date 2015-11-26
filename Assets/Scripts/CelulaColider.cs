using UnityEngine;
using System.Collections;

public class CelulaColider : MonoBehaviour {
    public Touch touch;
    public Ray ray;
    public bool apertarBotao;
    public int cont;
    private GameManager gameManager;

    // Use this for initialization
    void Start () {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        cont = 0;
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Input.touches.Length; i++)
        {
            touch = Input.touches[i];
            ray = Camera.main.ScreenPointToRay(Input.touches[i].position);
            Vector3 aux = ray.origin;
            aux.z = 0;
            ray.origin = aux;
            RaycastHit hit = new RaycastHit();
            /*
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.tag == "atk")
                {

                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            GameObject.Find("Player").GetComponent("Player").SendMessage("atk");
                            break;

                        case TouchPhase.Ended:
                            break;
                    }
                }
            }*/

        }
        DetectarIntencaoBotaoEsquerdo();
        
    }

    public void DetectarIntencaoBotaoEsquerdo()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray.origin = new Vector3(ray.origin.x,ray.origin.y,95.67f);

            //Physics.Raycast(ray, out hit, 10)
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000))
            {
                intencao(hit);
                {

                }
                if (hit.collider.gameObject.GetComponent<CelulaColider>() != null)
                {
                    //hit.collider.gameObject.GetComponent<CelulaColider>().ChamarBotao();
                }

            }
        }
    }

    public void intencao(RaycastHit hit)
    {
        if (cont > 20)
        {
            cont = 0;
            if (gameManager.acaoAtual == "COLOCAR")
            {
                hit.collider.gameObject.GetComponent<Recurso>().colocar(gameManager.recursoAtual);
            }
            else if (gameManager.acaoAtual == "UPGRADE")
            {
                hit.collider.gameObject.GetComponent<Recurso>().upgrade();
            }
            else if (gameManager.acaoAtual == "REMOVER")
            {

            }
        }
        else
        {
            cont++;
        }
        
    }



    public void ChamarBotao()
    {
        if (cont>900)
        {
            cont = 0;
            GameObject.FindObjectOfType<MenuControler>().AcinonarMenuOpcoesRecurso(this.gameObject);
        } else
        {
            cont++;
        }
        
    }
}
