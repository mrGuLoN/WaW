using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private int spreadRadius;
    [SerializeField] private float dmg;
    [SerializeField] private int ammo;
    [SerializeField] private int shot;
    [SerializeField] private GameObject fire;
    [SerializeField] private Rigidbody bulletEnd;
    [SerializeField] private Animator ani;    
    [SerializeField] private Camera _cam;
    [SerializeField] private float reloadTime;


    private int ammoIn;
    private float xRadius;
    private float yRadius;
    private float curTimeout;
    [SerializeField] private float tempFire;
    private float tmp;
    private bool reload;
    private bool reloadGo;

    private float checkDeath;
    private int boom;
    private bool onfire;
  // private PlayerMoveAndLvl pMoveLvl;



    // Start is called before the first frame update
    void Start()
    {
        fire.SetActive(false);       
        boom = 0;
        onfire = false;
        ammoIn = ammo;
        //pMoveLvl = GetComponent<PlayerMoveAndLvl>();
        tmp = 1 / tempFire;
        reload = false;
        curTimeout = tmp;
        reloadGo = false;
    }

    // Update is called once per frame
    void Update()
    {
        curTimeout += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse0) && onfire == false && curTimeout > tmp && reload == false)
        {           
           
            curTimeout = 0;
            boom++;
            ShootDamage();
            onfire = true;
            ShootAni();
            ammoIn--;
           
        }
        else if (boom >= shot && onfire == true && reload == false)
        {
            boom = 0;
            onfire = false;           
        }
        else if (onfire == true && reload == false)
        {
            ShootDamage();
            boom++;
        }
        else if (ammoIn <= 0 && reloadGo == false)
        {
            reload = true;
            ani.SetTrigger("Reload");            
            StartCoroutine(Reload());
            reloadGo = true;            
        }
       

    }

    void ShootDamage()
    {
       
        #region Damage
       
        
         xRadius = Random.Range(-spreadRadius, spreadRadius);
         yRadius = Random.Range(-spreadRadius, spreadRadius);
         RaycastHit hit;
         Ray ray = _cam.ScreenPointToRay(new Vector3(_cam.pixelWidth * 0.5f + xRadius, _cam.pixelHeight * 0.5f + yRadius, 0));
         if (Physics.Raycast(ray, out hit, 50f))
         {
             Debug.Log(hit.transform.tag);
             if (hit.collider.transform.gameObject.CompareTag("EnemyTurell") || hit.collider.transform.gameObject.CompareTag("EnemyMob") || hit.collider.transform.gameObject.CompareTag("EnemyPlayer"))
             {
                 hit.collider.transform.gameObject.GetComponent<HP>().dmg = dmg;
                 hit.collider.transform.gameObject.GetComponent<HP>().haveDmg = true;
                 checkDeath = hit.collider.transform.gameObject.GetComponent<HP>().hp - hit.collider.transform.gameObject.GetComponent<HP>().factor * dmg;
                 if (checkDeath <= 0)
                 {

                 }
             }
             Rigidbody bulletInstance = Instantiate(bulletEnd, hit.point, Quaternion.identity) as Rigidbody;
         }
            #endregion

        

    }

    private void ShootAni()
    {
        #region Animation
        fire.SetActive(false);
        fire.SetActive(true);
        ani.SetTrigger("Shoot");
        #endregion
    }

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(reloadTime);
        ammoIn = ammo;
        reload = false;
        reloadGo = false;
    }
}
