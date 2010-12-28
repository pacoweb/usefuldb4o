using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Db4objects.Db4o;
using Db4objects.Db4o.Ext;

namespace UsefulDB4O.EntityInfo
{
    public static class EntityInfoExtensions
    {

        /// <summary>
        /// Activates the specified enumerable.
        /// </summary>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="container">The container.</param>
        /// <param name="activationDepth">The activation depth.</param>
        public static void Activate(this IEnumerable<IDB4OEntityInfo> enumerable, IObjectContainer container, int activationDepth)
        {
            if (enumerable == null || enumerable.Count() == 0)
                return;

            foreach (var item in enumerable)
                item.Activate(container, activationDepth);

            return;
        }

        /// <summary>
        /// Fills the Db4O info.
        /// </summary>
        /// <param name="enumerable">The enumerable.</param>
        /// <param name="container">The container.</param>
        /// <param name="fillOptions">The fill options.</param>
        public static void FillDB4OInfo(this IEnumerable<IDB4OEntityInfo> enumerable, IObjectContainer container, DB4OFillOptions fillOptions)
        {
            if (enumerable == null || enumerable.Count() == 0)
                return;

            foreach (var item in enumerable)
                item.FillDB4OInfo(container, fillOptions);

            return;
        }

        /// <summary>
        /// Fills the Db4O info.
        /// </summary>
        /// <param name="repositoryItem">The repository item.</param>
        /// <param name="container">The container.</param>
        public static void FillDB4OInfo(this IDB4OEntityInfo repositoryItem, IObjectContainer container)
        {
            FillDB4OInfo(repositoryItem, container, DB4OFillOptions.FillGlobalID | DB4OFillOptions.FillLocalID | DB4OFillOptions.FillVersion);
        }

        /// <summary>
        /// Fills the Db4o info.
        /// </summary>
        /// <param name="db4oInfoItem">The db4o info item.</param>
        /// <param name="container">The container.</param>
        /// <param name="fillMode">The fill mode.</param>
        public static void FillDB4OInfo(this IDB4OEntityInfo db4oInfoItem, IObjectContainer container, DB4OFillOptions fillMode)
        {
            if (db4oInfoItem == null
                    || db4oInfoItem.HasDB4OEntityInfo()
                        || !container.Ext().IsActive(db4oInfoItem))
                return;

            var repositoryInfo = container.Ext().GetObjectInfo(db4oInfoItem);

            if (fillMode.Equals(DB4OFillOptions.FillGlobalID))
                db4oInfoItem.DB4OGlobalID = repositoryInfo.GetUUID().ConvertToString();

            if (fillMode.Equals(DB4OFillOptions.FillLocalID))
                db4oInfoItem.DB4OLocalID = repositoryInfo.GetInternalID();

            if (fillMode.Equals(DB4OFillOptions.FillVersion))
                db4oInfoItem.DB4OVersion = repositoryInfo.GetVersion();

            var entityType = db4oInfoItem.GetType();
            var properties = entityType.GetProperties();

            foreach (var property in properties)
            {
                var repositoryType = property.PropertyType.GetInterface(typeof(IDB4OEntityInfo).ToString());

                if (repositoryType == null)
                    continue;

                var val = property.GetValue(db4oInfoItem, null);

                if (val == null || !container.Ext().IsActive(val))
                    continue;

                var repositoryVal = val as IDB4OEntityInfo;

                repositoryVal.FillDB4OInfo(container);
            }

        }

        /// <summary>
        /// Activates the specified db4o info item.
        /// </summary>
        /// <param name="db4oInfoItem">The db4o info item.</param>
        /// <param name="container">The container.</param>
        /// <param name="activationDepth">The activation depth.</param>
        public static void Activate(this IDB4OEntityInfo db4oInfoItem, IObjectContainer container, int activationDepth)
        {
            if (!db4oInfoItem.HasDB4OEntityInfo())
                return;

            if (!String.IsNullOrEmpty(db4oInfoItem.DB4OGlobalID))
                db4oInfoItem.DB4OGlobalID.RecoverUUID()
                                   .Activate(container, activationDepth);

            if (db4oInfoItem.DB4OLocalID > 0)
                db4oInfoItem.DB4OLocalID
                                   .Activate(container, activationDepth);

            return;
        }

        /// <summary>
        /// Activates the specified local ID.
        /// </summary>
        /// <param name="localID">The local ID.</param>
        /// <param name="container">The container.</param>
        /// <param name="activationDepth">The activation depth.</param>
        public static void Activate(this long localID, IObjectContainer container, int activationDepth)
        {
            if (localID <= 0)
                return;

            var item = container.Ext().GetByID(localID);

            if (item == null)
                return;

            container.Activate(item, activationDepth);

            return;
        }

        /// <summary>
        /// Activates the specified UUID.
        /// </summary>
        /// <param name="UUID">The UUID.</param>
        /// <param name="container">The container.</param>
        /// <param name="activationDepth">The activation depth.</param>
        public static void Activate(this Db4oUUID UUID, IObjectContainer container, int activationDepth)
        {
            if (UUID == null)
                return;

            var item = container.Ext().GetByUUID(UUID);

            if (item == null)
                return;

            container.Activate(item, activationDepth);

            return;
        }

        /// <summary>
        /// Gets the activated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db4oInfoItem">The db4o info item.</param>
        /// <param name="container">The container.</param>
        /// <param name="activationDepth">The activation depth.</param>
        /// <returns></returns>
        public static T GetActivated<T>(this IDB4OEntityInfo db4oInfoItem, IObjectContainer container, int activationDepth)
        {
            if (!db4oInfoItem.HasDB4OEntityInfo())
                return default(T);

            if (!String.IsNullOrEmpty(db4oInfoItem.DB4OGlobalID))
                return db4oInfoItem.DB4OGlobalID.RecoverUUID()
                                   .GetActivated<T>(container, activationDepth);

            if (db4oInfoItem.DB4OLocalID > 0)
                return db4oInfoItem.DB4OLocalID
                                   .GetActivated<T>(container, activationDepth);

            return default(T);
        }

        /// <summary>
        /// Gets the activated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="localID">The local ID.</param>
        /// <param name="container">The container.</param>
        /// <param name="activationDepth">The activation depth.</param>
        /// <returns></returns>
        public static T GetActivated<T>(this long localID, IObjectContainer container, int activationDepth)
        {
            if (localID <= 0)
                return default(T);

            var item = container.Ext().GetByID(localID);

            if (item == null)
                return default(T);

            container.Activate(item, activationDepth);

            return (T)item;
        }

        /// <summary>
        /// Gets the activated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="UUID">The UUID.</param>
        /// <param name="container">The container.</param>
        /// <param name="activationDepth">The activation depth.</param>
        /// <returns></returns>
        public static T GetActivated<T>(this Db4oUUID UUID, IObjectContainer container, int activationDepth)
        {
            if (UUID == null)
                return default(T);

            var item = container.Ext().GetByUUID(UUID);

            if (item == null)
                return default(T);

            container.Activate(item, activationDepth);

            return (T)item;
        }

        /// <summary>
        /// Gets the activated.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="GlobalID">The global ID.</param>
        /// <param name="container">The container.</param>
        /// <param name="activationDepth">The activation depth.</param>
        /// <returns></returns>
        public static T GetActivated<T>(this string GlobalID, IObjectContainer container, int activationDepth)
        {
            if (String.IsNullOrEmpty(GlobalID))
                return default(T);

            var item = container.Ext().GetByUUID(GlobalID.RecoverUUID());

            if (item == null)
                return default(T);

            container.Activate(item, activationDepth);

            return (T)item;
        }

        /// <summary>
        /// Recovers the UUID.
        /// </summary>
        /// <param name="UUIDString">The UUID string.</param>
        /// <returns></returns>
        public static Db4oUUID RecoverUUID(this string UUIDString)
        {
            if (String.IsNullOrEmpty(UUIDString))
                return null;

            string[] parts = UUIDString.Split(new[] { '|' });

            if (parts.Length != 2)
                return null;

            return new Db4oUUID(Convert.ToInt64(parts[0]),
                StringToByteArray(parts[1]));
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <param name="UUID">The UUID.</param>
        /// <returns></returns>
        public static string ConvertToString(this Db4oUUID UUID)
        {
            if (UUID == null)
                return null;

            return String.Format("{0}|{1}",
                 UUID.GetLongPart()
                 , ByteArrayToString(UUID.GetSignaturePart()));
        }

        /// <summary>
        /// Determines whether [has D b4 O entity info] [the specified db4o info item].
        /// </summary>
        /// <param name="db4oInfoItem">The db4o info item.</param>
        /// <returns>
        /// 	<c>true</c> if [has D b4 O entity info] [the specified db4o info item]; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasDB4OEntityInfo(this IDB4OEntityInfo db4oInfoItem)
        {
            if (db4oInfoItem == null)
                return false;

            if (!String.IsNullOrEmpty(db4oInfoItem.DB4OGlobalID)
                    || db4oInfoItem.DB4OLocalID > 0)
                return true;

            return false;
        }

        #region Private methods

        private static byte[] StringToByteArray(string toEncode)
        {
            return new ASCIIEncoding().GetBytes(toEncode);
        }

        private static string ByteArrayToString(byte[] arr)
        {
            return new ASCIIEncoding().GetString(arr);
        }

        #endregion
    }
}
