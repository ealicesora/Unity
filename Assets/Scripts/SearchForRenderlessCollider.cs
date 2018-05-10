using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class SearchForRenderlessCollider : MonoBehaviour
{

    [SerializeField, Tooltip("点击这里寻找所有物品")]
    bool RunSearch_;
    [SerializeField]
    List<GameObject> InactiveGameObject_;

    // Update is called once per frame
    void Update()
    {
        if (Application.isPlaying)
        {
            Destroy(this.gameObject);
        }
        else if (RunSearch_)
        {
            InactiveGameObject_.Clear();
            List<GameObject> tResults_ = GetAllObjectsInScene();
            foreach (GameObject result in tResults_)
            {
                if (result.activeSelf == false)
                {
                    InactiveGameObject_.Add(result);
                }
            }
            RunSearch_ = false;
        }
    }

    List<GameObject> GetAllObjectsInScene()
    {
        List<GameObject> objectsInScene = new List<GameObject>();

        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.hideFlags == HideFlags.None)
            {
                objectsInScene.Add(go);
            }
        }

        return objectsInScene;
    }
}
