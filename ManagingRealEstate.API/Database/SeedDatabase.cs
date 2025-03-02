using ManagingRealEstate.API.Models;

namespace ManagingRealEstate.API.Database;

public class SeedData
{
    public static void SeedDatabase(IHost app)

    {
        using (var scope = app.Services.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            if (!context.Set<RealEstate>().Any())
            {

                context.Set<RealEstate>().AddRange(
                    RealEstate.Create("Luxury Villa", "A beautiful luxury villa with a sea view.", 1500000, "Malibu, CA"),
                    RealEstate.Create("Modern Apartment", "A modern apartment in the city center.", 500000, "New York, NY"),
                    RealEstate.Create("Cozy Cottage", "A cozy cottage in the countryside.", 300000, "Nashville, TN"),
                    RealEstate.Create("Beach House", "A stunning beach house with private access to the beach.", 1200000, "Miami, FL"),
                    RealEstate.Create("Penthouse Suite", "A luxurious penthouse suite with panoramic city views.", 2000000, "Los Angeles, CA"),
                    RealEstate.Create("Suburban Home", "A spacious suburban home with a large backyard.", 600000, "Austin, TX"),
                    RealEstate.Create("Mountain Cabin", "A rustic mountain cabin with breathtaking views.", 400000, "Denver, CO"),
                    RealEstate.Create("Downtown Loft", "A trendy downtown loft with modern amenities.", 700000, "Chicago, IL"),
                    RealEstate.Create("Historic Mansion", "A historic mansion with elegant architecture.", 2500000, "Savannah, GA"),
                    RealEstate.Create("Country Estate", "A sprawling country estate with extensive grounds.", 1800000, "Charlottesville, VA"),
                    RealEstate.Create("Urban Condo", "A stylish urban condo with modern features.", 800000, "San Francisco, CA"),
                    RealEstate.Create("Lake House", "A serene lake house with beautiful views.", 900000, "Lake Tahoe, NV"),
                    RealEstate.Create("Ranch Property", "A large ranch property with ample space.", 1100000, "Dallas, TX"),
                    RealEstate.Create("City Studio", "A compact city studio perfect for singles.", 350000, "Seattle, WA"),
                    RealEstate.Create("Luxury Townhouse", "A luxury townhouse with high-end finishes.", 950000, "Boston, MA"),
                    RealEstate.Create("Eco-Friendly Home", "An eco-friendly home with solar panels.", 750000, "Portland, OR"),
                    RealEstate.Create("Golf Course Villa", "A villa located on a prestigious golf course.", 1300000, "Scottsdale, AZ"),
                    RealEstate.Create("Ski Chalet", "A cozy ski chalet near popular ski resorts.", 1200000, "Aspen, CO"),
                    RealEstate.Create("Country Farmhouse", "A charming country farmhouse with land.", 650000, "Lexington, KY"),
                    RealEstate.Create("Modern Bungalow", "A modern bungalow with open floor plan.", 550000, "San Diego, CA")
                );

                context.SaveChanges();
            }
        }
    }
}
