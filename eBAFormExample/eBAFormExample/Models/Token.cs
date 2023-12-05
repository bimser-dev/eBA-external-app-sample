namespace eBAFormExample.Models
{
    public class Token
    {
        public string IdField { get; set; }
        public string LanguageField { get; set; }
        public string UserIdField { get; set; }
        public string UsernameField { get; set; }
        public bool TwoFactorAuthenticationEnabledField { get; set; }
        public string MFAParamsField { get; set; }
        public bool WebDelegationField { get; set; }
        public int DelegationIdField { get; set; }
        public string CaptchaImageField { get; set; }
        public string WebViewUrlField { get; set; }
    }
}
