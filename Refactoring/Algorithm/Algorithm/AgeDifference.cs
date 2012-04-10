using System;

namespace Algorithm
{
    public class AgeDifference: IComparable
    {
        public Person Person1 { get; set; }
        public Person Person2 { get; set; }
        public TimeSpan Difference { get; set; }

        public int CompareTo(object obj) {
            if (obj is AgeDifference) {
                AgeDifference OtherAgeDiff = (AgeDifference)obj;
                return this.Difference.CompareTo(OtherAgeDiff.Difference);
            } else {
                throw new ArgumentException("Object is not an AgeDifference.");
            }
        }
    }
}