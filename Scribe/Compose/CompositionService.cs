using RattrapDev.Scribe.Compose.Model;
using RattrapDev.Scribe.Term;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace RattrapDev.Scribe.Compose
{
    public class CompositionService
    {
        private IFileLoader _fileLoader;

        public CompositionService(IFileLoader fileLoader)
        {
            _fileLoader = fileLoader;
        }

        public Glossary CreateGlossary(string domainAssembly)
        {
            var types = _fileLoader.GetTypesFromAssembly(domainAssembly);

            var glossary = new Glossary();

            foreach (var t in types)
            {
                var attributes = t.GetCustomAttributes(true);
                if (attributes.Any(a => a is AggregateRoot))
                {
                    var aggregateRootTerm = attributes.OfType<AggregateRoot>().First();
                    var module = glossary.CreateOrGetModuleFrom(aggregateRootTerm);
                    var aggregateRootModel = new AggregateRootModel { Name = aggregateRootTerm.Name, Definition = aggregateRootTerm.Definition };

                    aggregateRootModel.Entities.AddRange(GetEntitiesFromProperties(t));
                    aggregateRootModel.ValueObjects.AddRange(GetValueObjectsFromProperties(t));
                    aggregateRootModel.CommandMethods.AddRange(GetCommandMethods(t));

                    module.Aggregates.Add(aggregateRootModel);
                }
                else if (attributes.Any(a => a is Entity))
                {
                    var entityTerm = attributes.OfType<Entity>().First();
                    var module = glossary.CreateOrGetModuleFrom(entityTerm);
                    var entityModel = new EntityModel { Name = entityTerm.Name, Definition = entityTerm.Definition };

                    entityModel.ValueObjects.AddRange(GetValueObjectsFromProperties(t));
                    entityModel.CommandMethods.AddRange(GetCommandMethods(t));

                    module.Entities.Add(entityModel);
                }
                else if (attributes.Any(a => a is ValueObject))
                {
                    var valueObjectTerm = attributes.OfType<ValueObject>().First();
                    var module = glossary.CreateOrGetModuleFrom(valueObjectTerm);
                    var valueObjectModel = new ValueObjectModel { Name = valueObjectTerm.Name, Definition = valueObjectTerm.Definition };

                    module.ValueObjects.Add(valueObjectModel);
                }
                else if (attributes.Any(a => a is DomainService))
                {
                    var domainServiceTerm = attributes.OfType<DomainService>().First();
                    var module = glossary.CreateOrGetModuleFrom(domainServiceTerm);
                    var domainServiceModel = new DomainServiceModel { Name = domainServiceTerm.Name, Definition = domainServiceTerm.Definition };

                    module.DomainServices.Add(domainServiceModel);
                }
                else if (attributes.Any(a => a is DomainEvent))
                {
                    var domainEventTerm = attributes.OfType<DomainEvent>().First();
                    var module = glossary.CreateOrGetModuleFrom(domainEventTerm);
                    var domainEventModel = new DomainEventModel { Name = domainEventTerm.Name, Definition = domainEventTerm.Definition };

                    module.DomainEvents.Add(domainEventModel);
                }
            }

            return glossary;
        }

        private List<string> GetValueObjectsFromProperties(Type t)
        {
            var valueObjects = new List<string>();
            foreach (var valueObject in t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                .Select(p => p.PropertyType.GetCustomAttributes().OfType<ValueObject>()).SelectMany(c => c))
            {
                valueObjects.Add(valueObject.Name);
            }

            return valueObjects;
        }

        private List<string> GetEntitiesFromProperties(Type t)
        {
            var entities = new List<string>();
            foreach (var entity in t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public)
                .Select(p => p.PropertyType.GetCustomAttributes().OfType<Entity>()).SelectMany(c => c))
            {
                entities.Add(entity.Name);
            }

            return entities;
        }

        private List<CommandMethodModel> GetCommandMethods(Type t)
        {
            var commandMethodModels = new List<CommandMethodModel>();
            foreach (var method in t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
            {
                var methodAttributes = method.GetCustomAttributes(true);
                if (methodAttributes.Any(a => a is CommandMethod))
                {
                    var commandMethodTerm = methodAttributes.OfType<CommandMethod>().First();
                    var domainEventTerms = commandMethodTerm.IssuedEvents == null ? Enumerable.Empty<DomainEvent>() : commandMethodTerm.IssuedEvents.Select(e => e.GetCustomAttributes().OfType<DomainEvent>().First()).ToList();

                    var commandMethodModel = new CommandMethodModel
                    {
                        Name = commandMethodTerm.Name,
                        Purpose = commandMethodTerm.Purpose,
                        Events = domainEventTerms.Select(e => e.Name).ToList(),
                    };

                    commandMethodModels.Add(commandMethodModel);
                }
            }

            return commandMethodModels;
        }
    }
}
