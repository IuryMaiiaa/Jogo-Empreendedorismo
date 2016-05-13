using UnityEngine;
using System.Collections;

public class PosicaoClickControler : MonoBehaviour {
    public Touch touch;
    public Ray ray;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*
       for (int i = 0; i < Input.touches.Length; i++)
       {
           touch = Input.touches[i];
           ray = Camera.main.ScreenPointToRay(Input.touches[i].position);
           Vector3 aux = ray.origin;
           aux.z = 0;
           ray.origin = aux;
           RaycastHit hit = new RaycastHit();

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
           }

       }
    */
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (hit.collider.gameObject.GetComponent<CelulaColider>() != null)
                {
                    hit.collider.gameObject.GetComponent<CelulaColider>().intencao(hit);
                } else if (hit.collider.gameObject.GetComponent<NaveScriptChamarBotao>() != null)
                {
                    hit.collider.gameObject.GetComponent<NaveScriptChamarBotao>().chamarMenuOpcoesNave();
                } else if (hit.collider.gameObject.GetComponent<ClonesFala>() != null)
                {
                    hit.collider.gameObject.GetComponent<ClonesFala>().chamarFalaNpc();
                } else if(hit.collider.gameObject.GetComponent<AlienNacaoCentroBotao>() != null)
                {
                    hit.collider.gameObject.GetComponent<AlienNacaoCentroBotao>().chamarMenuCentroAlien();
                }

            }
        }
    }

}
