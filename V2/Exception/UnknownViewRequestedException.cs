using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownViewRequestedException : Exception
{
    public override string Message => "Unknown View Requested from View Factory. Please make sure that you are passing a valid enum";
}
