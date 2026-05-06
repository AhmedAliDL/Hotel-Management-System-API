using Domain.Enums;

public static class CountryCityMapper
{
    public static readonly Dictionary<Country?, List<City?>> Map = new()
    {
        {
            Country.Egypt, new List<City?>
            {
                City.Cairo,
                City.Alexandria,
                City.Giza
            }
        },
        {
            Country.UnitedStates, new List<City?>
            {
                City.NewYork,
                City.LosAngeles,
                City.Chicago
            }
        },
        {
            Country.UnitedKingdom, new List<City?>
            {
                City.London,
                City.Manchester,
                City.Birmingham
            }
        },
        {
            Country.France, new List<City?>
            {
                City.Paris,
                City.Lyon,
                City.Marseille
            }
        },
        {
            Country.Italy, new List<City?>
            {
                City.Rome,
                City.Milan,
                City.Venice
            }
        },
        {
            Country.Spain, new List<City?>
            {
                City.Madrid,
                City.Barcelona,
                City.Valencia
            }
        },
        {
            Country.Japan, new List<City?>
            {
                City.Tokyo,
                City.Osaka,
                City.Kyoto
            }
        },
        {
            Country.UnitedArabEmirates, new List<City?>
            {
                City.Dubai,
                City.AbuDhabi,
                City.Sharjah
            }
        },
        {
            Country.Turkey, new List<City?>
            {
                City.Istanbul,
                City.Ankara,
                City.Antalya
            }
        },
        {
            Country.Brazil, new List<City?>
            {
                City.RioDeJaneiro,
                City.SaoPaulo,
                City.Brasilia
            }
        },
        {
            Country.Germany, new List<City?>
            {
                City.Berlin,
                City.Munich,
                City.Hamburg
            }
        },
        {
            Country.India, new List<City?>
            {
                City.Mumbai,
                City.Delhi,
                City.Bangalore
            }
        },
        {
            Country.Canada, new List<City?>
            {
                City.Toronto,
                City.Vancouver,
                City.Montreal
            }
        },
        {
            Country.Australia, new List<City?>
            {
                City.Sydney,
                City.Melbourne,
                City.Brisbane
            }
        }
    };
}