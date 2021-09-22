using System;
using System.Collections.Generic;
using System.Text;

namespace Praktikums2
{
    class Truck
    {
        string numberplate;
        public string Numberplate { get; set; }
        Driver d;
        ClientList cl;
        public Truck(Driver d, string numberplate)
        {
            this.d = d;
            this.numberplate = numberplate;
        }
        public override string ToString()
        {
            string s = this.numberplate + " driven by " + this.d.DriverName + ": \n";
            s += cl.ToString();
            return s;
        }
        public void AddClient(string clientname)
        {
            cl.Add(new Client(clientname));
        }
        public void RemoveClient(string clientName)
        {
            cl.Remove(clientName);
        }

        private class Client
        {
            public Client next;
            public string clientName;
            public Client(string clientName)
            {
                this.clientName = clientName;
            }
            public override string ToString()
            {
                return clientName;
            }

        }
        private class ClientList
        {
            private Client head;
            public ClientList()
            {
                head = null;
            }

            public void Add(Client c)
            {
                if (head==null)
                {
                    head = c;
                }
                else
                {
                    c.next = head;
                    head = c;
                }
            }
            public void Remove(string clientname)
            {
                if (head!=null&& head.clientName==clientname)
                {
                    head = head.next;
                }
                else
                {
                    Client temp = head;
                    Client last = head;

                    while (temp!=null)
                    {
                        if (temp.clientName==clientname)
                        {
                            last.next = temp.next;
                        }
                        last = temp;
                        temp = temp.next;
                    }
                }
            }
            public override string ToString()
            {
                Client current = head;
                String retString = "";
                while (current != null)
                {
                    retString += current.ToString() + "\n";
                    current = current.next;
                }

                return retString;
            }
        }
    }
}
