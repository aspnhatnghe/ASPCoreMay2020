using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Common
{
    public enum LoaiHinh
    {
        Loai = 1,
        HangHoa = 2,
        NhaSanXuat = 3,
        KhachHang = 4        
    }

    public static class MyRole
    {
        public const string SuperAdmin = "SuperAdmin";
        public const string Administrator = "Administrator";
        public const string Customer = "Customer";
        public const string Accountant = "Accountant";
        public const string Guest = "Guest";
    }
    public enum Role
    {
        [Description("SuperAdmin")]
        SuperAdmin = 4,
        [Description("Administrator")]
        Administrator = 3,
        [Description("Customer")]
        Customer = 1,
        [Description("Accountant")]
        Accountant = 2,
        [Description("Guest")]
        Guest = 0
    }

    public enum OrderStatus
    {
        [Description("Open")]
        Open = 0,
        [Description("Confirmed")]
        Confirmed = 1,
        [Description("Paid")]
        Paid = 2,
        [Description("Done")]
        Done = 3,
        [Description("Cancel")]
        Cancel = 4
    }

    public enum PaymentMethod
    {
        COD,
        CreditCard,
        Tranfer,
        InternetBanking,
        SMSBanking,
        MobileBanking
    }

    public enum CouponStatus
    {
        [Description("New")]
        New,
        [Description("Used")]
        Used,
        [Description("Expired")]
        Expired
    }
}
