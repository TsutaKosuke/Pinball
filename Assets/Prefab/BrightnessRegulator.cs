using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    Material myMaterial;//Materialを入れる

    private float minEmission = 0.3f;//Emissionの最小値

    private float magEmission = 2.0f;//Emissionの強度

    private int degree = 0;//角度

    private int speed = 10;//発光速度

    Color defaultColor = Color.white;//ターゲットのデフォルトの色

    // Start is called before the first frame update
    void Start()
    {
        this.myMaterial = GetComponent<Renderer>().material;//オブジェクトにアタッチしているマテリアlを取得

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", this.defaultColor * minEmission);

        //タグによって光らせる色を変える
        if (tag == "SmallStarTag")
        {
            this.defaultColor = Color.white;
        }
        else if (tag == "LargeStarTag")
        {
            this.defaultColor = Color.yellow;
        }
        else if (tag == "SmallCloudTag" || tag == "LargeCloudTag")
        {
            this.defaultColor = Color.cyan;          //cyanは水色に近い青緑色的なやつ
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.degree >= 0)
        {
            //光らせる強度を計算する
            Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin(this.degree * Mathf.Deg2Rad) * this.magEmission);

            //エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            this.degree -= this.speed;
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        this.degree = 180;
    }
}
