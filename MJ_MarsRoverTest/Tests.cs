using System;
using MaximJoseau_MarsRover;
using MaximJoseau_MarsRover.Ressources;
using Xunit;

namespace MaximJoseau_MarsRoverTest
{
  public class Tests
  {
    [Fact]
    public void RotationUneCommande()
    {
      Rover rover = new Rover();
      rover.Deplacement("L");
      Assert.Equal(Rover.Direction.W, rover.DirectionRover);
    }

    [Fact]
    public void RotationMultiCommande()
    {
      Rover rover2 = new Rover();
      rover2.Deplacement("RRLR");
      Assert.Equal(Rover.Direction.S, rover2.DirectionRover);
    }
    
    [Fact]
    public void TourDuMonde()
    {
      Rover rover3 = new Rover();
      rover3.RoverX = 4;
      rover3.Deplacement("FFFFF");
      Assert.Equal(9,rover3.RoverX);
    }
  }
}
