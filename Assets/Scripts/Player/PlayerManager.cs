using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    float x;
    float z;
    public float moveSpeed;
    public Collider weaponCollider;
    public PlayerUIManager PlayerUIManager;
    public GameObject gameOverText;
    public int maxHp = 10;
    int hp;
    bool isDie;

    Rigidbody rb;
    Animator animator;
    
    void Start()
    {
        if (isDie) {
            return;
        }

        hp = maxHp;
        PlayerUIManager.Init(this);
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        HideColliderWeapon();
    }

    
    void Update()
    {
        //キーボードで移動
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        //攻撃入力
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetTrigger("Attack");
        }
        
    }

    private void FixedUpdate() {

        if (isDie) {
            return;
        }

        //Playerの方向転換
        Vector3 direction = transform.position + new Vector3(x, 0, z) * moveSpeed;
        transform.LookAt(direction);
        //速度設定
        rb.velocity = new Vector3(x, 0, z) * moveSpeed;
        animator.SetFloat("Speed", rb.velocity.magnitude);

        
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
            isDie = true;
            animator.SetTrigger("Die");
            gameOverText.SetActive(true);
        }
        PlayerUIManager.UpdateHP(hp);
        Debug.Log("Player残りHP：" + hp);
    }

    private void OnTriggerEnter(Collider other) {

        if (isDie) {
            return;
        }

        Damager damager = other.GetComponent<Damager>();
        if (damager != null) {

            //ダメージを与えるものにぶつかったら
            
            animator.SetTrigger("Hurt");
            Damage(damager.damage);
        }

    }
}
