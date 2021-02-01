using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HT1
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable hash = new HashTable(30);

            hash.Insert(new Element(16, "шестнадцать"));
            hash.Insert(new Element(25, "двадцать пять"));
            hash.Insert(new Element(25, "опять двадцать пять"));
            hash.Insert(new Element(37, "тридцать сем"));
            hash.Insert(new Element(35, "тридцать пять"));
            hash.Insert(new Element(44, "сорок чоетыр"));
            hash.Insert(new Element(28, "двадцать восем"));
            hash.Insert(new Element(451, "четырста пятдесят один"));
            hash.Insert(new Element(7, "сем"));
            hash.Insert(new Element(1, "один"));
            hash.Insert(new Element(31, "тридцять один"));
            hash.Insert(9, "девять");
            hash.Insert(new Element(2, "два"));
            hash.Insert(new Element(83, "восемдесят три"));
            hash.Insert(new Element(65, "шестдесят пять"));
            hash.Insert(new Element(201, "двесте один"));
            hash.Insert(new Element(90, "девяносто"));
            hash.Insert(new Element(301, "триста один"));
            hash.Insert(new Element(13, "тринадцать"));
            hash.Insert(new Element(24, "двадцать четыри"));
            hash.Insert(new Element(46, "сорок шесть"));

            hash.PrintHash();

            Console.ReadLine();
        }
    }

    class ElementRef
    {
        public Element Next;

        public ElementRef()
        {
            Next = null;
        }
    }

    class Element : ElementRef
    {
        public readonly int Key;
        public readonly string Value;

        public Element(int key, string value)
        {
            Key = key;
            Value = value;
        }

        public override string ToString()
        {
            return $"[{Key}: {Value}]";
        }
    }




    class HashTable
    {
        ElementRef[] arr;

        public HashTable(int length)
        {
            arr = new ElementRef[length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new ElementRef();
            }
        }
        public void Insert(int key, string value)
        {
            Insert(new Element(key, value));
        }

        public void Insert(Element element)
        {
            int i = 0;
            int index = Hash(element.Key);
            while (i <= arr.Length)
            {
                if (arr[index + i].Next == null)
                {
                    arr[index + i].Next = element;
                    break;
                }
                else
                {
                    i++;
                }
            }
        }

        public Element Find(int key)
        {
            for (Element el = arr[Hash(key)].Next; el != null; el = el.Next)
            {
                if (el.Key == key) return el;
            }
            return null;
        }

        public bool Delete(int key)
        {
            ElementRef prev = arr[Hash(key)];
            for (Element el = arr[Hash(key)].Next; el != null; prev = prev.Next)
            {
                if (el.Key == key)
                {
                    prev = el.Next;
                    return true;
                }
            }
            return false;
        }

        int Hash(int key)
        {
            return key % arr.Length;
        }

        public void PrintHash()
        {
            Console.WriteLine("\t \t \t Хеш-таблица");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"\t \t \t{i,-5} хеш-индекс: ");
                PrintHashNumber(i);
                Console.WriteLine();
            }
        }

        void PrintHashNumber(int index)
        {
            for (Element el = arr[index].Next; el != null; el = el.Next)
                Console.Write(el.ToString() + " ");
        }

    }
}
