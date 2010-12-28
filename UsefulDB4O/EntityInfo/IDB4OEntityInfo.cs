using System;
using UsefulDB4O.DatabaseConfig;

namespace UsefulDB4O.EntityInfo
{
    /// <summary>
    /// Different options to fill the properties of the IDB4OEntityInfo entity info
    /// </summary>
    [Flags]
    public enum DB4OFillOptions
    {
        /// <summary>
        /// 
        /// </summary>
        FillGlobalID    = 0x1,
        /// <summary>
        /// 
        /// </summary>
        FillLocalID     = 0x2,
        /// <summary>
        /// 
        /// </summary>
        FillVersion     = 0x3
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IDB4OEntityInfo
    {
        /// <summary>
        /// Gets or sets the Db4O global ID.
        /// </summary>
        /// <value>The Db4O global ID.</value>
        string DB4OGlobalID { get; set; }
        /// <summary>
        /// Gets or sets the Db4O local ID.
        /// </summary>
        /// <value>The Db4O local ID.</value>
        long DB4OLocalID { get; set; }
        /// <summary>
        /// Gets or sets the Db4O version.
        /// </summary>
        /// <value>The Db4O version.</value>
        long DB4OVersion { get; set; }
    }
}
