using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hatchet : SpecialAttack
{
    bool offCooldown;
    public GameObject hatchet;
    Vector3 hatchetStartingPosition;
    public float forwardForce;
    public float upwardForce;
    public Hitbox hitbox;
    Quaternion startingRotation;

    // Start is called before the first frame update
    void Start()
    {
        offCooldown = true;
        hatchetStartingPosition = hatchet.transform.localPosition;
        startingRotation = hatchet.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack() {
        if (offCooldown) {
            offCooldown = false;
            StartCoroutine(ThrowHatchet());
        }
    }

    IEnumerator ThrowHatchet() {
        yield return new WaitForSeconds(1.6f);
        hatchet.transform.parent = null;
        hatchet.GetComponent<Rigidbody>().isKinematic = false;
        hatchet.GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce);
        hatchet.GetComponent<Rigidbody>().AddForce(transform.up * upwardForce);
        yield return new WaitForSeconds(0.01f);
        hitbox.active = true;
        yield return new WaitForSeconds(5);
        hatchet.transform.parent = transform;
        hatchet.transform.localPosition = hatchetStartingPosition;
        hatchet.transform.localRotation = startingRotation;
        hatchet.GetComponent<Rigidbody>().isKinematic = true;
        hitbox.active = false;
        offCooldown = true;
    }
}
