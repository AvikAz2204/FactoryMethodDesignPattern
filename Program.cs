using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            string val;
            Console.Write("Enter aggregator: ");
            val = Console.ReadLine();

            param P1 = new param();


            Creator factory = new ConcreteCreator();

            IDoPayment billPay = factory.FactoryMethod(val);
            billPay.billPayment(P1);



            Console.ReadKey();
        }
    }
}


class param
{
    string userName { get; set; }
}

namespace FactoryPattern
{
    

    interface IDoPayment
    {
        void billPayment(param P1);
    }

    class O2Payment : IDoPayment
    {
        public void billPayment(param p1)
        {
            Console.WriteLine("BillPayment From O2");
        }
    }

    class BDPayment : IDoPayment
    {
        public void billPayment(param p1)
        {
            Console.WriteLine("BillPayment From BD");
        }
    }

    abstract class Creator
    {
        public abstract IDoPayment FactoryMethod(string type);
    }

    class ConcreteCreator : Creator
    {
        public override IDoPayment FactoryMethod(string type)
        {
            switch (type)
            {
                case "BD": return new BDPayment();
                case "O2": return new O2Payment();
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }



}