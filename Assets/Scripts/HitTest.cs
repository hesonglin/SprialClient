using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
public class HitTest : MonoBehaviour
{
    // Start is called before the first frame update
    Transform cube;
    void Start()
    {
        Application.targetFrameRate = 60;
        cube = GameObject.Find("Cube").transform;
        Stage.inst.onTouchBegin.Add(OnTouchBegin);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTouchBegin()
    {
        if(!Stage.isTouchOnUI)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Stage.inst.touchPosition.x, Screen.height - Stage.inst.touchPosition.y));
            if(Physics.Raycast(ray,out hit))
            {
                if (hit.transform == cube)
                {
                    Debug.Log("Hit the cube");
                }
            }
        }
    }
}
