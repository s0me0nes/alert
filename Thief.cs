using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField] private Transform _firstPoint, _finishPoint;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _door;

    private bool _isGrab;

    private void Update()
    {
        if (_isGrab == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, _finishPoint.transform.position, _speed * Time.deltaTime);
        }
        else if (_isGrab)
        {
            transform.position = Vector2.MoveTowards(transform.position, _firstPoint.transform.position, _speed * Time.deltaTime);
        }
    }

    private void Comeback()
    {
        _isGrab = true;
        _door.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float waitingTime = 6f;

        if (collision.gameObject.TryGetComponent<Alarm>(out Alarm alarm))
        {
            _door.SetActive(true);
            Invoke("Comeback", waitingTime);
        }
    }
}
