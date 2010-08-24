using System;
using System.Collections.Generic;
using System.Linq;
using Db4objects.Db4o;
using System.Reflection;
using System.Threading;
using System.Collections.ObjectModel;

namespace UsefulDB4O
{
    public static class Extensions
    {

        public static IList<T> ToList<T>(this IObjectSet objectSet)
        {
            int totalCount;

            return objectSet.ToInternalPagedList<T>(null, null, -1, -1, out totalCount);
        }

        public static IList<T> ToList<T>(this IObjectSet objectSet, IObjectContainer container, int? activateDepth)
        {
            int totalCount;

            return objectSet.ToInternalPagedList<T>(container, activateDepth, -1, -1, out totalCount);
        }

        public static IList<T> ToPagedList<T>(this IObjectSet objectSet, int maximumRows, int startRowIndex, out int totalCount)
        {
            totalCount = 0;

            return objectSet.ToInternalPagedList<T>(null, null, maximumRows, startRowIndex, out totalCount);
        }

        public static IList<T> ToPagedList<T>(this IObjectSet objectSet, IObjectContainer container, int? activateDepth, int maximumRows, int startRowIndex, out int totalCount)
        {
            totalCount = 0;

            return objectSet.ToInternalPagedList<T>(container, activateDepth, maximumRows, startRowIndex, out totalCount);
        }

        public static int GetCount(this IObjectSet objectSet)
        {
            return objectSet.Ext().GetIDs().Length;
        }

        #region INTERNAL EXTENSIONS

        internal static Collection<T> ToCollection<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
                return null;

            var collection = new Collection<T>();

            foreach (T item in enumerable)
                collection.Add(item);

            return collection;
        }

        internal static T GetAttribute<T>(this MemberInfo memberInfo) where T : Attribute
        {
            var attribs = memberInfo.GetCustomAttributes(typeof(T), false);

            if (attribs != null && attribs.Length > 0)
                return (T)attribs[0];

            return null;
        }

        internal static IList<T> ToInternalPagedList<T>(this IObjectSet objectSet, IObjectContainer container, int? activateDepth, int maximumRows, int startRowIndex, out int totalCount)
        {
            totalCount = 0;

            if (objectSet == null)
                throw new ArgumentNullException("objectSet", "The objectSet instance cannot be null");


            var applyPaging = (maximumRows > 0 && startRowIndex > -1) ? true : false;
            var objectSetExt = objectSet.Ext();
            var itemIndexes = objectSetExt.GetIDs().Select((id, index) => index);

            totalCount = itemIndexes.Count();

            if (applyPaging)
                itemIndexes = itemIndexes.Skip(startRowIndex).Take(maximumRows);

            var applyCustomDepth = false;

            if (activateDepth.HasValue)
            {
                if (container == null)
                    throw new ArgumentNullException("container", "The container instance cannot be null when activateDepth.HasValue is true");

                    applyCustomDepth = true;
            }

            return itemIndexes.Select(delegate(int index)
            {
                var item = (T)objectSetExt.Get(index);

                if (applyCustomDepth && !container.Ext().IsActive(item))
                    container.Activate(item, activateDepth.Value);

                return item;

            }).ToList();
        }

        #endregion
    }
}
