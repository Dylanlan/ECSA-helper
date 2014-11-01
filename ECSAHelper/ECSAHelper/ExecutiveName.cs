using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ECSAHelper
{
    /// <summary>
    /// A class representing the name of an ECSA Executive Position. The only reason this class exists is because I needed
    /// a non-string to be able to use the collection editor to allow the user to change which positions exist.
    /// </summary>
    public class ExecutiveName
    {
        /// <summary>
        /// Constructor with given name
        /// </summary>
        /// <param name="name">
        /// The name of this Executive Position
        /// </param>
        public ExecutiveName(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Default constructor sets position to New Position
        /// </summary>
        public ExecutiveName()
        {
            this.Name = "New Position";
        }

        /// <summary>
        /// The name of this ExecutiveName
        /// </summary>
        [Category("Executive Position")]
        public string Name { get; set; }

        /// <summary>
        /// A method to display its name when converted to a string
        /// </summary>
        /// <returns>
        /// The name of the position
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }
    }
}
