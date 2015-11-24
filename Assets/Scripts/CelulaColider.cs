using UnityEngine;
using System.Collections;

public class CelulaColider : MonoBehaviour {
    public Touch touch;
    public Ray ray;
    public bool apertarBotao;
    public int cont;

    // Use this for initialization
    void Start () {
        cont = 300;
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

        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //ray.origin = new Vector3(ray.origin.x,ray.origin.y,95.67f);
           
            //Physics.Raycast(ray, out hit, 10)
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if(hit.collider.gameObject.GetComponent<CelulaColider>()!=null)
                {
                    hit.collider.gameObject.GetComponent<CelulaColider>().ChamarBotao();
                }
                
            }
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
