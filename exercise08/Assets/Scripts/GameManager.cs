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
            active.cc.Move(new Vector3(-1 * horiz, 0, -1 * vert) * active.moveSpeed * Time.deltaTime);
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

    }
}
