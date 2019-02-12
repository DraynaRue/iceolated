using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitPoint : MonoBehaviour {

    Rigidbody rb;
    public GameObject target;
    float alphaa;
    Text _this;

    void Start(){
        _this = this.GetComponent<Text>();
        _this.fontSize = 18;
        rb = this.gameObject.GetComponent<Rigidbody>();
        alphaa = 255f;
        target = GameObject.Find("_Player");
    }

    void Update(){
        Vector3 targetDir = target.transform.position - transform.position;

		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, 4f, 0f);
		
		transform.rotation = Quaternion.LookRotation(newDir);
        float frc = Random.Range(-2f, 2f);
        rb.AddForce(frc, frc, frc, ForceMode.Impulse);
        alphaa -= 1000f * Time.deltaTime;
        _this.color = new Color(255f, 0f, 0f, alphaa);

        float _timer = 1;
        _timer -= 0.5f * Time.deltaTime;

        if(_timer <= 0f){
            Destroy(this.gameObject);
        }
    }

}
