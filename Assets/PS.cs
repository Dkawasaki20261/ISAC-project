using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS : MonoBehaviour
{
    private CharacterController cc;// CharacterControllerを使うための変数
    private Vector3 velocity;// CharacterControllerに重力をかけるための変数
    private bool ToolSpawned = false;

    public float jumpPower = 8;// ジャンプ力
    public float moveSpeed = 10;// 移動スピード

    public float sensitivityX = 4F;// マウスの横の動きの強さ
    public float sensitivityY = 4F;// マウスの縦の動きの強さ

    public float minimumX = -360F;// 横の回転の最低値
    public float maximumX = 360F;// 横の回転の最大値

    public float minimumY = -60F;// 縦の回転の最低値
    public float maximumY = 60F;// 縦の回転の最大値s

    public float rotationX = 0f;// 横軸の回転量
    public float rotationY = 0f;// 縦軸の回転量

    public GameObject verRot;// 縦回転させるオブジェクト（カメラ）
    public GameObject horRot;// 横回転させるオブジェクト（プレイヤー）
    public GameObject Pickaxe;
    public GameObject Axe;
    public GameObject ASIBA;
    public GameObject ASIBA2;
    public GameObject Arm_2_Right_end;

    void Start()
    {
        cc = GetComponent<CharacterController>();// CharacterControllerの値を取得してccに代入
    }

    void Update()
    {
        rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;//rotationXを現在のyの向きにXの移動量*sensitivityXの分だけ回転させる

        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;//rotationYにYの移動量*sensitivityYの分だけ増やす
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);//rotationYを-60〜60の値にする

        verRot.transform.localEulerAngles = new Vector3(-rotationY, 0, 0);//オブジェクトの向きをnew Vector3(-rotationY, rotationX, 0)にする
        horRot.transform.localEulerAngles = new Vector3(0, rotationX, 0);//オブジェクトの向きをnew Vector3(-rotationY, rotationX, 0)にする

        if (Input.GetKey(KeyCode.W))// もし、Wキーがおされたら、
        {
            cc.Move(this.gameObject.transform.forward * moveSpeed * Time.deltaTime);// 前方に動かす
        }

        if (Input.GetKey(KeyCode.S))// もし、Sキーがおされたら、
        {
            cc.Move(this.gameObject.transform.forward * -1f * moveSpeed * Time.deltaTime);// 後方に動かす
        }

        if (Input.GetKey(KeyCode.A))// もし、Aキーがおされたら、
        {
            cc.Move(this.gameObject.transform.right * -1 * moveSpeed * Time.deltaTime);// 左に動かす
        }

        if (Input.GetKey(KeyCode.D))// もし、Dキーがおされたら

        {
            cc.Move(this.gameObject.transform.right * moveSpeed * Time.deltaTime);// 右に動かす
        }

        cc.Move(velocity * Time.deltaTime); //ccを常にvelocity分動かす

        velocity.y += Physics.gravity.y * Time.deltaTime;// velocity.yには重力分足し続ける
        if (cc.isGrounded)// もし地面に着いていたら、
        {
            if (Input.GetKey(KeyCode.Space))// もし、スペースキーがおされたら
            {
                velocity.y = jumpPower;// ジャンプする
            }
        }
        if (Input.GetMouseButtonDown(0) && ToolSpawned == false)// もし、左クリックされたら、
        {
            ToolSpawned = true;
            StartCoroutine(PickaxeSpawendCo());
        }
        if (Input.GetKey(KeyCode.Z) && ToolSpawned == false)// もし、Zされたら、
        {
            ToolSpawned = true;
            StartCoroutine(AxeSpawendCo());
        }
        if (Input.GetKey(KeyCode.Alpha1))
        {
            StartCoroutine(ASIBA1SpawendCO());
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            StartCoroutine(ASIBA2SpawendCO());
        }
        
        
    }
    IEnumerator PickaxeSpawendCo()
    {
            GameObject Pickaxes = Instantiate(Pickaxe) as GameObject;
            Pickaxes.transform.SetParent(Arm_2_Right_end.transform);
            Pickaxes.transform.localPosition = new Vector3(0,0,0);
            Pickaxes.transform.localRotation = Quaternion.EulerAngles(338,-97,128); 
            yield return new WaitForSeconds(1);
            Destroy(Pickaxes.gameObject);
            ToolSpawned = false;
    }
    IEnumerator AxeSpawendCo()
    {
            GameObject Axes = Instantiate(Axe) as GameObject;
            Axes.transform.SetParent(Arm_2_Right_end.transform);
            Axes.transform.localPosition = new Vector3(0,-0.00019f,-0.00114f);
            Axes.transform.localRotation = Quaternion.EulerAngles(180,-90,90);
            yield return new WaitForSeconds(1);
            Destroy(Axes.gameObject, 1);
            ToolSpawned = false;
    }
    IEnumerator ASIBA1SpawendCO()
    {
        GameObject ASIBAs = Instantiate(ASIBA) as GameObject;
        ASIBAs.transform.position = transform.position + transform.forward * 3;
        ASIBAs.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(1);
        Destroy(ASIBAs.gameObject, 5);
    }
    IEnumerator ASIBA2SpawendCO()
    {
        GameObject ASIBA2s = Instantiate(ASIBA2) as GameObject;
        ASIBA2s.transform.position = transform.position + transform.forward * 3;
        ASIBA2s.transform.rotation = transform.rotation;
        yield return new WaitForSeconds(1);
        Destroy(ASIBA2s.gameObject, 5);
    }



    // void OnCollisionStay(Collision hit)
    // {
    //     if(hit.gameObject.tag=="Rock")
    //     {
    //         Debug.Log("Touching rock");
    //         if(Input.GetMouseButtonUp(1))
    //         {
    //             Debug.Log("Touching rock and right clicked");
    //             GameObject obj = GameObject.Find("Rock.1");
    //             Destroy(obj);
    //         }
    //     }
    // }
}