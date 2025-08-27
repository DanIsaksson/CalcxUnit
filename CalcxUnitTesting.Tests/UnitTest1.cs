﻿using System;
using Methods;

namespace Calculator.Tests;

public class CalcMethodTests
{
    // ==== IDEAS FOR TESTING ====
    // - Check for really large numbers [Fact]
    // - Addition and Multiplication
    // - Add test for checking if input loop for charOperator works depending on input
    // - Line 61: xUnit test with try, catch for numeric input, write [Fact]
    // ===========================

    // [Theory] test somewhere..? For the switch statement! Assign test data for operator 1, 2, 3, 4 etc.
    [Theory]
    // Parameters: 1 = operator. 2 = num1. 3 = num2. 4 = expected result
    // Every InlineData row is a new test with new parameter values for the method test
    [InlineData('+', 3, 2, 5)]
    [InlineData('-', 3, 2, 1)]
    [InlineData('*', 3, 2, 6)]
    [InlineData('/', 6, 2, 3)]
    // The method applies InlineData-values across its parameters
    public void Operator_MethodValidation(char oper, double num1, double num2, double expected)
    {
        // Applies parameter values to method for check
        double actual = CalcMethods.ApplyOperator(oper, num1, num2);
        // Check that we got what we wanted as we inserted in [3] of InlineData (5, 1, 6, 3)
        Assert.Equal(expected, actual);
    }

    [Theory]
    // The 2 ones below SHOULD return TESTERROR, was result during last test.
    [InlineData('%', "Operator % not supported, use /.")]
    [InlineData('x', "Operator x not supported, use *.")]
    // The 2 checks below should NOT return any TESTERROR
    [InlineData('%', "Operator % not supported.")]
    [InlineData('x', "Operator x not supported.")]
    public void ApplyOperator_InvalidOperator_Throws(char oper, string expectedMessage)
    {

        var ex = Assert.Throws<ArgumentException>(() => CalcMethods.ApplyOperator(oper,1,1));
        Assert.Equal(expectedMessage, ex.Message);
        // Assert.Throws<ArgumentException>(() => CalcMethods.ApplyOperator(oper, 1, 1));
    }


    [Fact]
    public void Division_ValidNumbers_ReturnsCorrectResult()
    {
        // Sets up two testing variables I can use to test the logic in line 17+18.
        double dividend = 10; // The number we divide
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
