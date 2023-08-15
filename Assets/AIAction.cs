using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    /// <summary>
    /// Runs on Update of <see cref="AIController"/>
    /// </summary>
    void Execute();
    /// <summary>
    /// Flags when an action is complete.
    /// </summary>
    /// <returns></returns>
    bool IsActionComplete();
}
