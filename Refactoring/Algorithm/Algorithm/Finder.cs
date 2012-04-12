using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _persons;

        public Finder(List<Person> persons)
        {
            _persons = persons;
        }

        public AgeDifference Find(FindType findType)
        {
            var AgeDifferenceList = GetAgeDifferenceList();

            AgeDifference ageDifferenceResult = new AgeDifference();

            if (AgeDifferenceList.Count > 0) {
                if (findType == FindType.MaximumDiff) {
                    AgeDifferenceList.Reverse();
                } else {
                    AgeDifferenceList.Sort(); 
                }
                ageDifferenceResult = AgeDifferenceList[0];
            }

            return ageDifferenceResult;
        }

        private List<AgeDifference> GetAgeDifferenceList() {
            var AgeDifferenceList = new List<AgeDifference>();
            var differences = from p1 in _persons
                               from p2 in _persons
                               where p1 != p2
                               let p = new[] { p1, p2 }.OrderBy(x => x.BirthDate).ToArray()
                               let pair = new AgeDifference {
                                   Person1 = p[0],
                                   Person2 = p[1],
                                   Difference = p[1].BirthDate - p[0].BirthDate
                               }
                               orderby pair.Difference
                               select pair;
            return differences.ToList();
        }

        private AgeDifference GetNormalizedAgeDifference(int i, int j) {
            var normalizedAgeDifference = new AgeDifference();
            if (_persons[i].BirthDate < _persons[j].BirthDate) {
                normalizedAgeDifference.Person1 = _persons[i];
                normalizedAgeDifference.Person2 = _persons[j];
            } else {
                normalizedAgeDifference.Person1 = _persons[j];
                normalizedAgeDifference.Person2 = _persons[i];
            }
            normalizedAgeDifference.Difference = normalizedAgeDifference.Person2.BirthDate - normalizedAgeDifference.Person1.BirthDate;
            return normalizedAgeDifference;
        }
    }
}