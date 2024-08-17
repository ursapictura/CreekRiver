using Microsoft.EntityFrameworkCore;
using CreekRiver.Models;

public class CreekRiverDbContext : DbContext
{

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Campsite> Campsites { get; set; }
    public DbSet<CampsiteType> CampsiteTypes { get; set; }

    public CreekRiverDbContext(DbContextOptions<CreekRiverDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // seed data with campsite types
        modelBuilder.Entity<CampsiteType>().HasData(new CampsiteType[]
        {
            new CampsiteType {Id = 1, CampsiteTypeName = "Tent", FeePerNight = 15.99M, MaxReservationDays = 7},
            new CampsiteType {Id = 2, CampsiteTypeName = "RV", FeePerNight = 26.50M, MaxReservationDays = 14},
            new CampsiteType {Id = 3, CampsiteTypeName = "Primitive", FeePerNight = 10.00M, MaxReservationDays = 3},
            new CampsiteType {Id = 4, CampsiteTypeName = "Hammock", FeePerNight = 12M, MaxReservationDays = 7}
        });
    
        modelBuilder.Entity<Campsite>().HasData(new Campsite[]
        {
            new Campsite {Id = 1, CampsiteTypeId = 1, Nickname = "Barred Owl", ImageUrl="https://tnstateparks.com/assets/images/content-images/campgrounds/249/colsp-area2-site73.jpg"},
            new Campsite {Id = 2, CampsiteTypeId = 1, Nickname = "Lost Creek", ImageUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fpreview.redd.it%2Fh9oy39veczm31.jpg%3Fauto%3Dwebp%26s%3D42f8149eddd1363b3f8baac4025a4b2fd5efad15&f=1&nofb=1&ipt=84056e1c343e94ed646607de327110864634f3edbf6af9a4a3b4af468ed53b0c&ipo=images"},
            new Campsite {Id = 3, CampsiteTypeId = 2, Nickname = "Possum Ridge", ImageUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fc1.staticflickr.com%2F3%2F2945%2F15278631320_b932233cd4_b.jpg&f=1&nofb=1&ipt=df80a9e956a567079c7ce7a46fd4cc837e53371e84dfac4ad53fd42ab1cefdf0&ipo=images"},
            new Campsite {Id = 4, CampsiteTypeId = 3, Nickname = "Raccoon Cove", ImageUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fimages.squarespace-cdn.com%2Fcontent%2Fv1%2F57689a02e4fcb58e1ae15194%2F1600614652047-CWASI46NNCC1W6PQ1IFY%2FIMG_8859.JPG&f=1&nofb=1&ipt=14e82ec8647534044ce5e007eface7d022176784e0e45763a46f07348c63afd1&ipo=images"},
            new Campsite {Id = 5, CampsiteTypeId = 3, Nickname = "Window Cliff", ImageUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Foptimise2.assets-servd.host%2Fmaterial-civet%2Fproduction%2Fimages%2FWindow-Cliffs-5.jpg%3Fw%3D800%26h%3D540%26auto%3Dcompress%252Cformat%26fit%3Dcrop%26dm%3D1654183389%26s%3D4c14054c347b5ad826835d30b884d5b0&f=1&nofb=1&ipt=4a5c8106f0a1abef4e4d322c01fb9ea7d14e1d69f43e5023887a388ef1eed83b&ipo=images"},
            new Campsite {Id = 6, CampsiteTypeId = 4, Nickname = "Glow Worm Hallow", ImageUrl="https://external-content.duckduckgo.com/iu/?u=https%3A%2F%2Fwww.travel4wildlife.com%2Fwp-content%2Fuploads%2F2021%2F05%2Fglow-worm-caves-tennessee.jpg&f=1&nofb=1&ipt=ba9891583eb7dc3f151ed53261714397c7f211ffbfce6d36a02c9846f54612fd&ipo=images"},
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile[]
        {
            new UserProfile {Id = 1, FirstName = "Charlie", LastName = "Green", Email = "chargreen@gmail.com"}
        });
        
        modelBuilder.Entity<Reservation>().HasData(new Reservation[]
        {
            new Reservation {Id = 1, CampsiteId = 4, UserProfileId = 1, CheckinDate = new DateTime(2024, 09, 23), CheckoutDate = new DateTime(2024, 09, 25)}
        });
    }
}