using UnityEngine;
using System.Collections;

public class MinMap : MonoBehaviour {
    public static MinMap _instance;
    private Transform playerIconTrs;//主角在小地图上的图标
    public GameObject enemyIconPrefab;//敌人在地图上的图标预设（为什么是预设呢，因为敌人都是动态生成的，所以其在小地图的图标也应该是动态生成的）

	// Use this for initialization
	void Awake () {
        _instance = this;
        playerIconTrs = GameObject.Find("PlayerIcon").transform;
	}

    public Transform GetPlayerIconTrs(){//得到主角在小地图上的图标 
        return playerIconTrs;
     }

    public GameObject GetBossIcon() { //获取Boss图标
        GameObject go = NGUITools.AddChild(this.gameObject, enemyIconPrefab);
        go.GetComponent<UISprite>().spriteName = "BossIcon";
        return go;
    }
    public GameObject GetEnemyIcon()
    { //获取图标
        GameObject go = NGUITools.AddChild(this.gameObject, enemyIconPrefab);
        go.GetComponent<UISprite>().spriteName = "EnemyIcon";
        return go;
    }
}
