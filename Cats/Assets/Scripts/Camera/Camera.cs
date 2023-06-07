using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject targetObject;

    void LateUpdate() {
    transform.position = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, transform.position.z);
}
}
