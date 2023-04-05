using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tardis : MonoBehaviour
{
    public Vector3 teleportVector;
    public Vector3 inFrontOfTheCage;
    public Vector3 cameraDestination;
    public AudioSource sfx;
    public float countdown;
    public float radius;
    public GameManager gm;
    public GameObject victoryText;
    bool used;

    // Start is called before the first frame update
    void Start()
    {
        used = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Interact() {
        if (used) {
            return;
        }
        sfx.Play();
        used = true;
        StartCoroutine(DoctorWho());
    }

    IEnumerator DoctorWho() {
        yield return new WaitForSeconds(5);
        foreach (UnitController unit in gm.units) {
            if (Vector3.Distance(unit.transform.position, transform.position) < radius) {
                unit.transform.position = unit.transform.position + teleportVector;
            }
        }
        transform.position += teleportVector;
        gm.camera.transform.position = cameraDestination;
        if (gm.active != null) {
            gm.active.gameObject.GetComponent<CharacterController>().enabled = false;
            gm.active.transform.position = inFrontOfTheCage;
            gm.active.gameObject.GetComponent<CharacterController>().enabled = true;
        }
        victoryText.SetActive(true);
    }

}
