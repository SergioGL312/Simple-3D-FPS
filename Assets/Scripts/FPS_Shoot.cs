using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Shoot : MonoBehaviour
{
    public Transform cam;
    public LayerMask whatCanShoot;

    public Transform firePoint;
    public GameObject bulletPrefab;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Vector3 hitPos;

        RaycastHit hit;
        if (Physics.Raycast(cam.position, cam.forward, out hit, Mathf.Infinity, whatCanShoot))
        {
            hitPos = hit.point;
        }
        else
        {
            hitPos = cam.transform.position + cam.forward * 1000;
     
        }

        Vector3 direction = hitPos - firePoint.position;

        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = firePoint.position;
        bullet.transform.forward = direction;

        bullet.GetComponent<Rigidbody>().velocity = direction.normalized * 10;
    }
}
