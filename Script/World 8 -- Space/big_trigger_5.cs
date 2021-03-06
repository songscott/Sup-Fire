﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class big_trigger_5 : MonoBehaviour {

    private GameObject target;

    void FixedUpdate()
    {
      //  transform.Translate(new Vector3(0f, -0.02f, 0f));
    }
    void got(GameObject target)
    {
        Collider capCo = GetComponent<Collider>();
        //capCo.enabled = false;
        Destroy(gameObject, 0.5f);
        Rigidbody rigid = GetComponent<Rigidbody>();
        rigid.AddForce((-transform.position + target.transform.position) * 50f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall")
        {
            Destroy(gameObject);
        }
        else if (other.tag == "Bullet")
        {
            BulletMove_Planet bullet = other.GetComponent<BulletMove_Planet>();
            target = bullet.comeFrom;
            target.SendMessage("SetBig");
            got(target);

        }
        else if (other.tag == "Missile")
        {
            MissileMove_Planet missile = other.GetComponent<MissileMove_Planet>();
            target = missile.comeFrom;
            target.SendMessage("SetBig");
            got(target);

        }

    }
}
