using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.Interfaces
{
    public interface IOwnable
    {
        GameObject Owner { get; set; }
    }

}
