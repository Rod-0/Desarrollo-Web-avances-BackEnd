using Domain;
using Infraestructure;
using Infraestructure.Models;
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
        mockTutorialInfraestructure.Setup(t => t.Create(tutorial)).Returns(true); //mockeo la funcion que voy a mezclar
        TutorialDomain tutorialDomain = new TutorialDomain(mockTutorialInfraestructure.Object);

        //Act
        var returnValue = tutorialDomain.Create(tutorial);

        //Assert
        Assert.True(returnValue);
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
        mockTutorialInfraestructure.Setup(t => t.Create(tutorial)).Returns(false); //mockeo la funcion que voy a mezclar
        TutorialDomain tutorialDomain = new TutorialDomain(mockTutorialInfraestructure.Object);

        //Act
        var returnValue = tutorialDomain.Create(tutorial);

        //Assert
        Assert.False(returnValue);
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
        mockTutorialInfraestructure.Setup(t => t.Create(tutorial)).Returns(false); //mockeo la funcion que voy a mezclar
        TutorialDomain tutorialDomain = new TutorialDomain(mockTutorialInfraestructure.Object);

        //Act
        //var returnValue = tutorialDomain.Create(tutorial);

        //Assert
        var ex = Assert.Throws<Exception>(() => tutorialDomain.Create(tutorial));
        
        Assert.Equal("less than 3 char", ex.Message);
    }
}




