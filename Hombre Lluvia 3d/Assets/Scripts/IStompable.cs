using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStompable 
{
    void Stomped(Collider stomper, bool drop);
}
