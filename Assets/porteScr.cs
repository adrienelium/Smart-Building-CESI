using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class porteScr : MonoBehaviour {
    // Use this for initialization
    public GameObject hand;
    public GameObject parent;
    public float openningAngle = 90;

    private bool inTrigger = false;

    private bool doorOpen = false;
	
    void Start()
    {

    }

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1") && inTrigger)
        {
            //Debug.LogWarning("Ouverture porte");
            doorOpen = !doorOpen;

            if (doorOpen)
            {
                this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("ouvrir");
                this.GetComponent<AudioSource>().Play();
            }
            else
            {
                this.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("fermer");
                this.GetComponent<AudioSource>().PlayDelayed(1);
            }

        }

        if (doorOpen)
        {
            parent.transform.localRotation = Quaternion.Slerp(parent.transform.localRotation, Quaternion.Euler(0, openningAngle, 0), Time.deltaTime * 2f);

            
        }

        if (!doorOpen)
        {
            parent.transform.localRotation = Quaternion.Slerp(parent.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 2f);
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Shadow")
        {
            this.inTrigger = true;
            hand.SetActive(true);
        }
        


    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag != "Shadow")
        {
            this.inTrigger = false;
            hand.SetActive(false);
        }
            
    }
}
