using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FruitRacers.Backend.DataAccess.Sql.Design
{
    public class CustomPluralizer : IPluralizer
    {
        public string Pluralize(string identifier)
        {
            return new Inflector.Inflector(CultureInfo.CreateSpecificCulture("en-EN")).Pluralize(identifier) ?? identifier;
        }

        public string Singularize(string identifier)
        {
            return new Inflector.Inflector(CultureInfo.CreateSpecificCulture("en-EN")).Singularize(identifier) ?? identifier;
        }
    }
}
