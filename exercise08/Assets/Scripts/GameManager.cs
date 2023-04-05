using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public UnitController active;
    public List<UnitController> units;
    public TMP_Text nameDisplay;
    public TMP_Text hpDisplay;
    public GameObject door;
    public GameObject tardis;
    public Transform camera;
    const float GRAVITY = -9.8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        if (active != null) {
            active.cc.Move(new Vector3(-1 * horiz, GRAVITY, -1 * vert) * active.moveSpeed * Time.deltaTime);
            float bearing = 0;
            if (vert > 0.1f) {
                bearing = 180;
            }
            if (horiz > 0.1f) {
                if (Mathf.Abs(vert) < 0.1f) {
                    bearing -= 90;
                } else if (vert < 0) {
                    bearing -= 45;
                } else {
                    bearing += 45;
                }
            } else if (horiz < -0.1f) {
                if (Mathf.Abs(vert) < 0.1f) {
                    bearing += 90;
                } else if (vert < 0) {
                    bearing += 45;
                } else {
                    bearing -= 45;
                }
            }
            if (Mathf.Abs(horiz) + Mathf.Abs(vert) > 0.1f) {
                active.transform.rotation = Quaternion.Euler(0, bearing, 0);
            }
        } else {
            camera.Translate(new Vector3(-1 * horiz, 0, -1 * vert) * Time.deltaTime * 5, Space.World);
        }
    }

    public void UpdateUI() {
        if (active != null) {
            nameDisplay.text = active.name;
            hpDisplay.text = active.hp + " HP";
            if (active.hp <= 0) {
                active.selected = false;
                active = null;
            }
        }
        
    }

    public void Select(UnitController choice) {
        if (choice == active) {
            return;
        }
        foreach (UnitController u in units) {
            u.Deselect();
        }
        choice.Select();
        active = choice;
        nameDisplay.text = choice.name;
        hpDisplay.text = choice.hp + " HP";
    }

    public void AttackButton() {
        active.Attack();
    }

    public void InteractButton() {
        if (Vector3.Distance(door.transform.position, active.transform.position) < 4f) {
            door.SetActive(false);
        }

        if (Vector3.Distance(tardis.transform.position, active.transform.position) < 4f) {
            tardis.GetComponent<Tardis>().Interact();
        }
    }

    public void CancelButton() {
        if (active != null) {
            active.Deselect();

            active = null;
            nameDisplay.text = "";
            hpDisplay.text = "";
        }
    }
}
