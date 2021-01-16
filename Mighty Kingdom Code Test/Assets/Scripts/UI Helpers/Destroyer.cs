using UnityEngine;


public class Destroyer : MonoBehaviour
{
    public void ObjectDestroy(Object objectToDestroy)
    {
        Destroy(objectToDestroy);
    }
}