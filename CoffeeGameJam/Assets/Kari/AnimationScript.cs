using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeJam.Visuals
{
    public enum CharacterStates
    {
        Idle,
        Walking,
        Attack,
        Attack2,
        Attack3,
        Block,
        Eat,
        Drink,
        Hitstun,
        Death,
        Count
    }

    public enum EnemyStates
    {
        Idle,
        Walking,
        LungeAttack,
        BasicAttack,
        Hitstun,
        Death,
        Count
    }
    public class AnimationScript : MonoBehaviour
    {
        Vector3 originalScale;
        Animator thisAnimator;

        //[SerializeField] Entity player;
        // Start is called before the first frame update
        void Start()
        {
            thisAnimator = GetComponent<Animator>();
            originalScale = transform.localScale;
           
        }

        Vector3 prevPos = new Vector3();

        [SerializeField] int attackNumber;
        [SerializeField] CharacterStates state = CharacterStates.Count;

        // Update is called once per frame
        private void Update()
        {
            CharacterStates newState = FindState();

            if (newState >= CharacterStates.Attack && newState <= CharacterStates.Attack3)
            {
                float finalTime = (Time.time - AttackstartTime) / attackFrames/*player.attackFrames*/;
                thisAnimator.Play((state = newState).ToString(), 0, finalTime);

                return;
            }
            thisAnimator.Play((state = newState).ToString(), 0);


        }

        CharacterStates FindState()
        {

            if (state == CharacterStates.Hitstun || state == CharacterStates.Death || 
                (state >= CharacterStates.Attack && state <= CharacterStates.Attack3))
                return state;


            CharacterStates newState = CharacterStates.Idle;


            if (prevPos != transform.position)
            {
                if (transform.position.x > prevPos.x)
                    transform.localScale = new Vector3(originalScale.x * -1, originalScale.y, originalScale.z);
                else if (transform.position.x < prevPos.x)
                    transform.localScale = originalScale;

                newState = CharacterStates.Walking;
                prevPos = transform.position;
            }

            return newState;
        }

        float AttackstartTime;
        float attackFrames;

        public void StartAttack(EntityState prevState)
        {
            state = CharacterStates.Attack + (attackNumber < 3 ? attackNumber : attackNumber = 0);
            AttackstartTime = Time.time;
            attackFrames = EntityEventTracker.player.attackFrames;
            attackNumber++;
        }

        public void Hitstun() => state = CharacterStates.Hitstun;

        public void Death() => state = CharacterStates.Death;

        public void Neutral()
        {
            prevPos = transform.position;
            state = CharacterStates.Idle;
        }

    }


}
