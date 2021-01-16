using UnityEngine;


public class Creator : MonoBehaviour
{
    [SerializeField]
    Transform parent;

    public void ObjectCreate(Object objectToCreate)
    {
        Instantiate(objectToCreate, parent);
    }
}