using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : SpecialAttack
{
    bool offCooldown;
    public GameObject rope;
    Vector3 ropeStartingPosition;
    public float forwardForce;
    public float upwardForce;
    public Hitbox hitbox;
    Quaternion startingRotation;

    // Start is called before the first frame update
    void Start() {
        offCooldown = true;
        ropeStartingPosition = rope.transform.localPosition;
        startingRotation = rope.transform.localRotation;
    }

    // Update is called once per frame
    void Update() {
    }

    public override void Attack() {
        if (offCooldown) {
            offCooldown = false;
            StartCoroutine(ThrowRope());
        }
    }

    IEnumerator ThrowRope() {
        yield return new WaitForSeconds(2);
        rope.transform.parent = null;
        rope.GetComponent<Rigidbody>().isKinematic = false;
        rope.GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce);
        rope.GetComponent<Rigidbody>().AddForce(transform.up * upwardForce);
        yield return new WaitForSeconds(.1f);
        hitbox.active = true;
        yield return new WaitForSeconds(5);
        rope.transform.parent = transform;
        rope.transform.localPosition = ropeStartingPosition;
        rope.transform.localRotation = startingRotation;
        rope.GetComponent<Rigidbody>().isKinematic = true;
        hitbox.active = false;
        offCooldown = true;
    }
}
