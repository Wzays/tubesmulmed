using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{


    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Movement parameters")]
    [SerializeField] private float speed;
    private Vector3 initscale;
    private bool movingleft;

    [Header("Idle Behaviour")]
    [SerializeField] private float IdleDuration;
    private float IdleTimer;

    [Header("Enenmy Animator")]
    [SerializeField] private Animator anim;
    private void Awake()
    {
        initscale = enemy.localScale;
    }

    private void Update()
    {
        if (movingleft)
        {
          
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
            {
                DirectionCharge();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
            {
                DirectionCharge();
            }
        }

    }
    private void DirectionCharge()
    {
        anim.SetBool("isRunning", false);
        IdleTimer += Time.deltaTime;
        if (IdleTimer > IdleDuration)
            movingleft = !movingleft;
    }


    private void MoveInDirection(int _direction)
    {
        IdleTimer = 0;
        anim.SetBool("isRunning", true);
        //make enemy face direction
        enemy.localScale = new Vector3(Mathf.Abs(initscale.x) * _direction, initscale.y, initscale.z);
        //move in that direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);
    }
  
}
