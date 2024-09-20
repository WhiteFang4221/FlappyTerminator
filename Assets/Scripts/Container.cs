using UnityEngine;

public class Container : MonoBehaviour
{
    public void ClearContainer()
    {
        int childCount = transform.childCount;

        if (childCount > 0)
        {
            for (int i = childCount - 1; i >= 0; i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}

