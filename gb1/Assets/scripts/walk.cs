using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : MonoBehaviour
{
    public float speed = 0f;
    private Vector3 _direction;
    public GameObject hack_wire;
    private bool _isfire = false;
    private bool _issprint = false;
    public Transform wirepoint;
    public float damage;
    public float lifetime;
    public float sprint;

    
    // Start is called before the first frame update
    void Awake()
    {
        _direction = Vector3.zero;
    }
    void Start()
    { 
    }
    // Update is called once per frame
    void Update()
    {
        _direction.x = Input.GetAxis("Horizontal");
        _direction.z = Input.GetAxis("Vertical");

        if (Input.GetMouseButtonDown(0))
        {
            _isfire = true;
        }
        else
        {
            _isfire = false;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _issprint = true;
        }
        else
        {
            _issprint = false;
        }
    }
    void FixedUpdate()
    {
        if (_isfire)
        {
            Fire();
        }
        Move();
    }
    private void Move()
    {
        Vector3 direction = _direction * (_issprint ? sprint : 1) * speed * Time.fixedDeltaTime;
        transform.position += direction;
    }
    private void Fire()
    {
        GameObject wireOBJ = Instantiate(hack_wire, wirepoint.position, Quaternion.Euler(90, 0 , 0));
        wire wire = wireOBJ.transform.gameObject.GetComponent<wire>();
        wire.Init(damage, 3f);
    }
}
