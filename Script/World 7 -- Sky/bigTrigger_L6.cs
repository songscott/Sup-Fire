﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigTrigger_L6 : MonoBehaviour {

    private GameObject target;
	
	void FixedUpdate () {
        transform.Translate(new Vector3(0f, -0.02f, 0f));
	}
    void got(GameObject target)
    {
        Collider capCo = GetComponent<Collider>();
        capCo.enabled = false;
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
            bulletMove_L6 bullet = other.GetComponent<bulletMove_L6>();
            target = bullet.comeFrom;
            target.SendMessage("SetBig");
            got(target);

        }
        else if (other.tag == "Missile")
        {
            MissileMove_L6 missile = other.GetComponent<MissileMove_L6>();
            target = missile.comeFrom;
            target.SendMessage("SetBig");
            got(target);

        }
        else if (other.tag == "Player")
        {
            other.transform.parent.SendMessage("SetBig");
            Destroy(gameObject);
        }
    }
}
