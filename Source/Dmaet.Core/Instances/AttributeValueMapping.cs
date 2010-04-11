
using System.Collections.Generic;
using Dmaet.Core.Attributes;

namespace Dmaet.Core.Instances
{
    /// <summary>
    ///
    /// </summary>
    public class AttributeValueMapping : ICopyable<AttributeValueMapping>
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
        public AttributeValueMapping ()
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attributes">
        /// A <see cref="List<IAttribute>"/>
        /// </param>
        /// <param name="values">
        /// A <see cref="List<System.Double>"/>
        /// </param>
        public AttributeValueMapping (List<IAttribute> attributes, List<double> values)
        {
            this.attributes = new List<IAttribute> (attributes);
            this.values = new List<double> (values);
        }

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
        /// <param name="val">
        /// A <see cref="System.Double"/>
        /// </param>
        public void Add (IAttribute attribute, double val)
        {
            if (this.attributes.Contains (attribute))
                return;

            this.attributes.Add (attribute);
            this.values.Add (val);
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
            return this.values[IndexOf (attribute)];
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

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <param name="val">
        /// A <see cref="System.Double"/>
        /// </param>
        public void SetValue (IAttribute attribute, double val)
        {
            this.values[IndexOf (attribute)] = val;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="index">
        /// A <see cref="System.Int32"/>
        /// </param>
        /// <param name="val">
        /// A <see cref="System.Double"/>
        /// </param>
        public void SetValue (int index, double val)
        {
            this.values[index] = val;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        public void Remove (IAttribute attribute)
        {
            int index = IndexOf (attribute);

            this.attributes.RemoveAt (index);
            this.values.RemoveAt (index);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="attribute">
        /// A <see cref="IAttribute"/>
        /// </param>
        /// <returns>
        /// A <see cref="System.Int32"/>
        /// </returns>
        public int IndexOf (IAttribute attribute)
        {
            if (!this.attributes.Contains (attribute))
                throw new System.Exception ("Attribute not in list!");

            for (int i = 0; i < this.attributes.Count; ++i)
                if (attribute == this.attributes[i])
                    return i;
            throw new System.Exception ("Could not find attribute!");
        }

        /// <summary>
        ///     Creates a deep copy of the class.
        /// </summary>
        /// <returns>
        ///     A deep copy equal to this class.
        /// </returns>
        public AttributeValueMapping Copy ()
        {
            return new AttributeValueMapping (this.attributes, this.values);
        }
    }
}
