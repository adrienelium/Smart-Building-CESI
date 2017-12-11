using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeALedAgent : MonoBehaviour {

    public Light light;
    public BorneWifiAgent borne;
    public bool AutoMode = true;

    public GameObject led;

    public Material MatEteint;
    public Material MatAllumer;
    public MeshRenderer glass;

    public float lightIntensitySun = 0.2F;
    public float lightIntensityDark = 0.8F;
    private bool isDark = false;

    private bool isPlayerHere;

    public void SetAutoModeTrue()
    {
        AutoMode = true;
        
    }

    public void SetAutoModeFalse()
    {
        AutoMode = false;
        borne.AlertManuelMode(GetComponentInParent<LightGroup>().name);
    }

    public float LightIntensitySun
    {
        get
        {
            return lightIntensitySun;
        }

        set
        {
            lightIntensitySun = value;
        }
    }

    public float LightIntensityDark
    {
        get
        {
            return lightIntensityDark;
        }

        set
        {
            lightIntensityDark = value;
        }
    }


    // Use this for initialization
    void Start () {
        light.enabled = false;
        isPlayerHere = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Statut : " + isDark);
        if (isDark)
        {
            light.intensity = lightIntensityDark;
        }
        else
        {
            light.intensity = lightIntensitySun;
        }

        if (AutoMode)
        {
            led.SetActive(false);
        }
        else
        {
            led.SetActive(true);
        }

        if (light.enabled)
        {
            glass.material = MatAllumer;
        }
        else
        {
            glass.material = MatEteint;
        }
	}

    bool isShadow(string name)
    {
        return name == "Shadow";
    }

    void OnTriggerEnter(Collider other)
    {
        isDark = isShadow(other.tag);
        
    }

    void OnTriggerExit(Collider other)
    {
        if (isShadow(other.tag))
        {
            isDark = !isDark;
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player")
        {
            isPlayerHere = true;
            borne.PlayerIn(GetComponentInParent<LightGroup>().name);
        }

        
    }

    

    public void SwitchOnLight()
    {
        if (AutoMode)
        {
            EnableLight();
        }
    }

    public void SwitchOffLight()
    {
        if (AutoMode)
        {
            DisableLight();
        }
    }

    public void EnableLight()
    {
        light.enabled = true;
    }

    public void DisableLight()
    {
        light.enabled = false;
    }

    public bool isEnable()
    {
        return light.enabled;
    }
}
