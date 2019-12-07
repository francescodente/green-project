﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FruitRacers.Backend.Shared.Utils
{
    public static class ReflectionUtils
    {
        public static IEnumerable<T> InstancesOfSubtypes<T>(params Assembly[] assemblies)
        {
            return assemblies
                .SelectMany(assembly => assembly.GetTypes())
                .Where(t => typeof(T).IsAssignableFrom(t))
                .Where(t => !(t.IsAbstract || t.IsInterface))
                .Select(Activator.CreateInstance)
                .Cast<T>();
        }
    }
}
