using NSubstitute;
using NUnit.Framework;
using RattrapDev.Scribe.Compose;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using TestScribe.Customer;
using TestScribe.Store;

namespace RattrapDev.Scribe.Tests.Compose
{
    public class CompositionServiceTests
    {
        [Test]
        public void CreateGlossary_generates_glossary_for_aggregateRoot_terms()
        {
            // Arrange
            var fileLoader = Substitute.For<IFileLoader>();
            fileLoader.GetTypesFromAssembly(Arg.Any<string>()).Returns(new List<Type> { typeof(Customer), typeof(Store) });

            var sut = new CompositionService(fileLoader);

            // Act
            var glossary = sut.CreateGlossary("path");

            // Assert
            var customerModule = glossary.Modules.First(m => m.Name == "Customer");
            var aggregateRoot = customerModule.Aggregates.First(a => a.Name.Equals("Customer"));
            aggregateRoot.CommandMethods.Count.ShouldBe(5);
            aggregateRoot.CommandMethods.Any(c => c.Name.Equals("Update Profile")).ShouldBeTrue();
            aggregateRoot.CommandMethods.Any(c => c.Name.Equals("Outside Command")).ShouldBeTrue();
            aggregateRoot.CommandMethods.Any(c => c.Name.Equals("Add Item To Cart")).ShouldBeTrue();
            aggregateRoot.CommandMethods.Any(c => c.Name.Equals("Remove Items From Cart")).ShouldBeTrue();
            aggregateRoot.CommandMethods.Any(c => c.Name.Equals("Checkout")).ShouldBeTrue();
            var commandMethod = aggregateRoot.CommandMethods.First(c => c.Name.Equals("Checkout"));
            commandMethod.Purpose.ShouldBe("Customer checks out of the store");
            commandMethod.Events.Any(e => e.Equals("Customer Checkout")).ShouldBeTrue();
            aggregateRoot.Entities.Count.ShouldBe(1);
            aggregateRoot.Entities.First(e => e == "Test Entity");
            aggregateRoot.ValueObjects.Count.ShouldBe(2);
            aggregateRoot.ValueObjects.Any(v => v == "Name").ShouldBeTrue();
            aggregateRoot.ValueObjects.Any(v => v == "Cart").ShouldBeTrue();

            var storeModule = glossary.Modules.First(m => m.Name == "Store");
            storeModule.Aggregates.Any(a => a.Name == "Store").ShouldBeTrue();
        }

        [Test]
        public void CreateGlossary_generates_glossary_for_entity_terms()
        {
            // Arrange
            var fileLoader = Substitute.For<IFileLoader>();
            fileLoader.GetTypesFromAssembly(Arg.Any<string>()).Returns(new List<Type> { typeof(TestEntity) });

            var sut = new CompositionService(fileLoader);

            // Act
            var glossary = sut.CreateGlossary("path");

            // Assert
            var customerModule = glossary.Modules.First(m => m.Name == string.Empty);
            var entity = customerModule.Entities.First(a => a.Name.Equals("Test Entity"));
            entity.CommandMethods.Count.ShouldBe(1);
            entity.CommandMethods.Any(c => c.Name.Equals("Command")).ShouldBeTrue();
            entity.ValueObjects.Count.ShouldBe(1);
            entity.ValueObjects.Any(v => v == "Name").ShouldBeTrue();
        }

        [Test]
        public void CreateGlossary_generates_glossary_for_valueObject_terms()
        {
            // Arrange
            var fileLoader = Substitute.For<IFileLoader>();
            fileLoader.GetTypesFromAssembly(Arg.Any<string>()).Returns(new List<Type> { typeof(Name), typeof(Cart), typeof(StoreMetadata), typeof(StoreItem), typeof(Inventory) });

            var sut = new CompositionService(fileLoader);

            // Act
            var glossary = sut.CreateGlossary("path");

            // Assert
            var customerModule = glossary.Modules.First(m => m.Name == "Customer");
            var valueObjects = customerModule.ValueObjects;
            valueObjects.Count.ShouldBe(2);
            valueObjects.Any(v => v.Name == "Name" && v.Definition == "A person's name").ShouldBeTrue();
            valueObjects.Any(v => v.Name == "Cart" && v.Definition == "A collection of store items available for purchase").ShouldBeTrue();

            var storeModule = glossary.Modules.First(m => m.Name == "Store");
            var storeValueObjects = storeModule.ValueObjects;
            storeValueObjects.Count.ShouldBe(3);
            storeValueObjects.Any(v => v.Name == "Store Item" && v.Definition == "An item available for purchase").ShouldBeTrue();
            storeValueObjects.Any(v => v.Name == "Inventory" && v.Definition == "A collection of Store Items within a store").ShouldBeTrue();
            storeValueObjects.Any(v => v.Name == "Store Metadata" && v.Definition == "The metadata about the store including name and website").ShouldBeTrue();
        }

        [Test]
        public void CreateGlossary_generates_glossary_for_domainEvent_terms()
        {
            // Arrange
            var fileLoader = Substitute.For<IFileLoader>();
            fileLoader.GetTypesFromAssembly(Arg.Any<string>()).Returns(new List<Type> { typeof(CustomerCheckoutEvent) });

            var sut = new CompositionService(fileLoader);

            // Act
            var glossary = sut.CreateGlossary("path");

            // Assert
            var customerModule = glossary.Modules.First(m => m.Name == "Customer");
            var domainEvents = customerModule.DomainEvents;
            domainEvents.Count.ShouldBe(1);
            domainEvents.Any(v => v.Name == "Customer Checkout" && v.Definition == "An event indicating that the customer has checked out with the given items").ShouldBeTrue();
        }

        [Test]
        public void CreateGlossary_generates_glossary_for_domainService_terms()
        {
            // Arrange
            var fileLoader = Substitute.For<IFileLoader>();
            fileLoader.GetTypesFromAssembly(Arg.Any<string>()).Returns(new List<Type> { typeof(StoreTransactionService) });

            var sut = new CompositionService(fileLoader);

            // Act
            var glossary = sut.CreateGlossary("path");

            // Assert
            var storeModule = glossary.Modules.First(m => m.Name == "Store");
            var domainServices = storeModule.DomainServices;
            domainServices.Count.ShouldBe(1);
            domainServices.Any(v => v.Name == "Store Transaction Service" && v.Definition == "Processes transactions made by customers").ShouldBeTrue();
        }
    }
}
