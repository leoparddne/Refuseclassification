using AutoMapper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CCLUtility
{
    public static class MapperUtility
    {
        /// <summary>
        /// 实体属性反射
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T AutoMapping<T>(this object obj) where T : new()
        {
            T t = new T();
            var properties = obj.GetType().GetProperties();// BindingFlags.Public);//| BindingFlags.Instance);
            var fields = obj.GetType().GetFields();
            Type target = (t).GetType();

            foreach (var pp in properties)
            {
                PropertyInfo targetPP = target.GetProperty(pp.Name);
                object value = pp.GetValue(obj, null);

                if (targetPP != null && value != null)
                {
                    targetPP.SetValue(t, value, null);
                }
            }
            foreach (var field in fields)
            {
                var targetField = target.GetField(field.Name);
                object value = field.GetValue(obj);

                if (targetField != null && value != null)
                {
                    targetField.SetValue(t, value);
                }
            }
            return t;
        }
    }
}
