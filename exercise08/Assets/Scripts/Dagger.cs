using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dagger : SpecialAttack
{
    bool offCooldown;
    public Hitbox hitbox;
    public Transform model;
    float countdown;
    public float rotationSpeed;
    Quaternion startingRotation;

    // Start is called before the first frame update
    void Start() {
        offCooldown = true;
        startingRotation = model.rotation;
    }

    // Update is called once per frame
    void Update() {
        if (countdown > 0) {
            countdown -= Time.deltaTime;
            model.Rotate(0, 0, Time.deltaTime * rotationSpeed);

            if (countdown <= 0) {
                offCooldown = true;
                model.rotation = startingRotation;
                hitbox.active = false;
            }
        }
    }

    public override void Attack() {
        if (offCooldown) {
            offCooldown = false;
            countdown = 4f;
            hitbox.active = true;
        }
    }
}
