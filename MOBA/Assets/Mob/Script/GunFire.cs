using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [SerializeField] private GameObject fireLight;

    [SerializeField] private Transform gunPoint;
    [SerializeField] private float timeout = 0.5f;
    [SerializeField] private float dmg;
   // [SerializeField] private Rigidbody bulletEnd;
    private float curTimeout;
    public bool needFire = false;
    private AudioSource shoot;
    // Start is called before the first frame update
    void Start()
    {
        fireLight.SetActive(false);
        shoot = GetComponent<AudioSource>();
        shoot.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (needFire == true)
        {

            curTimeout += Time.deltaTime;
            fireLight.SetActive(false);
            if (curTimeout > timeout)
            {
                curTimeout = 0;
                shoot.Stop();
                shoot.Play();
                RaycastHit hit;
                Ray ray = new Ray(gunPoint.position, gunPoint.forward);
                
                fireLight.SetActive(true);

                if (Physics.Raycast(ray, out hit, 20))
                {
                    if (hit.transform.gameObject.CompareTag("EnemyTurell") || hit.transform.gameObject.CompareTag("EnemyMob") || hit.transform.gameObject.CompareTag("EnemyPlayer"))
                    {
                        hit.transform.gameObject.GetComponent<HP>().dmg = dmg;
                        hit.transform.gameObject.GetComponent<HP>().haveDmg = true;
                        Debug.Log("Fire!!!");
                    }
                    //Rigidbody bulletInstance = Instantiate(bulletEnd, hit.point, Quaternion.identity) as Rigidbody;
                   
                }
            }
        }
        else
        {
            
            fireLight.SetActive(false);
        }
    }
}
