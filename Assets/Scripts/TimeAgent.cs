using System;
using Unity.VisualScripting;
using UnityEngine;

//time agent for day night cycle and crops growing
public class TimeAgent : MonoBehaviour
{
    public Action onTimeTick;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        GameManager.instance.timeController.Subscribe(this);
    }

    public void Invoke()
    {
        onTimeTick?.Invoke();
    }

    private void OnDestroy()
    {
        GameManager.instance.timeController.Unsubscribe(this);
    }
}
