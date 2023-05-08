using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Chase : MonoBehaviour
{
    Transform player;
    Rigidbody2D rb;

    BossBehavior bossBehavior;
    
    // Start is called before the first frame update

    override public void OnStateEnter(Animator animator,AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("player").Transform;

        rb = animator.GetComponent<Rigidbody2D>();

        bossBehavior = animator.GetComponent<bossBehavior>();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 Target = new Vector2(player.position.x, rb.position.y);

        Vector2 newPos = Vector2.MoveTowards(rb.position, Target, bossBehavior.speed * Time.deltaTime);

        rb.MovePosition(newPos);

        float distance = Vector2.Distance(player.position, rb.position);

        if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && !bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("MeleeAttack");
        }
        else if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && bossBehavior.phase3 &&!bossBehavior.isDead)
        {
            animator.SetTrigger("Phase2Attack");
        }
        else if (distance < bossBehavior.attackRange && !bossBehavior.phase2 && bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("phase3Attack");
        }
        else if (bossBehavior.isDead)
        {
            animator.SetTrigger("Death");
        }
    }
     override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
   
}
