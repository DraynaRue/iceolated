using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

    public GameObject forwardM;
    public GameObject backwardsM;
    public GameObject leftM;
    public GameObject rightM;
    public GameObject upM;
    public GameObject downM;
	public GameObject tutUI;

	void update()
    {
			
            if(Input.GetKeyDown(KeyCode.W))
            {
				Debug.Log ("test");
                forwardM.SetActive(false);
                backwardsM.SetActive(true);
                leftM.SetActive(false);
                rightM.SetActive(false);
                upM.SetActive(false);
                downM.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                forwardM.SetActive(false);
                backwardsM.SetActive(false);
                leftM.SetActive(true);
                rightM.SetActive(false);
                upM.SetActive(false);
                downM.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                forwardM.SetActive(false);
                backwardsM.SetActive(false);
                leftM.SetActive(false);
                rightM.SetActive(true);
                upM.SetActive(false);
                downM.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                forwardM.SetActive(false);
                backwardsM.SetActive(true);
                leftM.SetActive(false);
                rightM.SetActive(false);
                upM.SetActive(true);
                downM.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                forwardM.SetActive(false);
                backwardsM.SetActive(true);
                leftM.SetActive(false);
                rightM.SetActive(false);
                upM.SetActive(false);
                downM.SetActive(true);
            }
            if (Input.GetKeyDown(KeyCode.LeftControl))
            {
				tutUI.SetActive (false); 
            }

        }
}
