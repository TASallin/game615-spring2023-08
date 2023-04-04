using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public string name;
    public int hp;
    public SpecialAttack attack;
    public bool selected = false;
    public CharacterController cc;
    public float moveSpeed;
    public GameObject marker;
    public GameObject selectParticles;
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        //defaultColor = bodyRend.material.color;

        GameObject gmObj = GameObject.Find("GameManager");
        gm = gmObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter() {
        if (hp > 0) {
            selectParticles.SetActive(true);
        }
      
    }

    private void OnMouseExit() {
        if (hp > 0) {
            selectParticles.SetActive(false);
        }
      
    }

    private void OnMouseDown() {
        if (hp > 0) {
            gm.Select(this);
        }
        
        /*
        if (gm.selectedUnit != null) {
            // if we're here, something was already selected!
            // 1. Deselect it
            gm.selectedUnit.selected = false;
            gm.selectedUnit.bodyRend.material.color = gm.selectedUnit.defaultColor;
        }
        // 2. Select me!
        selected = true;
        bodyRend.material.color = selectedColor;

        if (gm.selectedUnit == null) {
            gm.namePanelAnimator.SetTrigger("fadeIn");
        }

        gm.selectedUnit = this;
        gm.nameText.text = unitName;
        */
    }

    public void Attack() {
        attack.Attack();
    }

    public void Select() {
        marker.SetActive(true);
        selected = true;
    }

    public void Deselect() {
        marker.SetActive(false);
        selected = false;
    }

    public void Damage(int amount) {
        hp -= amount;
        if (hp <= 0) {
            hp = 0;
            transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }
}
