namespace Risk_Data_Access_Layer
{
    public class RiskDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public RiskDbContext(DbContextOptions<RiskDbContext> options):base(options)
        {
            
        }

        public DbSet<CallReason> CallReasons { get; set; }
        public DbSet<Governorate> governorates { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<SourceMarketing> sourceMarketings  { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<MobilePhone> MobilePhones { get; set; } 
        public DbSet<Call> Call { get; set; } 
        public DbSet<AgentClient> AgentClients { get; set; }   
        public DbSet<ClientCall> ClientCalls { get; set; }   
         
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Change Table Name Exist In Identity
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            //builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

            //Remove Column Exist In Identity
            //builder.Entity<IdentityUser>()
            //    .Ignore(e => e.Email);

            //Change Table Name && Remove Column Exist In Identity
            //builder.Entity<IdentityUser>()
            //    .ToTable("Users")
            //    .Ignore(e => e.Email);


        }

    }
}
