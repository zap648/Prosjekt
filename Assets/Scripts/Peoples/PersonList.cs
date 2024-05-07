using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct PersonList
{
    public List<Person> family_list;
    Person[] villagers;
    Person[] employees;

    public void setFamily(Person person)
    {
        if (family_list == null)
        {
            family_list = new List<Person>();
        }

        family_list.Add(person);
    }
    public List<Person> getFamily(Person person)
    {
        if (family_list == null) { setFamily(person) ; }
        
        return family_list;
    }
    public void setVillagers(Person person)
    {
        if (villagers == null)
        {
            villagers = new Person[0];
            villagers[0] = person;
        }

        villagers[villagers.Count()+1] = person;
    }
    public Person[] getVillagers()
    {
        if (villagers == null) { return villagers = new Person[0]; }

        return villagers;
    }
    public void setEmployees(Person person)
    {
        if (employees == null)
        {
            employees = new Person[0];
            employees[0] = person;
        }

        employees[employees.Count()] = person;
    }
    public Person[] getEmployees()
    {
        if (employees == null) { return employees = new Person[0]; }

        return employees;
    }
}
