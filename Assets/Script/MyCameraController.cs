using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {

    private GameObject unitychan;
    private float difference;
    
    // Use this for initialization
	void Start () {

        this.unitychan = GameObject.Find("unitychan");

        //Unityちゃんの初期位置 - カメラの初期位置
        this.difference = unitychan.transform.position.z - this.transform.position.z;

		
	}
	
	// Update is called once per frame
	void Update () {

        //カメラの位置を変更
        this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);

	}
}
