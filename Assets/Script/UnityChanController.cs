using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {

    
    private Animator myAnimator;         //アニメーションを制御する入れ物
    private Rigidbody myRigidbody;       //動きを制御する入れ物

    private float forwadForce = 800.0f; //前進するときの速さ
    private float turnForce = 500.0f;   //左右移動のときの速さ
    private float upForce = 500.0f;     //ジャンプのときの高さ
    private float movableRange = 3.4f;  //左右の移動制限
    private float coefficient = 0.95f;   //動きを減速させる係数（95%）

    private bool isEnd = false;         //ゲームの終了判定
    private GameObject stateText;
    private GameObject scoreText;
    private int score = 0;

    private bool isLButtonDown = false;
    private bool isRButtonDown = false;

	// Use this for initialization
	void Start () {

        this.myAnimator = GetComponent<Animator>();
        this.myRigidbody = GetComponent<Rigidbody>();


        //アニメーションを条件のSpeedに1を代入
        //AnimatorでSpeedが0.8以上になると走るアニメーションになる
        this.myAnimator.SetFloat("Speed", 1.0f);

        this.stateText = GameObject.Find("GameResultText");
        this.scoreText = GameObject.Find("ScoreText");
		
	}
	// Update is called once per frame
	void Update () {

        if (this.isEnd)
        {
            this.forwadForce *= this.coefficient;
            this.turnForce *= this.coefficient;
            this.upForce *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;

        }


        this.myRigidbody.AddForce(this.transform.forward * this.forwadForce);


        //方向移動と移動制限
        if ((Input.GetKey(KeyCode.LeftArrow) || this.isLButtonDown == true) && -this.movableRange < this.transform.position.x)
        {
            this.myRigidbody.AddForce(-this.turnForce, 0, 0);
        }
        else if ((Input.GetKey(KeyCode.RightArrow) || this.isRButtonDown == true) && this.transform.position.x < this.movableRange)
        {
            this.myRigidbody.AddForce(this.turnForce, 0, 0);
        }

        //アニメーターのJumpeの状態を習得（tureなら実行）
        if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }
        //スペースを押したときジャンプ、地面に着いているとジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && this.transform.position.y < 0.5)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * upForce);
        }
	}


    void OnTriggerEnter(Collider other)
    {
        //障害物にぶつかったとき
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "GAME OVER";
            
        }
        //ゴールした時
        if(other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }
        //コインをとったときエフェクトを表示してコインを破壊
        if(other.gameObject.tag == "CoinTag")
        {
            score += 10;
            scoreText.GetComponent<Text>().text = "score " + this.score + "pt";

            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);
        }
    }

    public void GetMyJumpButtonDown()
    {
        if(this.transform.position.y < 0.5)
        {
            this.myAnimator.SetBool("Jump", true);
            this.myRigidbody.AddForce(this.transform.up * this.upForce);
        }
    }

    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }

    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }

    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }

    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }
}
