using Domain;
using Infraestructure.Models;
using LearningCenter.Infraestructure.Interfaces;
using Moq;

namespace LearningCenter.Domain.Test;

public class TutorialDomainUnitTest
{
    [Fact]
 
    public void Create_ValidTutorial_ReturnSucces()

    {
        //Arrage

        Tutorial tutorial = new Tutorial()
        {
            Name = "Tutorial 1"
        };

        var mockTutorialInfraestructure = new Mock<ITutorialInfraestructure>(); //se crea un falso objeto
        mockTutorialInfraestructure.Setup(t => t.CreateAsync(tutorial)).ReturnsAsync(true); //mockeo la funcion que voy a mezclar
        TutorialDomain tutorialDomain = new TutorialDomain(mockTutorialInfraestructure.Object);

        //Act
        var returnValue = tutorialDomain.CreateAsync(tutorial);

        //Assert
        Assert.True(returnValue.Result);
    }

    [Fact]

    public void Create_InvalidTutorial_ReturnError()

    {
        //Arrage

        Tutorial tutorial = new Tutorial()
        {
            Name = "Tutorial 1"
        };

        var mockTutorialInfraestructure = new Mock<ITutorialInfraestructure>(); //se crea un falso objeto
        mockTutorialInfraestructure.Setup(t => t.CreateAsync(tutorial)).ReturnsAsync(false); //mockeo la funcion que voy a mezclar
        TutorialDomain tutorialDomain = new TutorialDomain(mockTutorialInfraestructure.Object);

        //Act
        var returnValue = tutorialDomain.CreateAsync(tutorial);

        //Assert
        Assert.False(returnValue.Result);
    }

    [Fact]

    public void Create_InvalidTutorial_ReturnException()

    {
        //Arrage

        Tutorial tutorial = new Tutorial()
        {
            Name = "T"
        };

        var mockTutorialInfraestructure = new Mock<ITutorialInfraestructure>(); //se crea un falso objeto
        mockTutorialInfraestructure.Setup(t => t.CreateAsync(tutorial)).ReturnsAsync(false); //mockeo la funcion que voy a mezclar
        TutorialDomain tutorialDomain = new TutorialDomain(mockTutorialInfraestructure.Object);

        //Act
        //var returnValue = tutorialDomain.Create(tutorial);

        //Assert
        var ex = Assert.ThrowsAsync<Exception>(() => tutorialDomain.CreateAsync(tutorial));
        
        Assert.Equal("less than 3 char", ex.Result.Message);
    }
}




