using UnityEngine;
using System.Collections;

public class PlayerDress : MonoBehaviour {

    public SkinnedMeshRenderer[] bodyMeshRendererArray;//用于设置身体的形状和颜色的数组
    public UILabel nameLabel;//用于显示角色名字的UI文本

    // Use this for initialization
    void Start () {
        InitDress();
    }

    void InitDress() {//初始化换过的装扮
        //获取身体形状的设置
       int headIndex = PlayerPrefs.GetInt("HeadMeshIndex");
       int handIndex = PlayerPrefs.GetInt("HandMeshIndex");
       int footIndex = PlayerPrefs.GetInt("FootMeshIndex");
       int upperBodyIndex = PlayerPrefs.GetInt("UpperBodyMeshIndex");
        int lowerBodyIndex = PlayerPrefs.GetInt("LowerBodyMeshIndex");
        //获取身体颜色的设置
       int colorIndex = PlayerPrefs.GetInt("ColorIndex");

        //设置角色名字
        nameLabel.text = "Name:"+PlayerPrefs.GetString("Name");
        //设置身体形状
        bodyMeshRendererArray[0].sharedMesh = CharacterSetting._instance.headMeshArray[headIndex];
        bodyMeshRendererArray[1].sharedMesh = CharacterSetting._instance.handMeshArray[handIndex];
        bodyMeshRendererArray[2].sharedMesh = CharacterSetting._instance.footMeshArray[footIndex];
        bodyMeshRendererArray[3].sharedMesh = CharacterSetting._instance.upperBodyMeshArray[upperBodyIndex];
        bodyMeshRendererArray[4].sharedMesh = CharacterSetting._instance.lowerBodyMeshArray[lowerBodyIndex];

        //设置身体颜色
        foreach (SkinnedMeshRenderer renderer in bodyMeshRendererArray)
        {
            renderer.material.color = CharacterSetting._instance.colorArray[colorIndex];
        }
    }
}
