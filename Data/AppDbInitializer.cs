using LilyBase.Data.Static;
using LilyBase.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace LilyBase.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreated();
                SeedActors(context);
                SeedProducers(context);
                SeedMovies(context);
                SeedActorMovies(context);
            }
        }

        private static void SeedActors(AppDbContext context)
        {
            if (!context.Actors.Any())
            {
                context.Actors.AddRange(new List<Actor>
                {
                    new Actor { FullName = "Leonardo DiCaprio", Bio = "Leonardo DiCaprio is an American actor and film producer known for his work in biographical and period films.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" },
                    new Actor { FullName = "Scarlett Johansson", Bio = "Scarlett Johansson is an American actress and singer. She was the world's highest-paid actress in 2018 and 2019.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" },
                    new Actor { FullName = "Robert Downey Jr.", Bio = "Robert Downey Jr. is an American actor and producer. He is known for his roles in a wide variety of films, including his portrayal of Tony Stark/Iron Man in the Marvel Cinematic Universe.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" },
                    new Actor { FullName = "Meryl Streep", Bio = "Meryl Streep is an American actress. Often described as the 'best actress of her generation', Streep is particularly known for her versatility and accent adaptability.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" },
                    new Actor { FullName = "Denzel Washington", Bio = "Denzel Washington is an American actor, director, and producer. He has been described as an actor who reconfigured 'the concept of classic movie stardom'.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" },
                    new Actor { FullName = "Emma Watson", Bio = "Emma Watson is an English actress and activist. She is known for her roles in both blockbuster and independent films, as well as for her women's rights work.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" },
                    new Actor { FullName = "Morgan Freeman", Bio = "Morgan Freeman is an American actor and film narrator. He is known for his distinctive deep voice and various roles in a wide variety of film genres.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" },
                    new Actor { FullName = "Natalie Portman", Bio = "Natalie Portman is an Israeli-American actress and director. She is known for her versatility and roles in both blockbusters and independent films.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" },
                    new Actor { FullName = "Tom Hanks", Bio = "Tom Hanks is an American actor and filmmaker. Known for both his comedic and dramatic roles, Hanks is one of the most popular and recognizable film stars worldwide.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" },
                    new Actor { FullName = "Jennifer Lawrence", Bio = "Jennifer Lawrence is an American actress. The world's highest-paid actress in 2015 and 2016, her films have grossed over $6 billion worldwide.", ProfilePictureURL = "https://www.usmagazine.com/wp-content/uploads/2022/03/Will-Smith-Celeb-Bio.jpg?w=800&h=1421&crop=1&quality=40&strip=all" }
                });
                context.SaveChanges();
            }
        }

        private static void SeedProducers(AppDbContext context)
        {
            if (!context.Producers.Any())
            {
                context.Producers.AddRange(new List<Producer>
                {
                    new Producer
                    {
                        FullName = "Steven Spielberg",
                        Bio = "Steven Spielberg is an American film director, producer, and screenwriter. He is considered one of the founding pioneers of the New Hollywood era and one of the most popular directors and producers in film history.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMTQ1MTE4OTQwNF5BMl5BanBnXkFtZTcwNTUxNzY4Mg@@._V1_UY317_CR12,0,214,317_AL_.jpg"
                    },
                    new Producer
                    {
                        FullName = "Kathleen Kennedy",
                        Bio = "Kathleen Kennedy is an American film producer. In 1982, she co-founded Amblin Entertainment with Steven Spielberg and Frank Marshall. She has been president of Lucasfilm since 2012.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMjI1MjY1NDMyOV5BMl5BanBnXkFtZTgwNzY2MzY2OTE@._V1_UX214_CR0,0,214,317_AL_.jpg"
                    },
                    new Producer
                    {
                        FullName = "Quentin Tarantino",
                        Bio = "Quentin Tarantino is an American film director, screenwriter, producer, author, and actor. His films are characterized by nonlinear storylines, dark humor, and stylized violence.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BN2YyZjk5NmUtYTAxZC00ZTlhLThmMjQtMjI3NTU4YzcwMTNhXkEyXkFqcGdeQXVyMTA3MDk2NDg2._V1_UX214_CR0,0,214,317_AL_.jpg"
                    },
                    new Producer
                    {
                        FullName = "James Cameron",
                        Bio = "James Cameron is a Canadian filmmaker and environmentalist. He is known for making science fiction and epic films, including Titanic and Avatar, the former of which earned him the Academy Award for Best Director.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMTY5NzQwMDU4OF5BMl5BanBnXkFtZTcwODI4NzU5Nw@@._V1_UY317_CR11,0,214,317_AL_.jpg"
                    },
                    new Producer
                    {
                        FullName = "Jerry Bruckheimer",
                        Bio = "Jerry Bruckheimer is an American film and television producer. He has been active in the genres of action, drama, and science fiction.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMjU1NTM3MDcxMl5BMl5BanBnXkFtZTgwNzM1NDAyNjE@._V1_UX214_CR0,0,214,317_AL_.jpg"
                    },
                    new Producer
                    {
                        FullName = "Christopher Nolan",
                        Bio = "Christopher Nolan is a British-American film director, producer, and screenwriter. He is known for making personal, distinctive films within the Hollywood mainstream.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMjI4NTgzMzA0OF5BMl5BanBnXkFtZTgwMjk5OTM2MjE@._V1_UX214_CR0,0,214,317_AL_.jpg"
                    },
                    new Producer
                    {
                        FullName = "Martin Scorsese",
                        Bio = "Martin Scorsese is an American film director, producer, screenwriter, and actor. He is a recipient of the AFI Life Achievement Award for his contributions to the cinema and has directed landmark films.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMjI2NjQ5MDQ4MF5BMl5BanBnXkFtZTgwNjYxNDIzNDE@._V1_UY317_CR8,0,214,317_AL_.jpg"
                    },
                    new Producer
                    {
                        FullName = "J.J. Abrams",
                        Bio = "J.J. Abrams is an American film director, producer, screenwriter, and composer. He is known for his work in the genres of action, drama, and science fiction.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BNjM5MTQ1OTg0Nl5BMl5BanBnXkFtZTcwODMyODk4OA@@._V1_UY317_CR1,0,214,317_AL_.jpg"
                    },
                    new Producer
                    {
                        FullName = "George Lucas",
                        Bio = "George Lucas is an American film director, producer, screenwriter, and entrepreneur. He is best known for creating the Star Wars and Indiana Jones franchises.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMjIwNTU3MzkwOV5BMl5BanBnXkFtZTcwNzQyODk4OA@@._V1_UX214_CR0,0,214,317_AL_.jpg"
                    },
                    new Producer
                    {
                        FullName = "Peter Jackson",
                        Bio = "Peter Jackson is a New Zealand film director, screenwriter, and film producer. He is best known for directing the Lord of the Rings trilogy and the Hobbit trilogy.",
                        ProfilePictureURL = "https://m.media-amazon.com/images/M/MV5BMjI4Nzk1NjMyNl5BMl5BanBnXkFtZTcwNDE2NTU4NA@@._V1_UY317_CR1,0,214,317_AL_.jpg"
                    }
                });
                context.SaveChanges();
            }
        }

        private static void SeedMovies(AppDbContext context)
        {
            if (!context.Movies.Any())
            {
                context.Movies.AddRange(new List<Movie>
                {
                    new Movie
                    {
                        Name = "Inception",
                        Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                        ImageURL = "https://flxt.tmsimg.com/assets/p7825626_p_v8_af.jpg",
                        ReleaseDate = new DateTime(2010, 7, 16, 0, 0, 0, DateTimeKind.Utc),  // Release date set to July 16, 2010
                        ProducerId = 1,
                        MovieCategory = MovieCategory.Action
                    },
                    new Movie
                    {
                        Name = "The Godfather",
                        Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                        ImageURL = "https://m.media-amazon.com/images/M/MV5BMDUyZTAzYWYtOWM2My00NDk4LTkwY2UtM2I3MGIyNTQ5YTg2XkEyXkFqcGdeQXVyMTA0MTM5NjI2._V1_.jpg",
                        ReleaseDate = new DateTime(1972, 3, 24, 0, 0, 0, DateTimeKind.Utc),  // Release date set to March 24, 1972
                        ProducerId = 2,
                        MovieCategory = MovieCategory.Drama
                    },
                    new Movie
                    {
                        Name = "Pulp Fiction",
                        Description = "The lives of two mob hitmen, a boxer, a gangster's wife, and a pair of diner bandits intertwine in four tales of violence and redemption.",
                        ImageURL = "https://m.media-amazon.com/images/I/71c05lTE03L._AC_SY679_.jpg",
                        ReleaseDate = new DateTime(1994, 10, 14, 0, 0, 0, DateTimeKind.Utc),  // Release date set to October 14, 1994
                        ProducerId = 3,
                        MovieCategory = MovieCategory.Action
                    },
                    new Movie
                    {
                        Name = "The Dark Knight",
                        Description = "When the menace known as the Joker emerges from his mysterious past, he wreaks havoc and chaos on the people of Gotham.",
                        ImageURL = "https://upload.wikimedia.org/wikipedia/en/1/1c/The_Dark_Knight_%282008_film%29.jpg",
                        ReleaseDate = new DateTime(2008, 7, 18, 0, 0, 0, DateTimeKind.Utc),  // Release date set to July 18, 2008
                        ProducerId = 4,
                        MovieCategory = MovieCategory.Action
                    },
                    new Movie
                    {
                        Name = "Forrest Gump",
                        Description = "The presidencies of Kennedy and Johnson, the Vietnam War, the Watergate scandal, and other historical events unfold.",
                        ImageURL = "https://flxt.tmsimg.com/assets/p7825626_p_v8_af.jpg",
                        ReleaseDate = new DateTime(1994, 7, 6, 0, 0, 0, DateTimeKind.Utc),  // Release date set to July 6, 1994
                        ProducerId = 5,
                        MovieCategory = MovieCategory.Drama
                    },
                    new Movie
                    {
                        Name = "The Matrix",
                        Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.",
                        ImageURL = "https://m.media-amazon.com/images/I/51EG732BV3L.jpg",
                        ReleaseDate = new DateTime(1999, 3, 31, 0, 0, 0, DateTimeKind.Utc),  // Release date set to March 31, 1999
                        ProducerId = 1,
                        MovieCategory = MovieCategory.Drama
                    }
                });
                context.SaveChanges();
            }
        }

        private static void SeedActorMovies(AppDbContext context)
        {
            if (!context.Actors_Movies.Any())
            {
                context.Actors_Movies.AddRange(new List<Actor_Movie>
                {
                    new Actor_Movie { ActorId = 1, MovieId = 1 },
                    new Actor_Movie { ActorId = 3, MovieId = 1 },
                    new Actor_Movie { ActorId = 1, MovieId = 2 },
                    new Actor_Movie { ActorId = 4, MovieId = 2 },
                    new Actor_Movie { ActorId = 1, MovieId = 3 },
                    new Actor_Movie { ActorId = 2, MovieId = 3 },
                    new Actor_Movie { ActorId = 5, MovieId = 3 },
                    new Actor_Movie { ActorId = 2, MovieId = 4 },
                    new Actor_Movie { ActorId = 3, MovieId = 4 },
                    new Actor_Movie { ActorId = 4, MovieId = 4 },
                    new Actor_Movie { ActorId = 2, MovieId = 5 },
                    new Actor_Movie { ActorId = 3, MovieId = 5 },
                    new Actor_Movie { ActorId = 4, MovieId = 5 },
                    new Actor_Movie { ActorId = 5, MovieId = 5 },
                    new Actor_Movie { ActorId = 3, MovieId = 6 },
                    new Actor_Movie { ActorId = 4, MovieId = 6 },
                    new Actor_Movie { ActorId = 5, MovieId = 6 }
                });
                context.SaveChanges();
            }
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                await EnsureRoleExists(roleManager, UserRoles.Admin);
                await EnsureRoleExists(roleManager, UserRoles.User);

                await EnsureUserExists(userManager, "admin@lilybase.com", "admin", UserRoles.Admin);
                await EnsureUserExists(userManager, "user@lilybase.com", "app-user", UserRoles.User);
            }
        }

        private static async Task EnsureRoleExists(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        private static async Task EnsureUserExists(UserManager<ApplicationUser> userManager, string email, string username, string role)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                var newUser = new ApplicationUser
                {
                    FullName = username,
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newUser, "Coding@1234?");
                await userManager.AddToRoleAsync(newUser, role);
            }
        }
    }
}
