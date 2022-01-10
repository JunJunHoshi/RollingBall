using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] public Color myColor = new Color();
    private GameObject SmokeObj;

    public static string DestroyBallName; //衝突した際に消すボールの名前を格納。これを全てのBallで一律に共有し、当てはまるなら消去
    //最初に自身の色を代入
    private void Awake()
    {
        SetColor();
    }
    private void Start()
    {
        SmokeObj = StageManager.GetSmokeObj();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Ball>() == null)
        {
            return;
        }
        //もし他のボールに衝突した際は自分の色を足した色に変更
        var othercolor = collision.gameObject.GetComponent<Ball>().myColor;
        MixtureColors(othercolor);

        //ぶつかった時はお互いの名前を共有し、コンマ秒後にその名前と一致しているボールだけ消す　→　結果片方だけが消える
        if (collision.gameObject.TryGetComponent<Ball>(out Ball otherBall))
        {
            ShareDestroyBallName(otherBall); //消すボールの名前を共有
            StartCoroutine(DestroyBall());
        }
    }

    private void MixtureColors(Color othercolor)
    {
        myColor = ColorManager.MixtureColor(myColor, othercolor);
        SetColor();
    }

    private void SetColor()
    {
        GetComponent<MeshRenderer>().material.color = myColor;
    }

    private void ShareDestroyBallName(Ball otherBall)
    {
        Ball.DestroyBallName = this.gameObject.name;
    }

    private void PlaySmokeEffect()
    {
        GameObject smoke = Instantiate(SmokeObj.gameObject, position:new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Quaternion.identity);
        smoke.GetComponent<ParticleSystem>().Play();
        Destroy(smoke, 1f);
    }

    private IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(0.00001f);
        if (DestroyBallName == this.gameObject.name)
        {
            PlaySmokeEffect();
            Destroy(gameObject);
        }
    }
}
