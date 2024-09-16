using UnityEngine;

public class PipeContainer : MonoBehaviour
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
