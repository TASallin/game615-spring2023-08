using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreCage : MonoBehaviour
{
    public GameObject ogre;
    public Hitbox hitbox;
    public Renderer rend;
    public Collider col;
    bool unleashed;
    public GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        unleashed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (unleashed) {
            if (gm.active != null) {
                ogre.transform.LookAt(gm.active.transform);
                ogre.transform.Translate(ogre.transform.forward * Time.deltaTime * 15);
            }
        }
    }

    public void Break() {
        rend.enabled = false;
        col.enabled = false;
        unleashed = true;
        hitbox.active = true;
        ogre.GetComponent<Rigidbody>().isKinematic = false;
    }
}
