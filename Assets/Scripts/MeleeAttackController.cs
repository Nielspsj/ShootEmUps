using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackController : MonoBehaviour
{
    //vTest1: Input to attack
    //vTest2: Attacak method that activates the trigger area.
    //vTest3: Timer to disable the trigger area
    public GameObject meleeTriggerArea;
    private bool isAttacking = false;
    private float attackDuration = 0.3f;
    private float attackTimer = 0f;
        
    // Update is called once per frame
    void Update()
    {
        CheckMeleetimer();
        if (Input.GetMouseButton(1))
        {
            //Debug.Log("right mouse button");
            //Attack
            OnAttack();
        }
    }
    
    //Enable the melee trigger area.
    private void OnAttack()
    {
        if (isAttacking == false)
        {
            meleeTriggerArea.SetActive(true);
            isAttacking = true;
            //Play animation
        }
    }
    //Timer starts when attacking starts.
    //For the duration the hitbox trigger area is enabled. Then it disables.
    private void CheckMeleetimer()
    {
        if (isAttacking == true)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                attackTimer = 0f;
                isAttacking = false;
                meleeTriggerArea.SetActive(false);
            }
        }
    }
}
