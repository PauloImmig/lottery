using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class LuckNumbers : List<int>
{
    public override string ToString()
    {
        return string.Join(", ", this);
    }
}