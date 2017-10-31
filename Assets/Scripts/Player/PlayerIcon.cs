using UnityEngine;
using System.Collections;

public class PlayerIcon : MonoBehaviour {

    private Transform playerIconTrs;//主角在小地图上的图标

    // Use this for initialization
    void Start () {
        playerIconTrs = MinMap._instance.GetPlayerIconTrs();
	}
	
	// Update is called once per frame
	void Update () {
        float rotateY = this.transform.eulerAngles.y;
        playerIconTrs.localEulerAngles = new Vector3(0, 0, -rotateY);//将主角的旋转变化为主角图标在小地图上的旋转
	}
}
