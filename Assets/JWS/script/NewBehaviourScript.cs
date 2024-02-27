using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject prefab; // 생성할 오브젝트의 프리팹을 설정해줍니다.
    public Transform parentTransform; // 부모 오브젝트의 Transform을 설정해줍니다.

    private void Start()
    {
        CreateObject();
    }
    void CreateObject()
    {
        // 프리팹으로부터 오브젝트를 생성합니다.
        GameObject newObject = Instantiate(prefab, parentTransform);

        // 만약 부모 Transform을 설정하지 않았다면 다음과 같이 생성합니다.
        // GameObject newObject = Instantiate(prefab);

        // 만약 생성된 오브젝트의 부모를 나중에 설정하려면 다음과 같이 합니다.
        // newObject.transform.parent = parentTransform;
    }
}
