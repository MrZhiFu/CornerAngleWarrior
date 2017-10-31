using UnityEngine;
using System.Collections;

//奖励物品类型
public enum ItemType {
        DualSword,  //吃到可以换剑
        Gun             //吃到可以换枪
    }

public class AwardItem : MonoBehaviour {
    public ItemType itemtype;
    private Rigidbody rigidbody;//奖励物品的刚体组件

    private bool isStartMove = false;//是否开始运动
    public float speed = 10;//运动速度
    private Transform playerTrs;//主角位置

    private void Awake()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start () {
        rigidbody.velocity = new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));//奖励物品随机运动
	}

    private void Update()
    {
        if (isStartMove == true)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, playerTrs.position+Vector3.up, Time.deltaTime * speed);//向主角方向移动
            if (Vector3.Distance(this.transform.position, playerTrs.position+Vector3.up) < 0.4f)//表示主角吃到奖励物品了
            {
                playerTrs.GetComponent<PlayerPickUpAward>().PickeUpAward(itemtype);//主角吃奖励物品的方法
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)//接触地面的检测
    {
        if (collision.collider.tag == Tags.ground)
        {
            //奖励物品碰到地面之后先静止
            rigidbody.useGravity = false;
            rigidbody.isKinematic = true;
            //然后奖励物品的碰撞器变成触发器，同时半径增大，方便主角拾取 
            SphereCollider col = this.GetComponent<SphereCollider>();
            col.isTrigger = true;
            col.radius = 2f;
        }
    }

    private void OnTriggerEnter(Collider other)//接触主角的检测
    {
        if (other.tag == Tags.player) {
            isStartMove = true;
            playerTrs = other.transform;
        }
    }
}
