using UnityEngine;
using System.Collections;

public class ScriptAjustancoCamera : MonoBehaviour {
    public Camera camera;
    public Transform mainCameraPosition;
    public Transform armazemCameraPosition;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void moveCameraArmazem()
    {
        camera.transform.position = armazemCameraPosition.position;
    }

    public void moveCameraMainPosition()
    {
        camera.transform.position = mainCameraPosition.position;
    }
}
