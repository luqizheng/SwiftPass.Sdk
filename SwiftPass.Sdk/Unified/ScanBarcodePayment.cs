using System;
using System.Collections.Generic;
using SwiftPass.Sdk.Utils;

namespace SwiftPass.Sdk.Unified
{
    public class ScanBarcodePayment:RequestBase
    {
        public ScanBarcodePayment(string outTradeNo, string body, int totalFee, string mchCreateIp,
            string authCode) : base("unified.trade.micropay")
        {
            this.OutTradeNo = outTradeNo;
            this.Body = body;
            this.TotalFee = totalFee;
            this.MchCreateIp = mchCreateIp;
            this.AuthCode = authCode;
        }

        protected override void FillTo(IDictionary<string, string> data)
        {
            base.FillTo(data);
            data.AddOrUpdateValueToDic("out_trade_no", this.OutTradeNo);
            data.AddOrUpdateValueToDic("device_info", this.DeviceInfo);
            data.AddOrUpdateValueToDic("body", this.Body);
            data.AddOrUpdateValueToDic("goods_detail", this.GoodsDetail);
            data.AddOrUpdateValueToDic("attach", this.Attach);
            data.AddOrUpdateValueToDic("total_fee", this.TotalFee.ToString());
            data.AddOrUpdateValueToDic("mch_create_ip", this.MchCreateIp);
            data.AddOrUpdateValueToDic("auth_code", this.AuthCode);
            data.AddOrUpdateValueToDic("time_start", this.TimeStart);
            data.AddOrUpdateValueToDic("time_expire", this.TimeExpire);
            data.AddOrUpdateValueToDic("op_user_id", this.OpUserId);
            data.AddOrUpdateValueToDic("op_shop_id", this.OpShopId);
            data.AddOrUpdateValueToDic("op_device_id", this.OpDeviceId);
            data.AddOrUpdateValueToDic("goods_tag", this.GoodsTag);
        }

        /// <summary>
        ///商户订单号商户系统内部的订单号 ,5到32个字符、 只能包含字母数字或者下划线，区分大小写，确保在商户系统唯一是必填：是 
        /// </summary>
        public string OutTradeNo { get; set; }
        /// <summary>
        ///设备号终端设备号，商户自定义。特别说明：对于QQ钱包支付，此参数必传，否则会报错。是必填：否 
        /// </summary>
        public string DeviceInfo { get; set; }
        /// <summary>
        ///商品描述商品描述是必填：是 
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        ///单品信息单品优惠活动该字段必传，且必须按照规范上传，JSON格式，详见【单品优惠活动字段说明】是必填：否 
        /// </summary>
        public string GoodsDetail { get; set; }
        /// <summary>
        ///附加信息商户附加信息，可做扩展参数是必填：否 
        /// </summary>
        public string Attach { get; set; }
        /// <summary>
        ///总金额总金额，以分为单位，不允许包含任何字、符号是必填：是 
        /// </summary>
        public int TotalFee { get; set; }
        /// <summary>
        ///终端IP订单生成的机器 IP是必填：是 
        /// </summary>
        public string MchCreateIp { get; set; }
        /// <summary>
        ///授权码扫码支付授权码， 设备读取用户展示的条码或者二维码信息是必填：是 
        /// </summary>
        public string AuthCode { get; set; }
        /// <summary>
        ///订单生成时间订单生成时间，格式为yyyymmddhhmmss，如2009年12月25日9点10分10秒表示为20091225091010。时区为GMT+8 beijing。该时间取自商户服务器。注：订单生成时间与超时时间需要同时传入才会生效。是必填：否 
        /// </summary>
        public DateTime? TimeStart { get; set; }
        /// <summary>
        ///订单超时时间订单失效时间，格式为yyyymmddhhmmss，如2009年12月27日9点10分10秒表示为20091227091010。时区为GMT+8 beijing。该时间取自商户服务器。注：订单生成时间与超时时间需要同时传入才会生效。是必填：否 
        /// </summary>
        public DateTime? TimeExpire { get; set; }
        /// <summary>
        ///操作员操作员帐号,默认为商户号是必填：否 
        /// </summary>
        public string OpUserId { get; set; }
        /// <summary>
        ///门店编号是必填：否 
        /// </summary>
        public string OpShopId { get; set; }
        /// <summary>
        ///设备编号是必填：否 
        /// </summary>
        public string OpDeviceId { get; set; }
        /// <summary>
        ///商品标记商品标记是必填：否 
        /// </summary>
        public string GoodsTag { get; set; }


    }
}
