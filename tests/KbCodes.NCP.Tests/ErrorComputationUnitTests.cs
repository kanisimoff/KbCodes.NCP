using Xunit;
using static System.Math;

namespace KbCodes.NCP.Tests
{
    public class ErrorComputationUnitTests
    {
        [Fact]
        public void Compute_AbsoluteError()
        {
            // arrange
            var xe = 10.1;
            var xa = 9.1;

            // act
            var ea = ErrorComputation.Ea<double>(xe, xa);

            // assert
            Assert.Equal(1, ea);
            Assert.IsType<double>(ea);
        }

        [Fact]
        public void Return_AbsoluteError_DifferentType()
        {
            // arrange
            int xe = 10;
            int xa = 9;

            // act
            var ea = ErrorComputation.Ea<double>(xe, xa);

            // assert
            Assert.Equal(1, ea);
            Assert.IsType<double>(ea);
        }

        [Fact]
        public void Compute_RelativeError()
        {
            // arrange
            var xe = 10.0;
            var xa = 5.0;

            // act
            var er = ErrorComputation.Er<double>(xe, xa);

            // assert
            Assert.Equal(0.5, er);
            Assert.IsType<double>(er);
        }

        [Fact]
        public void Return_RelativeError_DifferentType()
        {
            // arrange
            int xe = 10;
            int xa = 5;

            // act
            var er = ErrorComputation.Er<double>(xe, xa);

            // assert
            Assert.Equal(0.5, er);
            Assert.IsType<double>(er);
        }

        #region Tests for PercentageRelativeError
        [Fact]
        public void Compute_PercentageRelativeError()
        {
            // arrange
            var xe = 10.0;
            var xa = 5.0;

            // act
            var ep = ErrorComputation.Ep<double>(xe, xa);

            // assert
            Assert.Equal(50, ep);
            Assert.IsType<double>(ep);
        }

        [Fact]
        public void Return_PercentageRelativeError_DifferentType()
        {
            // arrange
            int xe = 10;
            int xa = 5;

            // act
            var ep = ErrorComputation.Ep<double>(xe, xa);

            // assert
            Assert.Equal(50, ep);
            Assert.IsType<double>(ep);
        }

        [Fact]
        public void Return_NotFrationType_PercentageRelativeError_For_Double()
        {
            // arrange
            double xe = 10.1;
            double xa = 5.1;

            // act
            var ep = ErrorComputation.Ep<int>(xe, xa);

            // assert
            Assert.Equal(50, ep);
            Assert.IsType<int>(ep);
        }

        [Fact]
        public void Return_Decimal_PercentageRelativeError()
        {
            // arrange
            decimal xe = 10;
            decimal xa = 5;

            // act
            var ep = ErrorComputation.Ep<decimal>(xe, xa);

            // assert
            Assert.Equal(Abs((xe - xa) / xe) * 100, ep);
            Assert.IsType<decimal>(ep);
        }

        [Fact]
        public void Return_Double_PercentageRelativeError()
        {
            // arrange
            double xe = 10.1;
            double xa = 5.1;

            // act
            var ep = ErrorComputation.Ep<double>(xe, xa);

            // assert
            Assert.Equal(Abs((xe - xa) / xe) * 100, ep);
            Assert.IsType<double>(ep);
        }


        [Fact]
        public void Return_PercentageRelativeError_NotFrationType()
        {
            // arrange
            float xe = 10f;
            float xa = 5f;

            // act
            var ep = ErrorComputation.Ep<int>(xe, xa);

            // assert
            Assert.Equal(50, ep);
            Assert.IsType<int>(ep);
        }
        #endregion

    }
}
