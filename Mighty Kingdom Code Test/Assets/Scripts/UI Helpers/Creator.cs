using UnityEngine;


public class Creator : MonoBehaviour
{
    [SerializeField]
    Transform parent = default;

    [SerializeField]
    Transform creationPoint = default;


    public void ObjectCreate(Object objectToCreate)
    {
        Instantiate(objectToCreate, creationPoint.position, Quaternion.identity, parent);
    }
}