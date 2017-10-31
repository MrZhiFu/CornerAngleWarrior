using UnityEngine;
using System.Collections;

public class StoryLabelDestroySelf : MonoBehaviour {

    private void Start()
    {
        GameObject.Destroy(this.gameObject, 15f);
    }
}
