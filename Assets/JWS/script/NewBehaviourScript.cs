using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject prefab; // ������ ������Ʈ�� �������� �������ݴϴ�.
    public Transform parentTransform; // �θ� ������Ʈ�� Transform�� �������ݴϴ�.

    private void Start()
    {
        CreateObject();
    }
    void CreateObject()
    {
        // ���������κ��� ������Ʈ�� �����մϴ�.
        GameObject newObject = Instantiate(prefab, parentTransform);

        // ���� �θ� Transform�� �������� �ʾҴٸ� ������ ���� �����մϴ�.
        // GameObject newObject = Instantiate(prefab);

        // ���� ������ ������Ʈ�� �θ� ���߿� �����Ϸ��� ������ ���� �մϴ�.
        // newObject.transform.parent = parentTransform;
    }
}
