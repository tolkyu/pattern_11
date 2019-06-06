using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeZ
{
    public class Client : IObserver
    {
        public double USD { get; set; }
        public double BTC { get; set; }
        public double CourseForSell { get; set; }
        public double SummForSell { get; set; }
        public double CourseForBuy { get; set; }
        public double SummForBuy { get; set; }
        public string Login { get; set; }
        public void Update(IMyObservable observevable)
        {
            Stock stock = observevable as Stock;
            if (stock.BTCCourse <= this.CourseForBuy)
            {
                if (this.SummForBuy * stock.BTCCourse < this.USD)
                {
                    this.BTC += this.SummForBuy;
                    this.USD -= this.SummForBuy * stock.BTCCourse;
                    this.SummForBuy = 0;
                }
            }
            else
            {
                if (stock.BTCCourse >= this.CourseForSell)
                {
                    if (this.BTC>this.SummForSell)
                    {
                        this.USD += this.SummForSell * stock.BTCCourse;
                        this.BTC -= this.SummForSell;
                        this.SummForSell = 0;
                    }
                }
            }
        }
    }
}
