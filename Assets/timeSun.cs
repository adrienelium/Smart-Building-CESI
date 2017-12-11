using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeSun : MonoBehaviour {

    public GameObject sun;
    public Text text;
    public float acceleration = 2;
    private float timedaySeconds = 15;

    public int degMaxLight = 30;
    private float offsethour = 8;

    private bool premierArc = true;
    private float anglePrecedent = 0;
    private float varspe = 24;
    private float nextActionTime = 0.0f;
    public float period = 5000f;
    int i = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float timespe = timedaySeconds * acceleration;
        float varspe2 = varspe / acceleration;

        Vector3 t = new Vector3(1, 0, 0);
        //float timespe = 30 * timedaySeconds/ 12;
        sun.transform.Rotate(t, timespe * Time.deltaTime);


        

        if (sun.transform.rotation.eulerAngles.x <= degMaxLight && sun.transform.rotation.eulerAngles.x > 0)
        {
            float res = sun.transform.rotation.eulerAngles.x / degMaxLight;
            sun.GetComponent<Light>().intensity = res;
        }
        else if (sun.transform.rotation.eulerAngles.x > degMaxLight && sun.transform.rotation.eulerAngles.x <= 180)
        {
            float res = 1 - sun.transform.rotation.eulerAngles.x / 180;
            sun.GetComponent<Light>().intensity = res;
        }
        else
        {
            sun.GetComponent<Light>().intensity = 0;

            
        }

        if (Time.time > nextActionTime)
        {
            
            nextActionTime += period;
            // execute block of code here
            //Debug.Log("Seconds : " + i);

            float totalMinutes = (i% varspe2) * 1440 / varspe2;
            //Debug.Log(totalMinutes/60);
            float resHeure = totalMinutes / 60;
            string txt = "";
            if (resHeure < 10)
            {
                txt = "0" + resHeure + " H";
            }
            else
            {
                txt = resHeure + " H";
            }
            
            text.text = txt;

            i++;
        }

        //float heures = (offsethour + angleActuel / 15) % 24;
        //float minutes = ((offsethour + angleActuel / 15) / 24 - heures) * 60;


    }




}
