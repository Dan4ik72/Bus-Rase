﻿using UnityEngine;

public interface IMoveHandler
{
    void Move(Vector3 direction, float deltaTime = 1);
}
