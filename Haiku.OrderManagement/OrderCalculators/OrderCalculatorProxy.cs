using Contracts;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.OrderCalculators
{
    class OrderCalculatorProxy
    {
        Customer proxyCustomer;
        IOrderManagement proxyContract;

        public uint CalculateOrderCosts(Customer customer, IOrderManagement contract)
        {
            proxyCustomer = customer;
            proxyContract = contract;
            OrderCalculator orderCalc = new OrderCalculator();
            return orderCalc.CalculateOrderCosts(proxyCustomer, proxyContract);
        }

        public uint CalculateOrderCosts()
        {
            return this.CalculateOrderCosts(proxyCustomer, proxyContract);
        }

    }
}
