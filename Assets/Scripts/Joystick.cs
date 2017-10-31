using UnityEngine;
using System.Collections;

public class Joystick : MonoBehaviour {
    private bool isPress = false;//是否按下了虚拟杆
    private Transform buttonTrs;//虚拟杆的中心按钮

    public static float h = 0;//获取到虚拟杆的水平值
    public static float v = 0;//获取到虚拟杆的垂直值

    void OnPress(bool isPress) //在NGUI中使用虚拟杆时，用来检测虚拟杆是否按下的函数，参数为是否按下的布尔值
    {
        this.isPress = isPress;
        if (isPress == false)//如果检测不到触摸就把中心按钮归0；
        {
            buttonTrs.localPosition = Vector2.zero;
            h = 0; v = 0;
        }
    }

	// Use this for initialization
	void Awake() {
        buttonTrs = transform.Find("Button");
	}
	 
	// Update is called once per frame
	void Update () {
        if (isPress == true)
        {
            Vector2 touchPos = UICamera.lastEventPosition;//UICamera.lastEventPosition用于在虚拟杆中获取触摸的位置坐标（坐标原点在左下角）
            touchPos -= new Vector2(228, 228);//使坐标原点移到虚拟杆中心位置（228为虚拟杆图片中心到屏幕底部的距离）
            float distance = Vector2.Distance(Vector2.zero, touchPos);//计算出触摸点与原点的距离，此时就是计算虚拟杆的半径
            if (distance > 125)//判断该距离是否大于虚拟杆圆形的半径150，如果大于那就最大为150。
            {
                touchPos = touchPos.normalized * 125;
                buttonTrs.localPosition = touchPos;
            }
            else
            {
                buttonTrs.localPosition = touchPos;
            }

            //把虚拟杆的水平值和垂直值设置为 -1 ~ 1。
            h = touchPos.x / 125;
            v = touchPos.y / 125;
        }
	}
}
