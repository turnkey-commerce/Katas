using System.Collections.Generic;

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

            for (var i = 0; i < _persons.Count - 1; i++) {
                for (var j = i + 1; j < _persons.Count; j++) {
                    var normalizedAgeDifference = GetNormalizedAgeDifference(i, j);
                    AgeDifferenceList.Add(normalizedAgeDifference);
                }
            }
            return AgeDifferenceList;
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