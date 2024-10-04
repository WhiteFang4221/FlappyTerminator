using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action SpacePressed;
    public event Action SpaceUnpressed;
    public event Action LeftMousePressed;

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            SpacePressed?.Invoke();
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            SpaceUnpressed?.Invoke();
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            LeftMousePressed?.Invoke();
        }
    }

    public void Reset()
    {
        SpaceUnpressed?.Invoke();
    }
}
