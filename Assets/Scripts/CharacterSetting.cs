using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CharacterSetting : MonoBehaviour{

    public static CharacterSetting _instance;//单例模式

    public UIInput nameInput;//用来存储输入的角色名字
    public Color purple;//紫色（因为Color枚举中没有定义紫色）
    public SkinnedMeshRenderer headRenderer;//头的皮肤网格渲染器
    public SkinnedMeshRenderer handRenderer;//手的皮肤网格渲染器
    public SkinnedMeshRenderer footRenderer;//脚的皮肤网格渲染器
    public SkinnedMeshRenderer upperBodyRenderer;//身体上部的皮肤网格渲染器
    public SkinnedMeshRenderer lowerBodyRenderer;//身体下部的皮肤网格渲染器

    public Mesh[] headMeshArray;//头部换装所需要的Mesh数组
    public Mesh[] handMeshArray;//手部换装所需要的Mesh数组
    public Mesh[] footMeshArray;//脚换装所需要的Mesh数组
    public Mesh[] upperBodyMeshArray;//身体上部换装所需要的Mesh数组
    public Mesh[] lowerBodyMeshArray;//身体下部换装所需要的Mesh数组

    private int[] meshIndex = {0,0,0,0,0};//渲染数组索引

    public SkinnedMeshRenderer[] allBodyRendererArray;//身体上的所有渲染器，用于切换颜色

    [HideInInspector]
    public Color[] colorArray;//保存角色身体颜色的数组
    private int colorIndex = -1;//角色身体颜色数组的索引（由于角色的保存和加载）

    void Awake() {
        _instance = this;
        colorArray = new Color[] { Color.blue, Color.cyan, Color.green, purple, Color.red };
    }

    void Start() {
        DontDestroyOnLoad(this.gameObject);//在加载新的场景时不销毁当前游戏对象，因为要使用该游戏对象保存角色的换装设置
    }

    public void OnHeadNextClick()//HeadNext箭头点击事件
    {
        meshIndex[0]++;
        meshIndex[0] %= headMeshArray.Length;//循环颜色的选择
        headRenderer.sharedMesh = headMeshArray[meshIndex[0]];
    }

    public void OnHandNextClick() //HandNext箭头点击事件
    {
        meshIndex[1]++;
        meshIndex[1] %= handMeshArray.Length;
        handRenderer.sharedMesh = handMeshArray[meshIndex[1]];
    }

    public void OnFootNextClick()//FootNext箭头点击事件
    {
        meshIndex[2]++;
        meshIndex[2] %=  footMeshArray.Length;//循环颜色的选择
        footRenderer.sharedMesh = footMeshArray[meshIndex[2]];
    }

    public void OnUpperBodyNextClick()//UpperBodyNext箭头点击事件
    {
        meshIndex[3]++;
        meshIndex[3] %= upperBodyMeshArray.Length;//循环颜色的选择
        upperBodyRenderer.sharedMesh = upperBodyMeshArray[meshIndex[3]];
    }

    public void OnLowerBodyNextClick()//LowerBodyNext箭头点击事件
    {
        meshIndex[4]++;
        meshIndex[4] %= lowerBodyMeshArray.Length;//循环颜色的选择
        lowerBodyRenderer.sharedMesh = lowerBodyMeshArray[meshIndex[4]];
    }

    public void OnBlueButtonClick() //蓝色按钮点击事件
    {
        ChangeColor(Color.blue);
        colorIndex = 0;
    }

    public void OnCyanButtonClick( ) //淡蓝色按钮点击事件
    {
        ChangeColor(Color.cyan);
        colorIndex = 1;
    }

    public void OnGreenButtonClick() //绿色按钮点击事件
    {
        ChangeColor(Color.green);
        colorIndex = 2;
    }

    public void OnPurpleButtonClick()//紫色按钮点击事件
    {
        ChangeColor(purple);
        colorIndex = 3;
    }

    public void OnRedButtonClick() //红色按钮点击事件
    {
        ChangeColor(Color.red);
        colorIndex = 4;
    }

    private void ChangeColor(Color color)//改变身体颜色的方法
    {
        foreach (var item in allBodyRendererArray)
        {
            item.material.color = color;
        }
    }

    public void OnPlayButtonClick() //开始游戏按钮
    {
        SavePlayerInfo();
        SceneManager.LoadScene(1);
    }

    private void SavePlayerInfo() 
    {
        //保存角色名字
        PlayerPrefs.SetString("Name", nameInput.value);
        //保存身体形状的设置
        PlayerPrefs.SetInt("HeadMeshIndex", meshIndex[0]);
        PlayerPrefs.SetInt("HandMeshIndex", meshIndex[1]);
        PlayerPrefs.SetInt("FootMeshIndex", meshIndex[2]);
        PlayerPrefs.SetInt("UpperBodyMeshIndex", meshIndex[3]);
        PlayerPrefs.SetInt("LowerBodyMeshIndex", meshIndex[4]);
        //保存身体颜色的设置
        PlayerPrefs.SetInt("ColorIndex", colorIndex);
    }
}
