﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Mahzan.Models.Enums.Expressions;

namespace Mahzan.Models.Expressions
{
    public static class ExpressionBuilder
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
        private static MethodInfo startsWithMethod =
        typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });
        private static MethodInfo endsWithMethod =
        typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });


        public static Expression<Func<T,
        bool>> GetExpression<T>(IList<FilterExpression> filters)
        {
            if (filters.Count == 0)
                return null;

            ParameterExpression param = Expression.Parameter(typeof(T), "t");
            Expression exp = null;

            if (filters.Count == 1)
                exp = GetExpression<T>(param, filters[0]);
            else if (filters.Count == 2)
                exp = GetExpression<T>(param, filters[0], filters[1]);
            else
            {
                while (filters.Count > 0)
                {
                    var f1 = filters[0];
                    var f2 = filters[1];

                    if (exp == null)
                        exp = GetExpression<T>(param, filters[0], filters[1]);
                    else
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0], filters[1]));

                    filters.Remove(f1);
                    filters.Remove(f2);

                    if (filters.Count == 1)
                    {
                        exp = Expression.AndAlso(exp, GetExpression<T>(param, filters[0]));
                        filters.RemoveAt(0);
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(exp, param);
        }

        private static Expression GetExpression<T>(ParameterExpression param, FilterExpression filter)
        {

            MemberExpression member = Expression.Property(param, filter.PropertyInfo.Name);
            ConstantExpression constant = Expression.Constant(filter.Value);

            //var parameter = Expression.Parameter(typeof(T), "t");
            var property = Expression.Property(param, filter.PropertyInfo.Name);
            var value = Expression.Constant(filter.Value);
            var converted = Expression.Convert(value, property.Type);

            switch (filter.Operator)
            {
                case OperationsEnum.Equals:
                    //return Expression.Equal(member, constant);
                    return Expression.Equal(property, converted);

                case OperationsEnum.GreaterThan:
                    return Expression.GreaterThan(member, constant);

                case OperationsEnum.GreaterThanOrEqual:
                    return Expression.GreaterThanOrEqual(member, constant);

                case OperationsEnum.LessThan:
                    return Expression.LessThan(member, constant);

                case OperationsEnum.LessThanOrEqual:
                    return Expression.LessThanOrEqual(member, constant);

                case OperationsEnum.Contains:
                    return Expression.Call(member, containsMethod, constant);

                case OperationsEnum.StartsWith:
                    return Expression.Call(member, startsWithMethod, constant);

                case OperationsEnum.EndsWith:
                    return Expression.Call(member, endsWithMethod, constant);
            }

            return null;
        }

        private static BinaryExpression GetExpression<T>
        (ParameterExpression param, FilterExpression filter1, FilterExpression filter2)
        {
            Expression bin1 = GetExpression<T>(param, filter1);
            Expression bin2 = GetExpression<T>(param, filter2);

            return Expression.AndAlso(bin1, bin2);
        }
    }
}