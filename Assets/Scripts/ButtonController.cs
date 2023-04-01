using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ButtonController : MonoBehaviour
{
 
    public abstract void SetDisable(GameObject gameOb);

    public abstract void SetEnable(GameObject gameOb);

    public abstract void LoadSceneOption(int sceneNum);
}
