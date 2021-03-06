﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Push : Projectile {

    [SerializeField] float pushForce = 100f;
    bool directed = false;
    Transform dontPushME;
    public override void MoveTo()
    {
        if (!directed)
        {

            myTrans.LookAt(myTrans.position - heading);

        }
    }
    public override void JustDie()
    {
        Destroy(gameObject);
    }
    public override void OnHit(Collision coll)
    {
        //dont hit on me!
    }

    public void PushZoneInit(Transform myWizard)
    {
        dontPushME = myWizard;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == dontPushME) {/*dont push him please*/ return; }
        if (other.transform.CompareTag("Wizard"))
        {
            //push them
            other.GetComponent<PlayerController>().Knockback((myTrans.position - (heading*2f)) - other.transform.position, -pushForce, 1.0f);

        }
        else if(other.transform.transform.CompareTag("Projectile") || other.transform.transform.CompareTag("MM"))
        {
            //destroy projectile!
            other.GetComponent<Projectile>().JustDie();

        }
        
    }

}
