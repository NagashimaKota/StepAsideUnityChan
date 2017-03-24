using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator2 : MonoBehaviour {

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private GameObject unitychan;

    private GameObject car;
    private GameObject coin;
    private GameObject cone;


    private int startPos = -160;
    private int goalPos = 120;

    private float posRange = 3.4f;
     

	// Use this for initialization
	void Start () {

        this.unitychan = GameObject.Find("unitychan");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
