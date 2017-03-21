using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject carPrefab;
    public GameObject coinPrefab;
    public GameObject conePrefab;
    private GameObject unitychan;

    private GameObject car;
    private GameObject coin;
    private GameObject cone;



    private int startPos = -160;   //スタート地点
    private int goalPos = 120;     //ゴール地点

    private float posRange = 3.4f; //アイテムを出す左右の範囲


	// Use this for initialization
	void Start () {

        this.unitychan = GameObject.Find("unitychan");
        
        //一定の距離ごとにアイテムを生成
        for(int i = startPos; i < goalPos; i += 15)
        {
            //アイテムの種類を選択
            int num = Random.Range(0, 10);

            //コーンを横一列に配置
            if(num <= 1)
            {
                for(float j = -1; j <= 1; j += 0.4f)
                {
                    cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i); 
                }
            }
            else
            {
                //レーンごとにアイテムの種類を決める
                for(int j = -1; j <2; j++)
                {
                    int item = Random.Range(1, 11);     //アイテムの種類
                    int offsetZ = Random.Range(-5, 6);  //アイテムを置くZ座標を前後にずらす

                    //コイン 60%,  車 30%,  何もなし 10%
                    if (1 <= item && item<= 6)
                    {
                        //コインを生成
                        coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    else if(7 <= item && 9 <= item)
                    {
                        //車を生成
                        car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    
    

}
