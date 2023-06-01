namespace LearningCenter.Domain.Test;

public class TesteableDomainUnitTest
{
    [Fact]
    public void Test1()

    {

        //Arrange - setup

        TesteableClass testeableClass = new TesteableClass();



        //Act - exce
    
        int result = testeableClass.sum(10, 20);




        //Assert

        Assert.Equal(result, 30);



    }
}