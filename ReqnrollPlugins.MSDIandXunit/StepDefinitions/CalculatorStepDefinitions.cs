using CalculatorApp;
using FluentAssertions;
using Xunit.Abstractions;

namespace ReqnrollPlugins.MSDIandXunit.StepDefinitions;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private readonly ICalculator _calculator;
    private readonly ITestOutputHelper _outputHelper;

    public CalculatorStepDefinitions(ICalculator calculator, ITestOutputHelper testOutputHelper)
    {
        _calculator = calculator;
        _outputHelper = testOutputHelper;
        _calculator.HasResult.Should().BeFalse();
    }

    [Given("the first number is {int}")]
    public void GivenTheFirstNumberIs(int number)
    {
        _calculator.Reset();
        _calculator.Enter(number);
    }

    [Given("the second number is {int}")]
    public void GivenTheSecondNumberIs(int number)
    {
        _calculator.Enter(number);
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        _outputHelper.WriteLine("Add invoked");
        _calculator.Add();
    }

    [When("the two numbers are multiplied")]
    public void WhenTheTwoNumbersAreMultiplied()
    {
        _outputHelper.WriteLine("Multiply invoked");
        _calculator.Multiply();
    }

    [Then("the result should be {int}")]
    public void ThenTheResultShouldBe(int result)
    {
        result.Should().Be( _calculator.GetResult());
    }
}
