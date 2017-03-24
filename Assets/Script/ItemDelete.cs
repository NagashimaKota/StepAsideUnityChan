using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDelete : MonoBehaviour {

    private GameObject unitychan;
    private float difference;

    // Use this for initialization
	void Start () {

        unitychan = GameObject.Find("unitychan");
        this.difference = unitychan.transform.position.z - this.transform.position.z;

	}
	
	// Update is called once per frame
	void Update () {

        //unitychanとの差をとる
        this.transform.position = new Vector3(0, this.transform.position.y, unitychan.transform.position.z - difference);
        
    }

    void OnTriggerEnter(Collider ther)
    {
        
        //トリガーオブジェクトがぶつかった時、クルマ、コーン、コインなら削除する
        if (ther.tag == "CarTag" || ther.tag == "TrafficConeTag" || ther.tag == "CoinTag")
        {
            Destroy(ther.gameObject);
        }
        
    }
}
