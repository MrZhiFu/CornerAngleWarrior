using UnityEngine;
using System.Collections;

public class EffectAutoDestroy : MonoBehaviour {

    public float exitTime = 1f;//特效存在时间

	// Use this for initialization
	void Start () {
        GameObject.Destroy(this.gameObject, exitTime);//打击特效1秒后自动销毁   
	}
}
