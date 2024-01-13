using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Boss1_Health : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;

    public int enemyhealth;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Boss1Hit(int damage)
    {
        enemyhealth -= damage;

        if (enemyhealth <= 0) // 적 사망
        {
            anim.SetTrigger("Die");
            gameObject.layer = 14;

            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.tag = "Boss1_Death";
            Invoke("Potal", 5);
        }
        else // 적 피격
        {
            // anim.SetTrigger("Damaged");
            spriteRenderer.color = new Color(1, 1, 1, 0.4f);
            Invoke("OffDamaged", 0.5f);
        }

        if (enemyhealth <= 5)
        {
            anim.SetBool("isRage", true);
        }
    }
    public void OffDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }

    public void Potal() // 보스가 죽으면 그 자리에 포탈을 소환
    {
        GameObject scenePotal = GameObject.FindGameObjectWithTag("ScenePotal");
        Transform scenePotaltransform = scenePotal.transform;
        GameObject boss1Death = GameObject.FindGameObjectWithTag("Boss1_Death");
        Transform boss1Deathtransform = boss1Death.transform;

        scenePotaltransform.position = boss1Deathtransform.position;
    }
   
}
