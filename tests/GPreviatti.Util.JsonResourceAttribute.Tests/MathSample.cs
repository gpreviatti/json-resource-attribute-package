﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPreviatti.Util.JsonResourceAttribute.Tests;

[ExcludeFromCodeCoverage]
sealed class MathSample
{
    public int Sum(int number1, int number2) => number1 + number2;

}
