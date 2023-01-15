namespace SecuringWebApiUsingJwtAuthentication.Settings
{
    public class JWT
    {
        public string Key { get; set; }
        //Key – The Super Secret Key that will be used for Encryption.You can move this somewhere else for extra security.
        public string Issuer { get; set; }
        //Issuer – identifies the principal that issued the JWT.
        public string Audience { get; set; }
        //Audience – identifies the recipients that the JWT is intended for.
        public double DurationInMinutes { get; set; }
        //DurationInMinutes – Defines the Minutes the generated JWT will remain valid.
    }
}
