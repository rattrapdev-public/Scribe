using RattrapDev.Scribe.Compose.Model;
using RattrapDev.Scribe.Term;
using System.Linq;
using System.Reflection;
using Module = RattrapDev.Scribe.Compose.Model.Module;

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
                    if (!glossary.Modules.Any(m => m.Name == aggregateRootTerm.Name))
                    {
                        glossary.Modules.Add(new Module { Name = aggregateRootTerm.Module });
                    }

                    var module = glossary.Modules.First(m => m.Name == aggregateRootTerm.Module);
                    var aggregateRootModel = new AggregateRootModel { Name = aggregateRootTerm.Name, Definition = aggregateRootTerm.Definition };

                    foreach(var prop in t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                    {
                        var propAttributes = prop.PropertyType.GetCustomAttributes(true);
                        if (propAttributes.Any(a => a is Entity))
                        {
                            var entityTerm = propAttributes.OfType<Entity>().First();
                            aggregateRootModel.Entities.Add(entityTerm.Name);
                        }
                        else if (propAttributes.Any(a => a is ValueObject))
                        {
                            var term = propAttributes.OfType<ValueObject>().First();
                            aggregateRootModel.ValueObjects.Add(term.Name);
                        }
                    }

                    foreach(var method in t.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
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

                            aggregateRootModel.CommandMethods.Add(commandMethodModel);
                        }
                    }

                    module.Aggregates.Add(aggregateRootModel);
                }
                else if (attributes.Any(a => a is Entity))
                {
                    var entityTerm = attributes.OfType<Entity>().First();
                    if (!glossary.Modules.Any(m => m.Name == entityTerm.Name))
                    {
                        glossary.Modules.Add(new Module { Name = entityTerm.Module });
                    }

                    var module = glossary.Modules.First(m => m.Name == entityTerm.Module);
                    var entityModel = new EntityModel { Name = entityTerm.Name, Definition = entityTerm.Definition };

                    foreach (var prop in t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                    {
                        var propAttributes = prop.PropertyType.GetCustomAttributes(true);
                        if (propAttributes.Any(a => a is ValueObject))
                        {
                            var term = propAttributes.OfType<ValueObject>().First();
                            entityModel.ValueObjects.Add(term.Name);
                        }
                    }

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

                            entityModel.CommandMethods.Add(commandMethodModel);
                        }
                    }

                    module.Entities.Add(entityModel);
                }
                else if (attributes.Any(a => a is Entity))
                {
                    var entityTerm = attributes.OfType<Entity>().First();
                    if (!glossary.Modules.Any(m => m.Name == entityTerm.Name))
                    {
                        glossary.Modules.Add(new Module { Name = entityTerm.Module });
                    }

                    var module = glossary.Modules.First(m => m.Name == entityTerm.Module);
                    var entityModel = new EntityModel { Name = entityTerm.Name, Definition = entityTerm.Definition };

                    foreach (var prop in t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public))
                    {
                        var propAttributes = prop.PropertyType.GetCustomAttributes(true);
                        if (propAttributes.Any(a => a is ValueObject))
                        {
                            var term = propAttributes.OfType<ValueObject>().First();
                            entityModel.ValueObjects.Add(term.Name);
                        }
                    }

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

                            entityModel.CommandMethods.Add(commandMethodModel);
                        }
                    }

                    module.Entities.Add(entityModel);
                }
                else if (attributes.Any(a => a is ValueObject))
                {
                    var valueObjectTerm = attributes.OfType<ValueObject>().First();
                    if (!glossary.Modules.Any(m => m.Name == valueObjectTerm.Name))
                    {
                        glossary.Modules.Add(new Module { Name = valueObjectTerm.Module });
                    }

                    var module = glossary.Modules.First(m => m.Name == valueObjectTerm.Module);
                    var valueObjectModel = new ValueObjectModel { Name = valueObjectTerm.Name, Definition = valueObjectTerm.Definition };

                    module.ValueObjects.Add(valueObjectModel);
                }
                else if (attributes.Any(a => a is DomainService))
                {
                    var domainServiceTerm = attributes.OfType<DomainService>().First();
                    if (!glossary.Modules.Any(m => m.Name == domainServiceTerm.Name))
                    {
                        glossary.Modules.Add(new Module { Name = domainServiceTerm.Module });
                    }

                    var module = glossary.Modules.First(m => m.Name == domainServiceTerm.Module);
                    var domainServiceModel = new DomainServiceModel { Name = domainServiceTerm.Name, Definition = domainServiceTerm.Definition };

                    module.DomainServices.Add(domainServiceModel);
                }
                else if (attributes.Any(a => a is DomainEvent))
                {
                    var domainEventTerm = attributes.OfType<DomainEvent>().First();
                    if (!glossary.Modules.Any(m => m.Name == domainEventTerm.Name))
                    {
                        glossary.Modules.Add(new Module { Name = domainEventTerm.Module });
                    }

                    var module = glossary.Modules.First(m => m.Name == domainEventTerm.Module);
                    var domainEventModel = new DomainEventModel { Name = domainEventTerm.Name, Definition = domainEventTerm.Definition };

                    module.DomainEvents.Add(domainEventModel);
                }
            }

            return glossary;
        }
    }
}
