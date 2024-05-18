namespace Common.Table
{
    public static class TableName
    {
        #region table name for user
        public const string User = "User";
        public const string Customer = "Customer";
        public const string ImportAgent = "ImportAgent";
        #endregion

        #region table name for invoice
        public const string InvoiceImport = "InvoiceImport";
        public const string InvoiceImportDetail = "InvoiceImportDetail";

        public const string InvoiceLaundry = "InvoiceLaundry";

        public const string InvoiceSell = "InvoiceSell";
        public const string InvoiceSellDetail = "InvoiceSellDetail";

        public const string InvoiceSellCurtain = "InvoiceSellCurtain";
        #endregion

        #region table name for Payment
        public const string PaymentDetail = "PaymentDetail";
        public const string Payment = "Payment";
        #endregion

        #region name table for store entity
        public const string Laundry = "Laundry";
        public const string PiceLaundry = "PiceLaundry";
        public const string Merchandise = "Merchandise";
        public const string PiceMerchandise = "PiceMerchandise";
        public const string SewCurtain = "SewCurtain";
        public const string PriceSewCurtain = "PriceSewCurtain";
        #endregion

    }
}
