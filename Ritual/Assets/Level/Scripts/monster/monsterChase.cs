using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterChase : MonoBehaviour
{
    public Rigidbody monsRigid;
    public Transform monsTrans, playTrans;
    public bool Pills = false;
    public int monSpeed;

    void FixedUpdate()
    {
        if (!Pills)
        {

            monsRigid.velocity = transform.forward * monSpeed * Time.deltaTime;
        }
    }

    private void Update()
    {
        monsTrans.LookAt(playTrans);
    }
}
