﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

internal class CharacterEvents
{
    public static UnityAction<GameObject, int> CharacterDamaged;
    public static UnityAction<GameObject, int> CharacterHealed;
}
