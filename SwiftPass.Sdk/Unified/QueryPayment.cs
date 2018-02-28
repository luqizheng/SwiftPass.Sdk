using System.Collections.Generic;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Unified
{
    public class QueryPayment : RequestBase
    {
        /// <summary>
        /// 订单号及swift订单号至少一个不为空
        /// </summary>
        public QueryPayment(string outTradeNo, string transactionId) : base("unified.trade.query")
        {

            if (string.IsNullOrEmpty(outTradeNo)&& string.IsNullOrEmpty(transactionId))
            {
                throw new SwiftPassException("0001","第三方订单号与平台订单号不能同时为空！");
            }

            this.OutTradeNo = outTradeNo;
            this.TransactionId = transactionId;
          
        }

        protected override void FillTo(IDictionary<string, string> data)
        {
            base.FillTo(data);
            data.AddOrUpdateValueToDic("out_trade_no", this.OutTradeNo);
            data.AddOrUpdateValueToDic("transaction_id", this.TransactionId);

        }

        /// <summary>
        ///商户订单号商户系统内部的订单号, out_trade_no和transaction_id至少一个必填，同时存在时transaction_id优先是必填：否 
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        ///平台订单号平台交易号, out_trade_no和transaction_id至少一个必填，同时存在时transaction_id优先。是必填：否 
        /// </summary>
        public string TransactionId { get; set; }

    }
}
