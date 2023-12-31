using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CoffeeJam.Visuals
{
    public enum CharacterStates
    {
        Idle,
        WalkingUp,
        WalkingDown,
        AttackDown,
        AttackDown2,
        AttackDown3,
        AttackUp,
        AttackUp2,
        AttackUp3,
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
        [SerializeField] int maxAttacks;
        bool Up;
        [SerializeField] CharacterStates state = CharacterStates.Count;

        // Update is called once per frame
        private void Update()
        {
            CharacterStates newState = FindState();

            if (newState >= CharacterStates.AttackDown && newState <= CharacterStates.AttackUp3)
            {
                float finalTime = (Time.time - AttackstartTime) / attackFrames/*player.attackFrames*/;
                thisAnimator.Play((state = newState).ToString(), 0, finalTime);

                return;
            }
            // if (thisAnimator.HasState(0, newState.ToString()))
                thisAnimator.Play((state = newState).ToString(), 0);


        }

        CharacterStates FindState()
        {

            if (state == CharacterStates.Hitstun || state == CharacterStates.Death || 
                (state >= CharacterStates.AttackDown && state <= CharacterStates.AttackUp3))
                return state;


            CharacterStates newState = CharacterStates.Idle;


            if (Vector3.Distance(prevPos,transform.position) > .01f)
            {
                if (transform.position.x > prevPos.x)
                    transform.localScale = new Vector3(originalScale.x * -1, originalScale.y, originalScale.z);
                else if (transform.position.x < prevPos.x)
                    transform.localScale = originalScale;

                if (prevPos.y < transform.position.y)
                {
                    newState = CharacterStates.WalkingUp;
                    Up = true;
                }
                else
                {
                    newState = CharacterStates.WalkingDown;
                    Up = false;
                }

                prevPos = transform.position;
            }

            return newState;
        }

        float AttackstartTime;
        float attackFrames;

        public void StartAttack(EntityState prevState)
        {
            if (Up)
                state = CharacterStates.AttackUp + (attackNumber < maxAttacks ? attackNumber : attackNumber = 0);
            else
                state = CharacterStates.AttackDown + (attackNumber < maxAttacks ? attackNumber : attackNumber = 0);

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
