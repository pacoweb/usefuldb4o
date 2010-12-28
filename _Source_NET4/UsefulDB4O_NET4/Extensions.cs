using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

using Db4objects.Db4o;

namespace UsefulDB4O
{
    public static class Extensions
    {

        /// <summary>
        /// Toes the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectSet">The object set.</param>
        /// <returns></returns>
        public static IList<T> ToList<T>(this IObjectSet objectSet)
        {
            int totalCount;

            return objectSet.ToInternalPagedList<T>(null, null, -1, -1, out totalCount);
        }


        /// <summary>
        /// Toes the list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectSet">The object set.</param>
        /// <param name="container">The container.</param>
        /// <param name="activateDepth">The activate depth.</param>
        /// <returns></returns>
        public static IList<T> ToList<T>(this IObjectSet objectSet, IObjectContainer container, int? activateDepth)
        {
            int totalCount;

            return objectSet.ToInternalPagedList<T>(container, activateDepth, -1, -1, out totalCount);
        }


        /// <summary>
        /// Toes the paged list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectSet">The object set.</param>
        /// <param name="maximumRows">The maximum rows.</param>
        /// <param name="startRowIndex">Start index of the row.</param>
        /// <param name="totalCount">The total count.</param>
        /// <returns></returns>
        public static IList<T> ToPagedList<T>(this IObjectSet objectSet, int maximumRows, int startRowIndex, out int totalCount)
        {
            return objectSet.ToInternalPagedList<T>(null, null, maximumRows, startRowIndex, out totalCount);
        }


        /// <summary>
        /// Toes the paged list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="objectSet">The object set.</param>
        /// <param name="container">The container.</param>
        /// <param name="activateDepth">The activate depth.</param>
        /// <param name="maximumRows">The maximum rows.</param>
        /// <param name="startRowIndex">Start index of the row.</param>
        /// <param name="totalCount">The total count.</param>
        /// <returns></returns>
        public static IList<T> ToPagedList<T>(this IObjectSet objectSet, IObjectContainer container, int? activateDepth, int maximumRows, int startRowIndex, out int totalCount)
        {
            return objectSet.ToInternalPagedList<T>(container, activateDepth, maximumRows, startRowIndex, out totalCount);
        }


        /// <summary>
        /// Gets the count.
        /// </summary>
        /// <param name="objectSet">The object set.</param>
        /// <returns></returns>
        public static int GetCount(this IObjectSet objectSet)
        {
            if (objectSet == null)
                throw new ArgumentNullException("objectSet");

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

            if (attribs.Length > 0)
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
