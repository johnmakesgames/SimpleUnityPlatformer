using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorController : MonoBehaviour
{
    List<EnemyBehavior> behaviors;
    List<EnemyBehavior> activeBehaviors;
    List<EnemyBehavior> removedBehaviors;

    // Start is called before the first frame update
    void Start()
    {
        activeBehaviors = new List<EnemyBehavior>();
        removedBehaviors = new List<EnemyBehavior>();

        // For some reason Getcomponents is only returning one of the components wtf
        var r = this.GetComponents(typeof(EnemyBehavior));
        var result = this.GetComponents<EnemyBehavior>();
        behaviors = new List<EnemyBehavior>(result);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var behaviour in behaviors)
        {
            if (behaviour.CanEnterBehavior())
            {
                if (!activeBehaviors.Contains(behaviour))
                {
                    activeBehaviors.Add(behaviour);
                    behaviour.EnterState();
                }
            }
            else
            {
                if (activeBehaviors.Remove(behaviour))
                {
                    removedBehaviors.Add(behaviour);
                }
            }
        }

        foreach (var behaviour in removedBehaviors)
        {
            behaviour.ExitState();
        }

        removedBehaviors.Clear();

        foreach (var behaviour in activeBehaviors)
        {
            behaviour.Act();
        }
    }
}
