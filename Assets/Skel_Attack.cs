using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skel_Attack : MonoBehaviour
{
    public int attackDamage = 1;

    public Vector3 attackOffset;
    public float attackRange = 0.5f;
    public LayerMask attackMask;

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);

        // 공격 범위 내에서 휘두르는 타이밍에 피격 함수 실행
        if (gameObject.layer != 14 && colInfo != null)
        {
            colInfo.GetComponent<PlayerMove>().OnDamaged(colInfo.transform.position);
        }
    }

    void OnDrawGizmos()
    {
        // Attack 함수에서 계산한 오버랩 써클의 범위를 Scene 뷰에 그립니다.
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.color = Color.red; // 원하는 색상으로 설정
        Gizmos.DrawWireSphere(pos, attackRange);
    }
}
