using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikums2
{
    class Fleet
    {
        private class Wrapper
        {
            public Truck t;
            public Wrapper next;
            public Wrapper(Truck t)
            {
                this.t = t;
                next = null;
            }
            public override string ToString()
            {
                return t.ToString();
            }
        }
        private Wrapper head;
        public Fleet()
        {
            head = null;
        }
        public int Add(Truck t)
        {
            // eleman listede varise eklemiyor
            if (TruckExist(t.Numberplate))
            {
                return -1;
            }
            // head e ekleme
            Wrapper neu = new Wrapper(t);

            if (head == null)
            {
                head = neu;
                return 0;
            }
            // eklenecek eleman listedeki elemanla karsilastirip büyükse basa ekleme
            if (t.Numberplate.CompareTo(head.t.Numberplate)<0)
            {
                neu.next = head;
                head = neu;
                return 0;
            }
            Wrapper temp = head;
            Wrapper last = head;
            while (temp!=null)
            {
                if (t.Numberplate.CompareTo(temp.t.Numberplate)<0)
                {
                    neu.next = temp;
                    last.next = neu;
                    return 0;
                }
                last = temp;
                temp = temp.next;
            }
            last.next = neu;
            return 0;


        }
        private bool TruckExist(string numberplate)
        {
            Wrapper temp = head;
            bool exist = false;
            while (temp != null)
            {
                if (temp.t.Numberplate.CompareTo(numberplate) == 0)
                {
                    exist = true;
                }
                temp = temp.next;
            }
            return exist;
        }

        public int Remove(string numberplate)
        {
            if (head.t.Numberplate == numberplate)
            {
                head = head.next;
                return 0;
            }
            else 
            { 
                Wrapper temp = head;
                Wrapper last = head;
                while (temp!=null)
                {
                    if (temp.t.Numberplate==numberplate)
                    {
                        last.next = temp.next;
                        return 0;
                    }
                    last = temp;
                    temp = temp.next;
                }
                 
            }
            return -1;
        }
        public void AddClient(String clientName, params String[] numberplates)
        {

        }
    }
}
