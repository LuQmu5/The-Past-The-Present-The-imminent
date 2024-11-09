using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public bool IsFiring { get; private set; }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            IsFiring = true;
        }
        else
        {
            IsFiring = false;
        }
    }
}