using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyEntity))]
public class BossAI : enemyAI2
{
    [SerializeField]
    public Projectile Projectile;

    [SerializeField]
    public uint NumProjectiles;

    [SerializeField]
    public float StandStillTimer;

    [SerializeField]
    public float StartupTimeFirePhase;

    [SerializeField]
    public float LungeSpeed;

    [SerializeField]
    public float LungeDistance;

    [SerializeField]
    public int LungeDamage;

    private int NonLungeDamage;

    [SerializeField]
    public float StartupTimeLungePhase;

    private EnemyEntity self;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindFirstObjectByType<PlayerEntity>().gameObject;
        self = GetComponent<EnemyEntity>();
        NonLungeDamage = self.collisionDamage;
        StartCoroutine(AI());
    }

    
    public IEnumerator AI()
    {
        Vector3 direction;
        Vector3 targetPosition;
        float lungeTime = LungeDistance / LungeSpeed;
        float timer;

        while (true)
        {
            yield return new WaitForSeconds(StartupTimeFirePhase);

            for (int i = 0; i < NumProjectiles; i++)
            {
                direction = (player.transform.position - transform.position).normalized;
                Projectile p = Instantiate(Projectile, transform.position, transform.rotation);
                p.Direction = direction;

                yield return new WaitForSeconds(StandStillTimer / (NumProjectiles + 1));
            }

            yield return new WaitForSeconds(StartupTimeLungePhase);
                        
            targetPosition = player.transform.position;

            timer = 0;
            self.collisionDamage = LungeDamage;
            while(timer < lungeTime)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, LungeSpeed * Time.deltaTime);
                timer += Time.deltaTime;

                yield return new WaitForEndOfFrame();
            }
            self.collisionDamage = NonLungeDamage;
        }
    }


}
