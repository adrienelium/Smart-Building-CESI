using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorneWifiAgent : MonoBehaviour {

    public bool fiestaEnOpenSpace = false;
    public int timeSecondsSwitchOffTubeALed = 5;

    public float lightIntensitySun = 0.4F;
    public float lightIntensityDark = 0.8F;

    public TubeALedAgent[] tubesTAXa;
    public TubeALedAgent[] tubesTAXb;
    public TubeALedAgent[] tubesTAXc;
    public TubeALedAgent[] tubesTA1X;
    public TubeALedAgent[] tubesTA2X;

    public TubeALedAgent[] tubesTBX;
    public TubeALedAgent[] tubesTBXa;
    public TubeALedAgent[] tubesTBXXa;
    public TubeALedAgent[] tubesTBXXb;

    public UnityEngine.UI.Text alertText; 

    private DateTime TimeTubesTAXa = new DateTime();
    private DateTime TimeTubesTAXb = new DateTime();
    private DateTime TimeTubesTAXc = new DateTime();
    private DateTime TimeTubesTA1X = new DateTime();
    private DateTime TimeTubesTA2X = new DateTime();

    private DateTime TimeTubesTBX = new DateTime();
    private DateTime TimeTubesTBXa = new DateTime();
    private DateTime TimeTubesTBXXa = new DateTime();
    private DateTime TimeTubesTBXXb = new DateTime();

    private TimeSpan diff;
    private DateTime tActuel;

    private float nextActionTime = 0.0f;
    public float period = 1.0f;

    // Use this for initialization
    void Start () {
        SetLightIntensityTubesTA1X(lightIntensityDark,lightIntensitySun);
        SetLightIntensityTubesTAXa(lightIntensityDark, lightIntensitySun);
    }
	
	// Update is called once per frame
	void Update () {

        tActuel = DateTime.Now;
        diff = tActuel.Subtract(TimeTubesTA2X);
        if (diff.Seconds >= timeSecondsSwitchOffTubeALed)
        {
            EteindreTubesTA2X();
        }

        if (!fiestaEnOpenSpace)
        {
            tActuel = DateTime.Now;
            diff = tActuel.Subtract(TimeTubesTA1X);
            if (diff.Seconds >= timeSecondsSwitchOffTubeALed)
            {
                EteindreTubesTA1X();
            }
        }
        
        tActuel = DateTime.Now;
        diff = tActuel.Subtract(TimeTubesTAXa);
        if (diff.Seconds >= timeSecondsSwitchOffTubeALed)
        {
            EteindreTubesTAXa();
        }
        
        tActuel = DateTime.Now;
        diff = tActuel.Subtract(TimeTubesTAXb);
        if (diff.Seconds >= timeSecondsSwitchOffTubeALed)
        {
            EteindreTubesTAXb();
            
        }
        
        tActuel = DateTime.Now;
        diff = tActuel.Subtract(TimeTubesTAXc);
        if (diff.Seconds >= timeSecondsSwitchOffTubeALed)
        {
            EteindreTubesTAXc();
        }



        tActuel = DateTime.Now;
        diff = tActuel.Subtract(TimeTubesTBX);
        if (diff.Seconds >= timeSecondsSwitchOffTubeALed)
        {
            EteindreTubesTBX();
        }

        tActuel = DateTime.Now;
        diff = tActuel.Subtract(TimeTubesTBXa);
        if (diff.Seconds >= timeSecondsSwitchOffTubeALed)
        {
            EteindreTubesTBXa();
        }

        tActuel = DateTime.Now;
        diff = tActuel.Subtract(TimeTubesTBXXa);
        if (diff.Seconds >= timeSecondsSwitchOffTubeALed)
        {
            EteindreTubesTBXXa();
        }

        tActuel = DateTime.Now;
        diff = tActuel.Subtract(TimeTubesTBXXb);
        if (diff.Seconds >= timeSecondsSwitchOffTubeALed)
        {
            EteindreTubesTBXXb();

        }

        if (fiestaEnOpenSpace)
        {
            AllumerTubesTA1X();
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;
                foreach (TubeALedAgent tube in tubesTA1X)
                {
                    tube.light.color = getRandomColor();
                }
            }

            
        }
        else
        {
            foreach (TubeALedAgent tube in tubesTA1X)
            {
                tube.light.color = Color.white;
            }
        }

    }

    public Color getRandomColor()
    {
        Color[] tabcolor = { Color.blue, Color.cyan, Color.green, Color.magenta, Color.red, Color.yellow };
        //System.Random index = new System.Random();
        UnityEngine.Random index = new UnityEngine.Random();
        int res = 0;
        Debug.Log(res);
        //return UnityEngine.Random.ColorHSV(1,1);
        return tabcolor[UnityEngine.Random.Range(0,5)];
    }

    public void PlayerIn(string name)
    {
        switch (name) {
            case "TA2X":
                TimeTubesTA2X = DateTime.Now;
                AllumerTubesTA2X();
                break;
            case "TA1X":
                TimeTubesTA1X = DateTime.Now;
                if (!fiestaEnOpenSpace)
                {
                    AllumerTubesTA1X();
                }
                break;
            case "TAXa":
                TimeTubesTAXa = DateTime.Now;
                AllumerTubesTAXa();
                break;
            case "TAXb":
                TimeTubesTAXb = DateTime.Now;
                AllumerTubesTAXb();
                break;
            case "TAXc":
                TimeTubesTAXc = DateTime.Now;
                AllumerTubesTAXc();
                break;

            case "TBX":
                TimeTubesTBX = DateTime.Now;
                AllumerTubesTBX();
                break;
            case "TBXa":
                TimeTubesTBXa = DateTime.Now;
                AllumerTubesTBXa();
                break;
            case "TBXXa":
                TimeTubesTBXXa = DateTime.Now;
                AllumerTubesTBXXa();
                break;
            case "TBXXb":
                TimeTubesTBXXb = DateTime.Now;
                AllumerTubesTBXXb();
                break;
        }
    }

    public void AlertManuelMode(string nameRoom)
    {
        alertText.text = "Une lampe de la salle [" + nameRoom + "] est passée en mode manuelle";
    }

    public void AllumerTubesTA2X()
    {
        foreach (TubeALedAgent tube in tubesTA2X)
        {
            tube.SwitchOnLight();
        }
    }

    public void EteindreTubesTA2X()
    {

        foreach (TubeALedAgent tube in tubesTA2X)
        {
            tube.SwitchOffLight();
        }
    }

    public void SetLightIntensityTubesTA2X(float darkI, float sunI)
    {
        foreach (TubeALedAgent tube in tubesTA2X)
        {
            tube.LightIntensityDark = darkI;
            tube.LightIntensitySun = sunI;
        }
    }

    public void AllumerTubesTA1X()
    {
        foreach (TubeALedAgent tube in tubesTA1X)
        {
            tube.SwitchOnLight();
        }
    }

    public void EteindreTubesTA1X()
    {

        foreach (TubeALedAgent tube in tubesTA1X)
        {
            tube.SwitchOffLight();
        }
    }

    public void SetLightIntensityTubesTA1X(float darkI, float sunI)
    {
        foreach (TubeALedAgent tube in tubesTA1X)
        {
            tube.LightIntensityDark = darkI;
            tube.LightIntensitySun = sunI;
        }
    }


    public void AllumerTubesTAXa()
    {
        //Debug.Log("Allumer TAXa");
        foreach (TubeALedAgent tube in tubesTAXa)
        {
            tube.SwitchOnLight();
        }
    }

    public void EteindreTubesTAXa()
    {
        //Debug.Log("Eteindre TAXa");
        foreach (TubeALedAgent tube in tubesTAXa)
        {
            tube.SwitchOffLight();
        }
    }

    public void SetLightIntensityTubesTAXa(float darkI, float sunI)
    {
        foreach (TubeALedAgent tube in tubesTAXa)
        {
            tube.LightIntensityDark = darkI;
            tube.LightIntensitySun = sunI;
        }
    }
    
    public void AllumerTubesTAXb()
    {
        foreach (TubeALedAgent tube in tubesTAXb)
        {
            tube.SwitchOnLight();
        }
    }

    public void EteindreTubesTAXb()
    {
        
        foreach (TubeALedAgent tube in tubesTAXb)
        {
            tube.SwitchOffLight();
        }
    }

    public void SetLightIntensityTubesTAXb(float darkI, float sunI)
    {
        foreach (TubeALedAgent tube in tubesTAXb)
        {
            tube.LightIntensityDark = darkI;
            tube.LightIntensitySun = sunI;
        }
    }
    
    public void AllumerTubesTAXc()
    {
        foreach (TubeALedAgent tube in tubesTAXc)
        {
            tube.SwitchOnLight();
        }
    }

    public void EteindreTubesTAXc()
    {
        foreach (TubeALedAgent tube in tubesTAXc)
        {
            tube.SwitchOffLight();
        }
    }

    public void SetLightIntensityTubesTAXc(float darkI, float sunI)
    {
        foreach (TubeALedAgent tube in tubesTAXc)
        {
            tube.LightIntensityDark = darkI;
            tube.LightIntensitySun = sunI;
        }
    }

    // GROUPE B *************************************************************

    public void AllumerTubesTBX()
    {
        //Debug.Log("allumer tbx");
        foreach (TubeALedAgent tube in tubesTBX)
        {
            tube.SwitchOnLight();
        }
    }

    public void EteindreTubesTBX()
    {
        //Debug.Log("eteindre tbx");
        foreach (TubeALedAgent tube in tubesTBX)
        {
            tube.SwitchOffLight();
        }
    }

    public void SetLightIntensityTubesTBX(float darkI, float sunI)
    {
        foreach (TubeALedAgent tube in tubesTBX)
        {
            tube.LightIntensityDark = darkI;
            tube.LightIntensitySun = sunI;
        }
    }

    public void AllumerTubesTBXa()
    {
        foreach (TubeALedAgent tube in tubesTBXa)
        {
            tube.SwitchOnLight();
        }
    }

    public void EteindreTubesTBXa()
    {
        foreach (TubeALedAgent tube in tubesTBXa)
        {
            tube.SwitchOffLight();
        }
    }

    public void SetLightIntensityTubesTBXa(float darkI, float sunI)
    {
        foreach (TubeALedAgent tube in tubesTBXa)
        {
            tube.LightIntensityDark = darkI;
            tube.LightIntensitySun = sunI;
        }
    }

    public void AllumerTubesTBXXa()
    {
        foreach (TubeALedAgent tube in tubesTBXXa)
        {
            tube.SwitchOnLight();
        }
    }

    public void EteindreTubesTBXXa()
    {
        foreach (TubeALedAgent tube in tubesTBXXa)
        {
            tube.SwitchOffLight();
        }
    }

    public void SetLightIntensityTubesTBXXa(float darkI, float sunI)
    {
        foreach (TubeALedAgent tube in tubesTBXXa)
        {
            tube.LightIntensityDark = darkI;
            tube.LightIntensitySun = sunI;
        }
    }

    public void AllumerTubesTBXXb()
    {
        foreach (TubeALedAgent tube in tubesTBXXb)
        {
            tube.SwitchOnLight();
        }
    }

    public void EteindreTubesTBXXb()
    {
        foreach (TubeALedAgent tube in tubesTBXXb)
        {
            tube.SwitchOffLight();
        }
    }

    public void SetLightIntensityTubesTBXXb(float darkI, float sunI)
    {
        foreach (TubeALedAgent tube in tubesTBXXb)
        {
            tube.LightIntensityDark = darkI;
            tube.LightIntensitySun = sunI;
        }
    }

}
