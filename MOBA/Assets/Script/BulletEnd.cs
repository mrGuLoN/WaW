using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(this.gameObject,0.2f);
    }
}
