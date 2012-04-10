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

            if(AgeDifferenceList.Count < 1)
            {
                return new AgeDifference();
            }

            AgeDifference ageDifferenceAnswer = AgeDifferenceList[0];
            foreach(var ageDifference in AgeDifferenceList)
            {
                switch(findType)
                {
                    case FindType.MinimumDiff:
                        if(ageDifference.Difference < ageDifferenceAnswer.Difference)
                        {
                            ageDifferenceAnswer = ageDifference;
                        }
                        break;

                    case FindType.MaximumDiff:
                        if (ageDifference.Difference > ageDifferenceAnswer.Difference)
                        {
                            ageDifferenceAnswer = ageDifference;
                        }
                        break;
                }
            }

            return ageDifferenceAnswer;
        }

        private List<AgeDifference> GetAgeDifferenceList() {
            var AgeDifferenceList = new List<AgeDifference>();

            for (var i = 0; i < _persons.Count - 1; i++) {
                for (var j = i + 1; j < _persons.Count; j++) {
                    var r = new AgeDifference();
                    if (_persons[i].BirthDate < _persons[j].BirthDate) {
                        r.Person1 = _persons[i];
                        r.Person2 = _persons[j];
                    } else {
                        r.Person1 = _persons[j];
                        r.Person2 = _persons[i];
                    }
                    r.Difference = r.Person2.BirthDate - r.Person1.BirthDate;
                    AgeDifferenceList.Add(r);
                }
            }
            return AgeDifferenceList;
        }
    }
}