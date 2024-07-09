using System.Collections.Generic;
using System.Reflection;
using System;
using System.Linq;

namespace Mapper
{
    internal interface IObjectMapper
    {
        void Map(object source, object destination);
    }

    internal interface IClassMapper<TSource, TDestination> : IObjectMapper where TSource : class where TDestination : class
    {
        void Map(TSource source, TDestination destination);
    }

    internal class ClassMapper<TSource, TDestination> : IClassMapper<TSource, TDestination> where TSource : class where TDestination : class
    {
        public readonly Type _sourceType;
        public IDictionary<string, PropertyInfo> _sourceProperties;

        public readonly Type _destinationType;
        public IDictionary<string, PropertyInfo> _destinationProperties;

        private readonly IList<IObjectMapper> _mappers = new List<IObjectMapper>();

        public ClassMapper()
        {
            _sourceType = typeof(TSource);
            _destinationType = typeof(TDestination);

            CreatePropertyMappers();
        }

        private IEnumerable<PropertyInfo> GetSourceProperties(Type type)
        {
            return type.GetProperties().Where(x => x.GetMethod != null);
        }

        private IEnumerable<PropertyInfo> GetDestinationProperties(Type type)
        {
            return type.GetProperties().Where(x => x.SetMethod != null);
        }

        private void CreatePropertyMappers()
        {
            var sourceProperties = GetSourceProperties(_sourceType).ToList();
            if (sourceProperties.Count == 0)
            {
                throw new Exception("No source properties found");
            }

            var destinationProperties = GetDestinationProperties(_destinationType).ToList();
            if (destinationProperties.Count == 0)
            {
                throw new Exception("No destination properties found");
            }

            if (!sourceProperties.Select(x => x.Name).Intersect(destinationProperties.Select(x => x.Name), StringComparer.OrdinalIgnoreCase).Any())
            {
                throw new Exception("Source and Destination properties are not matching");
            }

            _sourceProperties = sourceProperties.ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);
            _destinationProperties = destinationProperties.ToDictionary(x => x.Name, x => x, StringComparer.OrdinalIgnoreCase);

            foreach (var sourceProperty in _sourceProperties)
            {
                if (_destinationProperties.ContainsKey(sourceProperty.Key))
                {
                    if (sourceProperty.Value.PropertyType.IsClass && sourceProperty.Value.PropertyType != typeof(string))
                    {
                        Type type = typeof(ClassMapper<,>).MakeGenericType(sourceProperty.Value.PropertyType, _destinationProperties[sourceProperty.Key].PropertyType);
                        IObjectMapper objectMapper= new Mapper()[typeof(IClassMapper<,>)];

                        _mappers.Add(new ComplexPropertyMapper(sourceProperty.Value, _destinationProperties[sourceProperty.Key], objectMapper));
                    }
                    else
                    {
                        _mappers.Add(new SimplePropertyMapper(sourceProperty.Value, _destinationProperties[sourceProperty.Key]));
                    }
                }
            }
        }

        public void Map(TSource source, TDestination destination)
        {
            foreach (var mapper in _mappers)
            {
                mapper.Map(source, destination);
            }


        }

        public void Map(object source, object destination)
        {
            Map((TSource)source, (TDestination)destination);
        }
    }

    internal class SimplePropertyMapper : IObjectMapper
    {
        private readonly PropertyInfo _sourceProperty;
        private readonly PropertyInfo _destinationProperty;

        public SimplePropertyMapper(PropertyInfo sourceProperty, PropertyInfo destinationProperty)
        {
            _sourceProperty = sourceProperty;
            _destinationProperty = destinationProperty;
        }

        public void Map(object source, object destination)
        {
            _destinationProperty.SetValue(destination, _sourceProperty.GetValue(source));
        }

    }

    internal class ComplexPropertyMapper:IObjectMapper
    {
        private readonly PropertyInfo _sourceProperty;
        private readonly PropertyInfo _destinationProperty;
        private readonly IObjectMapper _mapper;

        public ComplexPropertyMapper(PropertyInfo sourceProperty, PropertyInfo destinationProperty, IObjectMapper mapper)
        {
            _sourceProperty = sourceProperty;
            _destinationProperty = destinationProperty;
            _mapper = mapper;
        }

        public void Map(object source, object destination)
        {
            var sourceValue = _sourceProperty.GetValue(source);
            var destinationValue = Activator.CreateInstance(_destinationProperty.PropertyType);
            _mapper.Map(sourceValue, destinationValue);
            _destinationProperty.SetValue(destination, destinationValue);
        }
    }
}
