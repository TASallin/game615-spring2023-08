using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public bool active;
    public int power;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other) {
        if (active && other.gameObject.tag.Equals("Unit")) {
            other.gameObject.GetComponent<UnitController>().Damage(power);
        } else if (active && other.gameObject.tag.Equals("Destructible")) {
            other.gameObject.GetComponent<OgreCage>().Break();
        }
    }
}
