using UnityEngine.Events;
using UnityEngine;

public class scriptMiado : MonoBehaviour
{
    public UnityEvent endAnim;
    public void EventPlay()
    {
        Debug.Log("what");
        endAnim.Invoke();
    }
}