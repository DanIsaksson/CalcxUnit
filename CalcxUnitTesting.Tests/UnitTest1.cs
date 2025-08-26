﻿using System;
using Methods;

namespace Calculator.Tests;

public class CalcMethodTests
{
    [Fact]
    public void Division_ValidNumbers_ReturnsCorrectResult()
    {
        // Sets up two testing variables I can use to test the logic in line 17+18.
        double dividend = 10; // THe number we divide
        double divisor = 2; // The number we divide by

        double expected = 5;

        // Calls on Division(x,y) method and stores value in "result".
        double result = CalcMethods.Division(dividend, divisor);
        // Assert is an xUnit test framework method. Inside its .Equal() 
        // method, I compare the "expected" result to the actual "result".
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Division_DivideByZero_ThrowsException()
    {
        // Sets up two testing variables I can use to test the logic in line 32.
        double dividend = 10;
        double divisor = 0;

        // Verify that calling Division with zero divisor throws DivideByZeroException
        // The () => expression captures any exception thrown
        Assert.Throws<DivideByZeroException>(() => CalcMethods.Division(dividend, divisor));
    }
}
