using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint, _finishPoint;
    [SerializeField] private float _speed;
    [SerializeField] private float _waitingTime = 6f;

    private bool _isGrab;

    private void Update()
    {
        if (_isGrab == false)
        {
            Move(_finishPoint);
        }
        else if (_isGrab)
        {
            Move(_firstPoint);
        }
    }

    private void ComeBack()
    {
        _isGrab = true;
    }

    private void Move(Transform target)
    {
        transform.position =
                Vector2.MoveTowards(transform.position, target.transform.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Alarm>(out Alarm alarm))
        {
            Invoke(nameof(ComeBack), _waitingTime);
        }
    }
}
