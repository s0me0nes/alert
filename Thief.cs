using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint, _finishPoint;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _door;
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
        _door.SetActive(false);
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
            _door.SetActive(true);
            Invoke(nameof(ComeBack), _waitingTime);
        }
    }
}
