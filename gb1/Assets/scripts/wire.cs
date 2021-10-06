using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire : MonoBehaviour
{
    private float _damage;
    public float speed;
    private Vector3 direct;
    // Start is called before the first frame update
    public void Init(float damage, float lifetime)
    {
        _damage = damage;
        Destroy(this.gameObject, lifetime);
    
    }
    private void Awake()
    {
        direct.z = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = direct * speed * Time.fixedDeltaTime;
        this.transform.position += direction;
    }
}
