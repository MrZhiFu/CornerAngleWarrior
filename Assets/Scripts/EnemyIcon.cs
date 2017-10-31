using UnityEngine;
using System.Collections;

public class EnemyIcon : MonoBehaviour {

    private Transform icon;//敌人在小地图上的图标
    private Transform playerTrs;//主角在世界坐标系中的图标

	// Use this for initialization
	void Start () {
        if (this.tag == Tags.soulBoss1 || this.tag == Tags.soulBoss2)//如果是Boos就生成Boos在小地图中的图标
        {
            icon = MinMap._instance.GetBossIcon().transform;
        }
        else if (this.tag == Tags.soulMonster)//如果是Monster就生成Monster在小地图中的图标
        {
            icon = MinMap._instance.GetEnemyIcon().transform;
        }
        playerTrs = GameObject.FindGameObjectWithTag(Tags.player).transform;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 offset = this.transform.position - playerTrs.position;
        offset *= 10;
        icon.localPosition = new Vector3(offset.x, offset.z, 0);
	}

    private void OnDestroy()//敌人死后敌人在小地图上的图标也销毁
    {
        if (icon != null)
        {
            Destroy(icon.gameObject);
        }
    }
}
