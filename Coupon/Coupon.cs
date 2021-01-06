using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coupon
{
    [Serializable]  //将类标记为可序列化
    public class Coupon : INotifyPropertyChanged
    {
        [field: NonSerialized()]    //将可序列化的类中的某字段标记为不被序列化
        public event PropertyChangedEventHandler PropertyChanged;

        public decimal Amount { get; set; }

        public float InterestRate { get; set; }

        public int Term { get; set; }

        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Customer"));
            }
        }

        public Coupon(decimal amount, float interestRate, int term, string name)
        {
            Amount = amount;
            InterestRate = interestRate;
            Term = term;
            _name = name;
        }
    }
}
