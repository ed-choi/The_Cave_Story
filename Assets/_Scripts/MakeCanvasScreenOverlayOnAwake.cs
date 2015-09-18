using UnityEngine;
using System.Collections;

public class MakeCanvasScreenOverlayOnAwake : MonoBehaviour {

    //  Purely for the fact that the canvas makes it hard to click-select objects that are behind it while
    //  editing stuff in scene mode/view. So I moved it up 500 unitys and set it to World Space
    //  in the inspector.
    void Awake() {
        this.GetComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
    }

}