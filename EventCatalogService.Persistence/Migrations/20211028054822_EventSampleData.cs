using Microsoft.EntityFrameworkCore.Migrations;

namespace EventCatalogService.Persistence.Migrations
{
    public partial class EventSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] {
                    "Id",
                    "EventName",
                    "Price",
                    "Artist",
                    "Date",
                    "Description",
                    "ImageUrl",
                    "CategoryId",
                    "Version"
                },
                values: new object[,]
                {
                    {
                        "event-2df9f69f-1f58-44d8-a331-01894722e238",
                        "To the Moon and Back",
                        "135",
                        "Nick Sailor",
                        "2021-05-09 17:47:01.0403256",
                        "The critics are over the moon and so will you after you've watched this sing and dance extravaganza written by Nick Sailor, the man from 'My dad and sister'.",
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg",
                        "category-6313179f-7837-473a-a4d5-a5571b43e6a6",
                        "1"
                    },

                    {
                        "event-35fdb7c1-be9d-4afb-b10d-66f3fbf9daf8",
                        "Techorama 2021",
                        "400",
                        "Many",
                        "2021-07-09 17:47:01.0403208",
                        "The best tech conference in the world",
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg",
                        "category-6313179f-7837-473a-a4d5-a5571b43e6a6",
                        "1"
                    },
                    {
                        "event-4e7a4aba-9ec7-4bc2-9899-8123797c7ea3",
                        "John Egbert Live",
                        "65",
                        "John Egbert",
                        "2021-03-09 17:47:01.0369024",
                        "Join John for his farwell tour across 15 continents. John really needs no introduction since he has already mesmerized the world with his banjo.",
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg",
                        "category-6313179f-7837-473a-a4d5-a5571b43e6a6",
                        "1"
                    },

                    {
                        "event-545d2628-12e2-4fbd-a217-807eb08bc562",
                        "The State of Affairs: Michael Live!",
                        "85",
                        "Michael Johnson",
                        "2021-06-09 17:47:01.0402916",
                        "Michael Johnson doesn't need an introduction. His 25 concert across the globe last year were seen by thousands. Can we add you to the list?",
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg",
                        "category-6313179f-7837-473a-a4d5-a5571b43e6a6",
                        "1"
                    },

                    {
                        "event-56782850-60f5-40c1-ba2b-1c358d6c5e65",
                        "Clash of the DJs",
                        "85",
                        "DJ 'The Mike'",
                        "2021-01-09 17:47:01.0403072",
                        "DJs from all over the world will compete in this epic battle for eternal fame.",
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg",
                        "category-6313179f-7837-473a-a4d5-a5571b43e6a6",
                        "1"
                    },

                    {
                        "event-71b4a729-51ab-4b16-915e-1cbabfa27a6f",
                        "Spanish guitar hits with Manuel",
                        "25",
                        "Manuel Santinonisi",
                        "2021-01-09 17:47:01.0403112",
                        "Get on the hype of Spanish Guitar concerts with Manuel.",
                        "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg",
                        "category-6313179f-7837-473a-a4d5-a5571b43e6a6",
                        "1"
                    }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Event",
                keyColumn: "Id",
                keyValues: new object[]
                {
                   "event-2df9f69f-1f58-44d8-a331-01894722e238",
                    "event-35fdb7c1-be9d-4afb-b10d-66f3fbf9daf8",
                    "event-4e7a4aba-9ec7-4bc2-9899-8123797c7ea3",
                    "event-545d2628-12e2-4fbd-a217-807eb08bc562",
                    "event-56782850-60f5-40c1-ba2b-1c358d6c5e65",
                    "event-71b4a729-51ab-4b16-915e-1cbabfa27a6f"
                });
        }
    }
}

    