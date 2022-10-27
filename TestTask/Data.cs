using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestTask
{
    internal class Data
    {
        private Person[] team = Array.Empty<Person>();

        private class Person
        {
            private string name = "null";
            private int cash;

            public string Name { 
                get { return name; }
                set { name = value; }
            }
            public int Cash { 
                get { return cash; }
                set { cash = value; }
            }

            public Person(string name, int cash)
            {
                Name = name;
                Cash = cash;
            }
        }

        public int GetLength() 
        {
            return team.Length; 
        }

        public string[] GetPersonArray()
        {
            string[] personArray = new string[GetLength()];
            for (int i = 0; i < GetLength(); i++)
            {
                personArray[i] = team[i].Name + " " + team[i].Cash;
            }
            return personArray;
        }

        public void AddNewPerson(string name, int cash)
        {
            int i = 0;
            while (i < GetLength() && team[i].Name != name)
                i++;
            if (i == GetLength())
            {
                Array.Resize(ref team, GetLength() + 1);
                team[GetLength() - 1] = new Person(name, cash);
            } 
            else
                MessageBox.Show("Такое имя уже есть");
        }

        public void DeletePerson(string name)
        {
            if (GetLength() > 0)
            {
                int i = 0;
                while (i < GetLength() && name != team[i].Name)
                    i++;
                if (i < GetLength())
                {
                    Person item = team[i];
                    team = Array.FindAll(team, j => j != item).ToArray();
                }
                else
                    MessageBox.Show("Сотрудник не найден");
            }
            else
                MessageBox.Show("В базе данных еще нет сотрудников");
        }

        public void NewPayment(string name, int amount)
        {
            if (GetLength() > 0)
            {
                int i = 0;
                while (i < GetLength() && name != team[i].Name)
                    i++;
                if (i < GetLength())
                    team[i].Cash += amount;
                else
                    MessageBox.Show("Сотрудник не найден");
            }
            else
                MessageBox.Show("В базе данных еще нет сотрудников");
        }

        public void NewPurchase(string name, int amount)
        {
            if (GetLength() > 0)
            {
                int i = 0;
                while (i < GetLength() && name != team[i].Name)
                    i++;
                if (i < GetLength())
                {
                    team[i].Cash += amount;
                    foreach (Person person in team)
                        person.Cash -= (int) (amount / GetLength());
                }
                else
                    MessageBox.Show("Сотрудник не найден");
            }
            else
                MessageBox.Show("В базе данных еще нет сотрудников");
        }
    }
}
