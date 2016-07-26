#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;
#endregion

namespace Contracts
{

    public class OrderRecord
    {

        private IDAL _repository;

        public OrderRecord(IDAL repository)
        {
            _repository = repository;
        }

        public bool CustomerHRADeductionEligible(Customer customer)
        {
            uint val = _repository.HRA(customer);

            if (val > 0)
                return true;
            else
                return false;
        }

    }

}
