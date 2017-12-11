using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonePlayer : MonoBehaviour {
    public Camera cameraT;
    Ray ray;
    RaycastHit hit;
    public BorneWifiAgent borneA;
    public UnityEngine.UI.Text alertText;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ray = cameraT.ScreenPointToRay(Input.mousePosition);
        bool fire1 = Input.GetButtonDown("Fire1");
        bool fire2 = Input.GetButtonDown("Fire2");
        if (fire1 || fire2)
        {
            //print("tirer : " + Physics.Raycast(ray, out hit));
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.gameObject.tag == "Tubeled") {
                    //Debug.Log("Tube led : " + hit.collider.gameObject.name);
                    TubeALedAgent tube = hit.collider.GetComponentInParent<TubeALedAgent>();

                    if (fire1)
                    {
                        if (tube.AutoMode)
                        {
                            tube.SetAutoModeFalse();
                            tube.DisableLight();
                            tube.GetComponent<AudioSource>().Play();
                        }
                        else
                        {
                            tube.SetAutoModeTrue();
                            tube.GetComponent<AudioSource>().Play();
                        }
                    }

                    if (fire2)
                    {
                        if (tube.isEnable())
                        {
                            tube.DisableLight();
                        }
                        else
                        {
                            tube.EnableLight();
                        }
                    }
                    
                }
                
            }

        }

        if (Input.GetButtonDown("Activer Fiesta"))
        {
            borneA.fiestaEnOpenSpace = !borneA.fiestaEnOpenSpace;
        }

        if (Input.GetButtonDown("Submit"))
        {
            alertText.text = "";
        }
    }
}
