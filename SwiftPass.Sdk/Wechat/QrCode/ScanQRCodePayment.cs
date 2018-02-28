using System;
using System.Collections.Generic;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Wechat.QrCode
{
    public class ScanQrCodePayment:RequestBase
    {
        public ScanQrCodePayment(string outTradeNo,string body, int totalFee, string notifyurl,string mchCreateIp):base("pay.weixin.native")
        {
            if (String.IsNullOrEmpty(outTradeNo))
                throw new ArgumentNullException(nameof(outTradeNo));
            if (string.IsNullOrEmpty(body))
                throw new ArgumentNullException(nameof(body));
            if (totalFee<=0)
                throw new ArgumentOutOfRangeException(nameof(totalFee));
            OutTradeNo = outTradeNo;
            Body = body;
            TotalFee = totalFee;
            MchCreateIp = mchCreateIp;
            NotifyUrl = notifyurl;
        }

        /// <summary>
        ///商户订单号商户系统内部的订单号 ,32个字符内、 可包含字母,确保在商户系统唯一是必填：是 
        /// </summary>
        public string OutTradeNo { get; set;}
        /// <summary>
        ///设备号终端设备号是必填：否 
        /// </summary>
        public string DeviceInfo { get; set;}
        /// <summary>
        ///商品描述商品描述是必填：是 
        /// </summary>
        public string Body { get; set;}
        /// <summary>
        ///附加信息商户附加信息，可做扩展参数是必填：否 
        /// </summary>
        public string Attach { get; set;}
        /// <summary>
        ///总金额总金额，以分为单位，不允许包含任何字、符号是必填：是 
        /// </summary>
        public int TotalFee { get; set;}
        /// <summary>
        ///终端IP订单生成的机器 IP是必填：是 
        /// </summary>
        public string MchCreateIp { get; set;}
        /// <summary>
        ///通知地址接收平台通知的URL，需给绝对路径，255字符内格式如:http://wap.tenpay.com/tenpay.asp，确保平台能通过互联网访问该地址是必填：是 
        /// </summary>
        public string NotifyUrl { get; set;}
        /// <summary>
        ///订单生成时间订单生成时间，格式为yyyyMMddHHmmss，如2009年12月25日9点10分10秒表示为20091225091010。时区为GMT+8 beijing。该时间取自商户服务器。注：订单生成时间与超时时间需要同时传入才会生效。是必填：否 
        /// </summary>
        public DateTime? TimeStart { get; set;}
        /// <summary>
        ///订单超时时间订单失效时间，格式为yyyyMMddHHmmss，如2009年12月27日9点10分10秒表示为20091227091010。时区为GMT+8 beijing。该时间取自商户服务器。注：订单生成时间与超时时间需要同时传入才会生效。是必填：否 
        /// </summary>
        public DateTime? TimeExpire { get; set;}
        /// <summary>
        ///操作员操作员帐号,默认为商户号是必填：否 
        /// </summary>
        public string OpUserId { get; set;}
        /// <summary>
        ///商品标记商品标记，微信平台配置的商品标记，用于优惠券或者满减使用是必填：否 
        /// </summary>
        public string GoodsTag { get; set;}
        /// <summary>
        ///商品 ID预留字段此 id 为静态可打印的二维码中包含的商品 ID，商户自行维护。是必填：否 
        /// </summary>
        public string ProductId { get; set;}
        /// <summary>
        ///是否限制信用卡限定用户使用时能否使用信用卡，值为1，禁用信用卡；值为0或者不传此参数则不禁用是必填：否 
        /// </summary>
        public string LimitCreditPay { get; set;}

    

        protected override void FillTo(IDictionary<string, string> data)
        {
            base.FillTo(data);
            data.AddOrUpdateValueToDic("out_trade_no", this.OutTradeNo);
            data.AddOrUpdateValueToDic("device_info", this.DeviceInfo);
            data.AddOrUpdateValueToDic("body", this.Body);
            data.AddOrUpdateValueToDic("attach", this.Attach);
            data.AddOrUpdateValueToDic("total_fee", this.TotalFee.ToString());
            data.AddOrUpdateValueToDic("mch_create_ip", this.MchCreateIp);
            data.AddOrUpdateValueToDic("notify_url", this.NotifyUrl);
            data.AddOrUpdateValueToDic("time_start", this.TimeStart);
            data.AddOrUpdateValueToDic("time_expire", this.TimeExpire);
            data.AddOrUpdateValueToDic("op_user_id", this.OpUserId);
            data.AddOrUpdateValueToDic("goods_tag", this.GoodsTag);
            data.AddOrUpdateValueToDic("product_id", this.ProductId);
            data.AddOrUpdateValueToDic("limit_credit_pay", this.LimitCreditPay);
        }
    }
}
