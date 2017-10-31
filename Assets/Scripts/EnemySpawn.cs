using UnityEngine;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject prefab;

    //每一个位置生成敌人的方法
    public GameObject SpwanEnemy() {
        return GameObject.Instantiate(prefab, this.transform.position, this.transform.rotation)as GameObject;
    }
}
