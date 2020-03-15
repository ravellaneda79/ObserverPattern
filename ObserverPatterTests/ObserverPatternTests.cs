using FluentAssertions;
using PoC_ObserverPattern_WeakReference;
using Xunit;

namespace ObserverPatterTests
{
    public class ObserverPatternTests
    {
        [Fact]
        public void GivenAnyObservableBusiness_WhenDoBusinessStuff_ThenObserverGetNotified()
        {
            // Arrange
            var observableBusiness = new BusinessClassObservable();
            var observer = new ConcreteObserver("Observer");

            // Act
            observableBusiness.DoBusinessStuff();

            // Assert
            observableBusiness.ObservableState.Should().Be(observer.ObservableState);
        }
    }
}
