namespace GoodbyeUsp.Sources
{
    public class Person
    {
        public class PersonDoc
        {
            public int Type { get; set; }
            public string Number { get; set; }
            public DateTime? Date { get; set; }
            public string? DocInstance { get; set; }
        }
        
        IList<PersonDoc> _docs = new List<PersonDoc>();

        public int ClientId { get; set; }
        public string? Name { get; set; }
        public string Fam { get; set; }
        public string? Otch { get; set; }
        public int Vlad { get; set; }
        public string TaxCode { get; set; }
        public string Passport { get; set; }
        public DateTime? PassportIssueDate { get; set; }
        public string? PassportIssuer { get; set; }
        public int DocType { get; set; }

        public Person Build()
        {
            if (Vlad == 1)
            {
                if (!string.IsNullOrEmpty(TaxCode))
                {
                    _docs.Add(new PersonDoc
                    {
                        Type = 19,
                        Number = TaxCode.Length > 10 ? TaxCode[..10] : TaxCode,
                    });
                }
                if (!string.IsNullOrEmpty(Passport))
                {
                    _docs.Add(new PersonDoc
                    {
                        Type = 1,
                        Number = Passport.Length > 15 ? Passport[..15] : Passport,
                        Date = PassportIssueDate,
                        DocInstance = PassportIssuer?.Length > 50 ? PassportIssuer[..50] : PassportIssuer,
                    });
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(Fam))
                {
                    var s = Fam.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                    Fam = s[0];
                    switch (s.Length)
                    {
                        case 2:
                            Name = s[1].Length > 20 ? s[1][..20] : s[1];
                            break;
                        case > 2:
                            Name = s[1].Length > 20 ? s[1][..20] : s[1];
                            Otch = s[2].Length > 20 ? s[2][..20] : s[2];
                            break;
                    }
                }
                if (!string.IsNullOrEmpty(Passport))
                {
                    var cert = Passport.Trim();
                    _docs.Add(new PersonDoc
                    {
                        Type = 8,
                        Date = PassportIssueDate,
                        Number = cert.Length > 15 ? cert[..15] : cert,
                        DocInstance = PassportIssuer?.Length > 50 ? PassportIssuer[..50] : PassportIssuer,
                    });
                }
            }

            if (Fam.Length > 20) Fam = Fam[..20];
            if (Name?.Length > 20) Name = Name[..20];
            if (Otch?.Length > 20) Otch = Otch[..20];

            return this;
        }

        public IEnumerable <PersonDoc> Docs { get => _docs; }
    }
}
