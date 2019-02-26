using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch11ExFinal
{
    public class People : DictionaryBase, ICloneable
    {
        public void Add(Person newPerson)
        {
            Dictionary.Add(newPerson.Name, newPerson);
        }
        public void Remove(string personName)
        {
            Dictionary.Remove(personName);
        }
        public Person this[string personName]
        {
            get { return (Person)Dictionary[personName]; }
            set { Dictionary[personName] = value; }
        }
        public Person[] GetOldest()
        {
            Person tempOldest = null;
            People oldestPeople = new People();
            Person currentPerson = null;

            foreach (DictionaryEntry person in Dictionary)
            {
                currentPerson = person.Value as Person;
                if (tempOldest == null)
                {
                    tempOldest = currentPerson;
                    continue;
                }
                if (currentPerson > tempOldest)
                {
                    tempOldest = currentPerson;
                }
            }
            oldestPeople.Add(tempOldest);
            foreach (DictionaryEntry person in Dictionary)
            {
                currentPerson = person.Value as Person;
                if (currentPerson == tempOldest)
                {
                    continue;
                }
                if (currentPerson >= tempOldest)
                {
                    oldestPeople.Add(currentPerson);
                }
            }
            Person[] oldestPeopleArr = new Person[oldestPeople.Count];
            int copyIndex = 0;
            foreach (DictionaryEntry p in oldestPeople)
            {
                oldestPeopleArr[copyIndex] = p.Value as Person;
                copyIndex++;
            }
            return oldestPeopleArr;
        }

        public object Clone()
        {
            People cloned = new People();
            foreach (DictionaryEntry p in Dictionary)
            {
                Person clone = new Person();
                Person toClone = p.Value as Person;
                clone.Name = toClone.Name;
                clone.Age = toClone.Age;
                cloned.Add(clone);
            }
            return cloned;
        }

        public IEnumerable Ages
        {
            get
            {
                foreach (DictionaryEntry p in Dictionary)
                {
                    yield return (p.Value as Person).Age;
                }
            }
        }
    }
}
