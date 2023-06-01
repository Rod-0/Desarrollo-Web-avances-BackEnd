namespace LearningCenter.Domain.Test;

public class TesteableDomainUnitTest
{
    [Theory]
    [InlineData(10,20,30)]
    [InlineData(10,100, 110)]
    [InlineData(20,20, 40)]
    public void sum_integerValues_ReturnSum(int numberA,int numberB, int expected)

    {

        //Arrange - setup

        TesteableClass testeableClass = new TesteableClass();



        //Act - exce
    
        int result = testeableClass.sum(numberA, numberB);




        //Assert

        Assert.Equal(result, expected);



    }
}