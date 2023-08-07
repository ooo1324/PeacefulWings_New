using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBlock : MonoBehaviour
{
    public GameObject bulletObj;
    public float bulletDelaySec;

    public Transform initPos;

    private bool activeShot = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Shot());
    }

    IEnumerator Shot()
    {
        while (activeShot)
        {
            Instantiate(bulletObj, initPos);
            yield return new WaitForSeconds(bulletDelaySec);
        }
      
    }
}
