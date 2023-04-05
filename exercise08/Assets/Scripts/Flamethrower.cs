using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : SpecialAttack
{
    bool offCooldown;
    public GameObject fireball;
    Vector3 fireballStartingPosition;
    public float forwardForce;
    public float upwardForce;
    public Hitbox hitbox;

    // Start is called before the first frame update
    void Start() {
        offCooldown = true;
        fireballStartingPosition = fireball.transform.localPosition;
    }

    // Update is called once per frame
    void Update() {

    }

    public override void Attack() {
        if (offCooldown) {
            offCooldown = false;
            StartCoroutine(ThrowFireball());
        }
    }

    IEnumerator ThrowFireball() {
        yield return new WaitForSeconds(1);
        fireball.SetActive(true);
        fireball.transform.parent = null;
        fireball.GetComponent<Rigidbody>().isKinematic = false;
        fireball.GetComponent<Rigidbody>().AddForce(transform.forward * forwardForce);
        fireball.GetComponent<Rigidbody>().AddForce(transform.up * upwardForce);
        yield return new WaitForSeconds(.2f);
        hitbox.active = true;
        yield return new WaitForSeconds(5.8f);
        fireball.transform.parent = transform;
        fireball.transform.localPosition = fireballStartingPosition;
        fireball.GetComponent<Rigidbody>().isKinematic = true;
        hitbox.active = false;
        fireball.SetActive(false);
        offCooldown = true;
    }
}
