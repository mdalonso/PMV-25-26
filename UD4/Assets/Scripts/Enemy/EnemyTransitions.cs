using UnityEngine;

public class EnemyTransitions : MonoBehaviour
{
    [SerializeField] Animator anim;
    Transform _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }
    bool HasParameter(int paramHash)
    {
        foreach (AnimatorControllerParameter param in anim.parameters)
        {
            if (param.nameHash == paramHash)
            {
                return true;
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        LookUpDown();
    }

    void LookUpDown()
    {
        int upHash = Animator.StringToHash("Up");

        if (HasParameter(upHash))
        {
            if (_player!=null && _player.position.y - gameObject.transform.position.y > 0)
            {
                anim.SetBool(upHash, true);
            }
            else
            {
                anim.SetBool(upHash, false);

            }
        }
    }
}
