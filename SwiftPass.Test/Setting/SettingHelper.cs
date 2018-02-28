namespace SwiftPass.Test.Setting
{
    public static class SettingHelper
    {
        public static Setting Setting()
        {
            return new Setting("wr")
            {

                MerchantNumber = "7551000001",
                Url = "https://pay.swiftpass.cn/pay/gateway",
                Key = "9d101c97133837e13dde2d32a5054abb",
                NotifyUrl = "http://127.0.0.1/notifyurl",

            };
        }
    }
}