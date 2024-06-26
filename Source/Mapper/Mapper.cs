using System;
using System.Collections.Generic;

namespace Mapper
{
    public interface IMapper
    {
        TDestination Map<TDestination>(object source) where TDestination : class;
        TDestination Map<TDestination, TSource>(TSource Source) where TDestination : class where TSource : class;
    }

    public class Mapper : IMapper
    {
        private static readonly object _syncLock = new object();
        private static readonly IDictionary<Type, IObjectMapper> _mapperDictionary = new Dictionary<Type, IObjectMapper>();

        internal IObjectMapper this[Type key]
        {
            get
            {
                bool containsKey;
                lock (_syncLock)
                {
                    containsKey = _mapperDictionary.ContainsKey(key);
                }

                if (!containsKey)
                {
                    var classMappertype = typeof(ClassMapper<,>).MakeGenericType(key.GenericTypeArguments);
                    var classMapperInstance = Activator.CreateInstance(classMappertype);
                    _mapperDictionary.Add(key, (IObjectMapper)classMapperInstance);
                }

                lock (_syncLock)
                {
                    return _mapperDictionary[key];
                }
            }
            set
            {
                lock (_syncLock)
                {
                    _mapperDictionary[key] = value;
                }
            }
        }

        IDictionary<Type, IObjectMapper> MapperDictionary => _mapperDictionary;

        public Mapper()
        {
        }


        public T Map<T, U>(U source) where T : class where U : class
        {
            return Map<T>(source);
        }

        public TDestination Map<TDestination>(object source) where TDestination : class
        {
            Type sourceType = source.GetType();
            Type destinationType = typeof(TDestination);

            IObjectMapper mapper = this[typeof(IClassMapper<,>).MakeGenericType(new[] { sourceType,destinationType})];

            TDestination result = Activator.CreateInstance<TDestination>();
            mapper.Map(source, result);

            return result;
        }
    }
}
