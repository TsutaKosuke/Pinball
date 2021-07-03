using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //課題
    private GameObject scoreText;

    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //課題
        this.scoreText = GameObject.Find("Score");

        
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外の出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "GameOver";
        }
    }

    //課題
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "SmallStarTag")
        {
            score += 10;
        }
        else if (collision.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }
        else if (collision.gameObject.tag == "SmallCloudTag" || collision.gameObject.tag == "LargeCloudTag")
        {
            score += 50;
        }

        this.scoreText.GetComponent<Text>().text = score.ToString();
    }

   
}
