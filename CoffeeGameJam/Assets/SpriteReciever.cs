using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnnoyingClassNames
{

    public class SpriteReciever : MonoBehaviour
    {
        SpriteRenderer spriteRenderer;
        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            UsableObjectBucket.onUsedAction += RecieveSprite;
        }

        void RecieveSprite(Sprite sprite)
        {
            //Debug.Log("Sprite Recieved");

            spriteRenderer.sprite = sprite;
        }

        private void OnDestroy() =>            UsableObjectBucket.onUsedAction -= RecieveSprite;
        private void OnDisable() => UsableObjectBucket.onUsedAction -= RecieveSprite;


    }
}
