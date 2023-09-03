using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class House : MonoBehaviour
{
    private Alarm _alarm;

    private void Awake()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thief thief))
        {
            _alarm.Activate();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Thief thief))
        {
            _alarm.Deactivate();
        }
    }
}
