using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public struct PersonList
{
    Person[] family;
    Person[] villagers;
    Person[] employees;

    public void setFamily(Person person)
    {
        family[family.Count()] = person;
    }
    public Person[] getFamily()
    {
        return family;
    }
    public void setVillagers(Person person)
    {
        villagers[villagers.Count()] = person;
    }
    public Person[] getVillagers()
    {
        return villagers;
    }
    public void setEmployees(Person person)
    {
        employees[employees.Count()] = person;
    }
    public Person[] getEmployees()
    {
        return employees;
    }
}
