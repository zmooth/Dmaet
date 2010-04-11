
using System.Collections.Generic;
using Dmaet.Core.Attributes;

namespace Dmaet.Core.Instances
{
    /// <summary>
    ///
    /// </summary>
    public class AttributeValueMapping
    {
        /// <summary>
        ///
        /// </summary>
        private List<IAttribute> attributes = new List<IAttribute> ();
        /// <summary>
        ///
        /// </summary>
        private List<double> values = new List<double> ();

        /// <summary>
        ///
        /// </summary>
        public List<IAttribute> Attributes {
            get { return this.attributes; }
        }

        /// <summary>
        ///
        /// </summary>
        public List<double> Values {
            get { return this.values; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count {
            get { return this.attributes.Count; }
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Double"/>
        /// </returns>
        public double GetValue (IAttribute attribute)
        {
            if (!this.attributes.Contains (attribute))
                throw new System.Exception ("Attribute not in list!");

            for (int i = 0; i < this.attributes.Count; ++i)
                if (attribute == this.attributes[i])
                    return this.values[i];
            
            throw new System.Exception ("Could not find attribute!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">
        /// A <see cref="System.Int32"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Double"/>
        /// </returns>
        public double GetValue (int index)
        {
            if (index < 0 || index >= this.values.Count)
                throw new System.IndexOutOfRangeException ();
            
            return this.values[index];
        }
    }
}
