using CsvHelper.Configuration;
using GreenProject.Backend.Contracts.Reports;
using GreenProject.Backend.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace GreenProject.Backend.ApiLayer.Utils.Csv
{
    public static class CsvMappings
    {
        public abstract class OrderedClassMap<T> : ClassMap<T>
        {
            private readonly CsvReportSettings settings;
            private int index;

            public OrderedClassMap(CsvReportSettings settings)
            {
                this.settings = settings;
                this.index = 0;
            }

            public MemberMap<T, TProperty> AddMap<TProperty>(Expression<Func<T, TProperty>> expression)
            {
                return Map(expression).Index(this.index++);
            }

            public MemberMap<T, TProperty> AddPropertyMap<TProperty>(Expression<Func<T, TProperty>> property)
            {
                return AddMap(property)
                    .Name(this.settings.HeaderNames[this.GetPropertyName(property)]);
            }

            private string GetPropertyName<TProperty>(Expression<Func<T, TProperty>> property)
            {
                MemberExpression memberExpression;

                if (property.Body is UnaryExpression)
                {
                    UnaryExpression unaryExpression = (UnaryExpression)property.Body;
                    memberExpression = (MemberExpression)unaryExpression.Operand;
                }
                else
                {
                    memberExpression = (MemberExpression)property.Body;
                }

                return ((PropertyInfo)memberExpression.Member).Name;
            }
        }

        public class OrderReportModelMap : OrderedClassMap<OrderReportModel>
        {
            public OrderReportModelMap(CsvReportSettings settings)
                : base(settings)
            {
                AddPropertyMap(x => x.Street);
                AddPropertyMap(x => x.HouseNumber);
                AddPropertyMap(x => x.City);
                AddPropertyMap(x => x.ZipCode);
                AddPropertyMap(x => x.Name);
                AddPropertyMap(x => x.OrderNumber);
            }
        }
    }
}
