using System.Collections.Generic;
using Hackatown.Backend.Model;

namespace Hackatown.Backend
{
    public static class FakeDatabase
    {
        public static Dictionary<string, Building> Buildings { get; private set; }

        static FakeDatabase()
        {
            Buildings = new Dictionary<string, Building>
            {
                {
                    "", new Building
                    {
                        Img = Resource.Drawable.Index,
                        Description = "Malheureusement ca fonctionne pas!"
                    }
                },
                {
                    "Polytechnique", new Building
                    {
                        Img = Resource.Drawable.Poly,
                        Description = "L'École Polytechnique de Montréal (Polytechnique Montréal) est un établissement d'enseignement supérieur d'ingénierie affilié à l'Université de Montréal, situé à Montréal (Québec) et fondé en 1873. En plus de ses programmes de baccalauréat, Polytechnique Montréal offre une formation aux cycles supérieurs et est une des plus importantes institutions de recherche en génie au Canada.",
                        Lat = 45.504384,
                        Long = -73.6150716
                    }
                },
                {
                    "Universite de Montreal", new Building
                    {
                        Img = Resource.Drawable.Udem,
                        Description = "L'université de Montréal (UdeM) est l'un des quatre établissements d'enseignement supérieur de Montréal au Québec. Elle est l'une des cinq grandes universités du Canada (la deuxième en terme du nombre d'étudiants) et parallèlement la plus importante au Québec pour le nombre d'étudiants ainsi que pour la recherche. Elle est classée parmi les meilleures universités au monde et bénéficie d'une grande réputation en tant que l'une des meilleures institutions post-secondaires dans le monde francophone. Elle est reconnue parmi les meilleures institutions d'enseignement supérieur dans le monde francophone.",
                        Lat = 45.5056156,
                        Long = -73.6159479
                    }
                },
                {
                    "Oratoire St-Joseph", new Building
                    {
                        Img = Resource.Drawable.Oratoire,
                        Description = @"L'oratoire Saint-Joseph est une église à Montréal (Québec), bâtie sur le versant nord-ouest du mont Royal. Cet établissement catholique est situé au 3800, chemin Queen-Mary (quartier Côte-des-Neiges de l'arrondissement Côte-des-Neiges–Notre-Dame-de-Grâce)2. L'élément secondaire du site est la basilique catholique. Structure unique, les dimensions de la basilique et de son dôme sont impressionnantes. Le dôme a 60 m de hauteur interne et 39 m de diamètre et sa croix, point culminant de Montréal, atteint 300 m3. Dans les jardins de l'oratoire, on peut suivre un chemin de croix grandeur nature, inauguré en 1951, peuplé de sculptures représentant la Passion du Christ. Inauguré en 1904 à l'initiative du frère André 4, les travaux de l'ensemble du lieu se terminèrent en 19673. L'oratoire a fêté en 2004 le 100e anniversaire de la chapelle initiale du frère André. Le tout domine la ville de son imposante silhouette. Le dôme peut être vu de plusieurs endroits dans la ville et même de l'extérieur de l'île. Il est le troisième plus grand oratoire au monde après celui de la basilique Notre-Dame de la Paix de Yamoussoukro et de la basilique Saint-Pierre de Rome. C'est le lieu de pèlerinage le plus important dédié à saint Joseph à travers le monde. Il attire environ deux millions de visiteurs chaque année, provenant de toutes les parties du monde. C'est aussi la plus grande église du Canada. L'Oratoire a été reconnu comme un lieu historique national du Canada le 3 mai 20041. Il a été désigné en tant que l'un des cinq sanctuaires nationaux du Canada par la Conférence des évêques catholiques du Canada.",
                        Lat = 45.493304,
                        Long = -73.6226196
                    }
                },
                {
                    "McGill", new Building
                    {
                        Img = Resource.Drawable.mcgill,
                        Description = "L'université McGill (en anglais : McGill University), située à Montréal, est l'une des plus anciennes universités du Canada. L'université possède deux campus, séparés par 35 kilomètres. Le campus principal est au centre-ville de Montréal et le campus MacDonald est à Sainte-Anne-de-Bellevue, dans la banlieue. McGill compte parmi ses anciens élèves 12 prix Nobel et 142 boursiers de Rhodes, ainsi que trois astronautes, trois premiers ministres canadiens, treize juges de la Cour suprême du Canada, quatre dirigeants étrangers, 28 ambassadeurs étrangers, neuf Oscars, onze gagnants des Grammy Awards, trois gagnants du prix Pulitzer et 28 médaillés olympiques. Tout au long de sa longue histoire, les anciens élèves de McGill ont contribué à invention du football, du basket-ball et du hockey sur glace. L'université McGill ou ses anciens élèves ont également fondé plusieurs grandes universités et collèges, y compris les universités de la Colombie-Britannique, de Victoria et de l'Alberta, de l'École de médecine et de la médecine dentaire de Schulich, de l'École de médecine de l'Université Johns Hopkins et du Collège Dawson",
                        Lat = 45.5047847,
                        Long = -73.5793398
                    }
                },
                {
                    "Concordia", new Building
                    {
                        Img = Resource.Drawable.Concordia,
                        Description = "L’Université Concordia (dérivé de la devise de Montréal, Concordia salus, ou en français « la prospérité par la concorde ») est une université publique québécoise situé à Montréal. Celui-ci est scindée en deux campus majeurs distant de sept kilomètres : le campus Sir-George-Williams dans le centre-ville de Montréal (station de métro Guy-Concordia), et le campus Loyola dans le quartier résidentiel de Notre-Dame-de-Grâce (station de métro Vendôme). Même si cette institution est officiellement bilingue2, Concordia représente, avec McGill, une des deux universités d'enseignement anglais de Montréal. L'université comptait, en 2007, 39 230 étudiants.",
                        Lat = 45.4972657,
                        Long = -73.5812114
                    }
                },
                 {
                    "ETS", new Building
                    {
                        Img = Resource.Drawable.Ets,
                        Description = "L'École de technologie supérieure est une constituante du réseau de l'Université du Québec. Fondée en 1974, l'ÉTS est spécialisée dans l’enseignement et la recherche en génie et le transfert technologique.",
                        Lat = 45.4946761,
                        Long = -73.5622961
                    }
                },
            };

            foreach (var item in Buildings)
            {
                item.Value.Name = item.Key;
            }
        }
    }
}