﻿using System.Linq.Expressions;
using System.Reflection;

namespace System
{
    ///<summary>
    /// Provides support for extracting property information based on a property expression.
    ///</summary>
    static class PropertySupport
    {
        /// <summary>
        /// Extracts the property name from a property expression.
        /// </summary>
        /// <typeparam name="T">The object type containing the property specified in the expression.</typeparam>
        /// <param name="propertyExpression">The property expression (e.g. p => p.PropertyName)</param>
        /// <returns>The name of the property.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="propertyExpression"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the expression is:<br/>
        ///     Not a <see cref="MemberExpression"/><br/>
        ///     The <see cref="MemberExpression"/> does not represent a property.<br/>
        ///     Or, the property is static.
        /// </exception>
        public static string ExtractPropertyName<T>(Expression<Func<T>> propertyExpression)
        {
            if (propertyExpression == null)
                throw new ArgumentNullException("propertyExpression");

            return ExtractPropertyNameFromLambda(propertyExpression);
        }

        /// <summary>
        /// Extracts the property name from a LambdaExpression.
        /// </summary>
        /// <param name="expression">The LambdaExpression</param>
        /// <returns>The name of the property.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <paramref name="expression"/> is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the expression is:<br/>
        ///     The <see cref="MemberExpression"/> does not represent a property.<br/>
        ///     Or, the property is static.
        /// </exception>
        private static string ExtractPropertyNameFromLambda(LambdaExpression expression)
        {
            if (expression == null)
                throw new ArgumentNullException("expression");

            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
                throw new ArgumentException("PropertySupport_NotMemberAccessExpression_Exception", "expression");

            var property = memberExpression.Member as PropertyInfo;
            if (property == null)
                throw new ArgumentException("PropertySupport_ExpressionNotProperty_Exception", "expression");

            var getMethod = property.GetGetMethod();
            if (getMethod.IsStatic)
                throw new ArgumentException("PropertySupport_StaticExpression_Exception", "expression");

            return memberExpression.Member.Name;
        }

    }
}
