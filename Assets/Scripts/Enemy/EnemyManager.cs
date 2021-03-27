using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


//Playerを追跡

public class EnemyManager : MonoBehaviour
{
    public Transform target;
    NavMeshAgent agent;
    Animator animator;
    public Collider weaponCollider;
    public EnemyUIManager enemyUIManager;
    public GameObject gameClearText;
    public int maxHp = 100;
    int hp = 100;

    void Start()
    {
        hp = maxHp;
        enemyUIManager.Init(this);

        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.destination = target.position;
        HideColliderWeapon();
    }


    void Update()
    {
        agent.destination = target.position;
        animator.SetFloat("Distance", agent.remainingDistance);
        
    }

    public void LookAtTarget() {
        //Playerの方向を向く
        transform.LookAt(target);
    }


    //武器の判定を有効・無効にする
    public void HideColliderWeapon() {

        weaponCollider.enabled = false;
    }

    public void ShowColliderWeapon() {

        weaponCollider.enabled = true;
    }

    void Damage(int damage) {

        hp -= damage;
        if (hp <= 0) {
            hp = 0;
            animator.SetTrigger("Die");
            Destroy(gameObject, 2f);
            gameClearText.SetActive(true);
        }
        enemyUIManager.UpdateHP(hp);
        Debug.Log("Enemy残りHP：" + hp);
    }

    private void OnTriggerEnter(Collider other) {

        //ダメージを与えるものにぶつかったら
        Damager damager = other.GetComponent<Damager>();
        if (damager != null) {
            Debug.Log("Enemyはダメージを受ける");
            animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }
    }
}
