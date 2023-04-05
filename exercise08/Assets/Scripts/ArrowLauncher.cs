using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowLauncher : MonoBehaviour
{
    bool offCooldown;
    public Vector3 arrowPosition;
    public float sightRadius;
    public GameManager gm;
    public GameObject arrow;
    public float shootingForce;
    public AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        offCooldown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (offCooldown && gm.active != null && Vector3.Distance(arrowPosition, gm.active.transform.position) < sightRadius) {
            StartCoroutine(Shoot());
        }
    }

    IEnumerator Shoot() {
        offCooldown = false;
        GameObject a = Instantiate(arrow, arrowPosition, Quaternion.identity);
        a.transform.LookAt(gm.active.transform.position + new Vector3(0, 2, 0));
        a.GetComponent<Rigidbody>().AddForce(a.transform.forward * shootingForce);
        sfx.Play();
        yield return new WaitForSeconds(3);
        Destroy(a);
        yield return new WaitForSeconds(2);
        offCooldown = true;
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Unit")) {
            Destroy(gameObject);
        }
    }
}
