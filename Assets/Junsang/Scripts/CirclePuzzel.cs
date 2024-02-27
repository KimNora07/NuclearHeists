using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ButtonData
{
    public RectTransform imageRectTransform;
    public Button rotateButton;
    public float rotationAmount = 60f;
    public float duration = 2f;
    public float trueRotation;

    public bool isTrue = false;
    public bool canRotate = true;
}

public class CirclePuzzel : MonoBehaviour
{
    public List<ButtonData> buttonDataList;

    void Start()
    {
        // 각각의 버튼에 대한 리스너를 추가
        for (int i = 0; i < buttonDataList.Count; i++)
        {
            int index = i; // 클로저 문제 해결을 위해 인덱스를 복사

            buttonDataList[i].rotateButton.onClick.AddListener(() => RotateImageOnClickHandler(index));
        }
    }

    void Update()
    {
        bool allTrue = true;

        for (int i = 0; i < buttonDataList.Count; i++)
        {
            buttonDataList[i].isTrue = IsRotationEqual(buttonDataList[i].imageRectTransform.localRotation.eulerAngles.z, buttonDataList[i].trueRotation);
        }

        foreach (ButtonData buttonData in buttonDataList)
        {
            if (!buttonData.isTrue)
            {
                allTrue = false;
                break;
            }
        }

        if(allTrue)
        {
            Debug.Log("모두 True");
        }
    }

    bool IsRotationEqual(float currentRotation, float targetRotation)
    {
        float epsilon = 0.0001f;
        float adjustedTargetRotation = (targetRotation + 360) % 360;

        return Mathf.Abs(currentRotation - adjustedTargetRotation) < epsilon;
    }

    void RotateImageOnClickHandler(int index)
    {
        if (buttonDataList[index].canRotate)
        {
            float newRotation = buttonDataList[index].imageRectTransform.localRotation.eulerAngles.z + buttonDataList[index].rotationAmount;
            StartCoroutine(RotateImage(buttonDataList[index].imageRectTransform, buttonDataList[index].imageRectTransform.localRotation.eulerAngles.z, newRotation, buttonDataList[index].duration));
            buttonDataList[index].canRotate = false;
        }
    }

    IEnumerator RotateImage(RectTransform imageRectTransform, float fromAngle, float toAngle, float time)
    {
        float elapsedTime = 0f;

        while (elapsedTime < time)
        {
            float currentAngle = Mathf.Lerp(fromAngle, toAngle, elapsedTime / time);
            imageRectTransform.localRotation = Quaternion.Euler(0, 0, currentAngle);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageRectTransform.localRotation = Quaternion.Euler(0, 0, toAngle);
        buttonDataList.Find(x => x.imageRectTransform == imageRectTransform).canRotate = true;
    }
}
