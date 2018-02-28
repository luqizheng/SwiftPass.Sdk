using System;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SwiftPass.Sdk;
using SwiftPass.Sdk.Alipay.QrCode;
using SwiftPass.Sdk.Unified;
using SwiftPass.Sdk.Wechat;
using SwiftPass.Sdk.Wechat.H5Payment;
using SwiftPass.Sdk.Wechat.QrCode;

namespace SwiftPass.Test
{
    [TestClass]
    public class SwiftPassServiceTest
    {

        [TestMethod]
        public void 微信二维码获取()
        {
            var setting = Setting.SettingHelper.Setting();
            var logger = new LoggerFactory().CreateLogger<SwiftPassService>();
            var service = new SwiftPassService(setting.Url, setting.MerchantNumber, setting.Key, logger);
          
            ScanQrCodePayment scanCodePayment=new ScanQrCodePayment(Guid.NewGuid().ToString("N"),"玩具枪",100,setting.NotifyUrl,"192.168.1.100");

            var result= service.GetPayCode(scanCodePayment);
            Assert.AreEqual(result.Status, "0");
        }

        [TestMethod]
        public void ScanBarCode()
        {
            var setting = Setting.SettingHelper.Setting();
            var logger = new LoggerFactory().CreateLogger<SwiftPassService>();
            var service = new SwiftPassService(setting.Url, setting.MerchantNumber, setting.Key, logger);
            var payment=new ScanBarcodePayment(Guid.NewGuid().ToString("N"),"垃圾",100,"192.168.2.5","134963456781739211");
            var result = service.ScanBarCode(payment);
            var query = service.Query(new QueryPayment(result.OutTradeNo, result.TransactionId));
            var refund =
                service.Refund(new RefundPayment(result.OutTradeNo, result.TransactionId, "225222", 1, 1, "12121"));
            var queryrefund = service.QueryRefund(new RefundQueryInfo(result.OutTradeNo,result.TransactionId,refund.OutRefundNo,refund.RefundId));
            Assert.AreEqual(result.Status, "0");

        }

        [TestMethod]
        public void GetAlipayCode()
        {
            var setting = Setting.SettingHelper.Setting();
            var logger = new LoggerFactory().CreateLogger<SwiftPassService>();
            var service = new SwiftPassService(setting.Url, setting.MerchantNumber, setting.Key, logger);
            var result= service.GetAliPayCode(new ScanAliQrCodePayment(DateTime.Now.ToString("yyyyMMddHHmmss"), "无人机4kSpark", 1,
                "192.168.1.1", "http://localhost:8000/"));

            Assert.IsNotNull(result.CodeImgUrl);
            Console.WriteLine(result.CodeImgUrl);
            Console.WriteLine(result.CodeUrl);
        }

        [TestMethod]
        public void GetH5PayInfo()
        {
            var setting = Setting.SettingHelper.Setting();
            var logger = new LoggerFactory().CreateLogger<SwiftPassService>();
            var service = new SwiftPassService(setting.Url, "175510359638", "61307e5f2aebcacecbcca6fe5296df9c", logger);
            var result = service.PrepareForH5Payement(new PaymentInfoForWapRequest(DateTime.Now.ToString("yyyyMMddHHmmss"), "无人机4kSpark", 1, "192.168.1.1", "http://localhost:8000/", "AND_WAP", "https://m.jd.com", "京东商城"));
            Assert.AreEqual(result.ResultCode,"0");
        }



        [TestMethod]
        public void GetH5ForWeixinPayInfo()
        {
            var setting = Setting.SettingHelper.Setting();
            var logger = new LoggerFactory().CreateLogger<SwiftPassService>();
            var service = new SwiftPassService(setting.Url, setting.MerchantNumber, setting.Key, logger);
            //测试时appid为空。
            var result = service.PrepareForWeixinH5Payment(new PaymentInfoForWeixinRequest(true,DateTime.Now.ToString("yyyyMMddHHmmss"), "无人机4kSpark","", 1, "192.168.1.1", "http://localhost:8000/"));

            Assert.AreEqual(result.ResultCode, "0");
        }
    }
}
